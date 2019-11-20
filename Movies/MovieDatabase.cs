using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Movies
{
    /// <summary>
    /// A class representing a database of movies
    /// </summary>
    public static class MovieDatabase
    {
        private static List<Movie> movies;

        /// <summary>
        /// Loads the movie database from the JSON file
        /// </summary>

        public static List<Movie> All {
            get
            {
                if (movies == null)
                {
                    using (StreamReader file = System.IO.File.OpenText("movies.json"))
                    {
                        string json = file.ReadToEnd();
                        movies = JsonConvert.DeserializeObject<List<Movie>>(json);
                    }
                }
                return movies;
            }
        }

        public static List<Movie> Search(string searchString)
        {
            if (searchString == null)
            {
                return All;
            }
            List<Movie> result = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(movie);
                }
            }
            return result;
        }

        public static List<Movie> Filter(List<string> ratings)
        {
            List<Movie> result = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (ratings.Contains(movie.MPAA_Rating))
                {
                    result.Add(movie);
                }
            }
            return result;
        }

        public static List<Movie> SearchAndFilter(string searchString, List<string> ratings)
        {
            List<Movie> result = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (ratings.Contains(movie.MPAA_Rating) 
                    && movie.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(movie);
                }
            }
            return result;
        }

        public static List<Movie> Search(List<Movie> movies, string term)
        {
            List<Movie> result = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.Title.Contains(term, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(movie);
                }
            }
            return result;
        }

        public static List<Movie> FilterByMpaa(List<Movie> movies, List<string> mpaa)
        {
            List<Movie> result = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (mpaa.Contains(movie.MPAA_Rating))
                {
                    result.Add(movie);
                }
            }
            return result;
        }

        public static List<Movie> FilterByMinIMDB(List<Movie> movies, float minIMDB)
        {
            List<Movie> result = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (minIMDB<=movie.IMDB_Rating)
                {
                    result.Add(movie);
                }
            }
            return result;
        }
        public static List<Movie> FilterByMaxIMDB(List<Movie> movies, float maxIMDB)
        {
            List<Movie> result = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (maxIMDB >= movie.IMDB_Rating)
                {
                    result.Add(movie);
                }
            }
            return result;
        }
    }
}

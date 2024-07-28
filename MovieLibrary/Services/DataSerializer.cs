﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MovieLibrary.Models;

namespace MovieLibrary.Services
{
    public class DataSerializer
    {
        public static string path = $"C:/Users/arjun.pawar/source/repos/FinalLayeredMovieStoreApp/MovieLibrary/Assets/movies.json";
        //static string path = ConfigurationManager.AppSettings["filePath"]!.ToString();
        public static void SerializeMovieStore(List<Movie> movies)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(JsonSerializer.Serialize(movies)); //movies
            }
        }

        public static List<Movie> DeserializeMovieStore()
        {
            if (!File.Exists(path))
                return new List<Movie>();
            using (StreamReader sr = new StreamReader(path))
            {
                List<Movie> movies = JsonSerializer.Deserialize<List<Movie>>(sr.ReadToEnd());
                return movies;
            }

        }
    }
}
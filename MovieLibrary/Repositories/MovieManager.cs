using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Exceptions;
using MovieLibrary.Models;
using MovieLibrary.Services;

namespace MovieLibrary.Repositories
{
    public class MovieManager
    {
        static List<Movie> movies = new List<Movie>();

        public MovieManager()
        {
            movies = DataSerializer.DeserializeMovieStore();
        }

        public static void AddNewMovie(int id, string name, string genre, int yearOfRelease)
        {
            if (movies.Count >= 5)
            {
                throw new CapacityIsFullException("The capacity is full. Cannot add more movies.");
                return;
            }
            else
            {
                try
                {

                    Movie newMovie = Movie.AddMovie(id, name, genre, yearOfRelease);
                    movies.Add(newMovie);
                    
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }
        }

        public static List<Movie> DisplayMovies()
        {
            if (movies.Count == 0)
                throw new MovieStoreEmptyException("No Movies Found,Movie Store Empty");
            else
            {
                //edit
                return movies;
            }
        }

        public static Movie FindMovieById(int id)
        {
            Movie findMovie = null;


            findMovie = movies.Where(item => item.Id == id).FirstOrDefault();



            if (findMovie != null)
                return findMovie;
            else
                throw new MovieNotFoundException("Movie Not Found");
           

        }

        public static void UpdateMovieName(int id,string name)
        {
            Movie findMovie = FindMovieById(id);
            if (findMovie == null)
                throw new MovieNotFoundException("Movie doesnt exists. Please check ID again");
            else
            {
               
                findMovie.Name = name;
              
            }
        }
        public static void RemoveMovie(int id)
        {
            Movie findMovie = FindMovieById(id);
            if (findMovie != null)
                movies.Remove(findMovie);
            else
                throw new MovieNotFoundException("Movie doesnt exists. Please check ID again");
        }

        public static void ClearAllMovies()
        {
            if (movies.Count == 0)
                throw new MovieStoreEmptyException("Movie Store list is already Empty, nothing to clear");
            else
            {
                movies.Clear();
            }
        }


        public static void ExitMovie()
        {
            DataSerializer.SerializeMovieStore(movies);

        }

    }
}

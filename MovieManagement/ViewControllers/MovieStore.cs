using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Repositories;
using MovieLibrary.Exceptions;

namespace MovieManagement.ViewControllers
{
    internal class MovieStore
    {
        public static void DisplayMenu()
        {
            new MovieManager();

            while (true)
            {
                Console.WriteLine("Welcome to Movie Management System: \n" +
                    "What do you wish to do?\n" +
                    "1. Add a Movie\n" +
                    "2. Display All Movie\n" +
                    "3. Find Movie By ID\n" +
                    "4. Update Movie details\n" +
                    "5. Remove Movie By Name\n" +
                    "6. Clear All Movies\n" +
                    "7. Exit   ");

                int choice = Convert.ToInt32(Console.ReadLine());


                //DoTask(choice);



                try
                {
                    DoTask(choice);
                }
                catch (MovieStoreEmptyException me)
                {
                    Console.WriteLine(me.Message);
                }
                catch (MovieNotFoundException mf)
                {
                    Console.WriteLine(mf.Message);
                }
                catch (CapacityIsFullException ce)
                {
                    Console.WriteLine(ce.Message);
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

            static void DoTask(int choice)
            {
                switch (choice)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Display();
                        break;
                    case 3:
                        Find();

                        break;
                    case 4:
                        Update();
                        break;
                    case 5:
                        Remove();
                        break;
                    case 6:
                        MovieManager.ClearAllMovies();
                        Console.WriteLine("All movies are cleared");
                        break;
                    case 7:
                        MovieManager.ExitMovie();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter Valid Input");
                        break;


                }
            }


            static void Add()
            {

                Console.WriteLine("Enter movie ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter movie name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Movie Name cannot be Empty");


                Console.WriteLine("Enter mOvie Genre: ");
                string genre = Console.ReadLine();
                Console.WriteLine("ENter Year of Release: ");
                int yearOfRelease = Convert.ToInt32(Console.ReadLine());

                MovieManager.AddNewMovie(id, name, genre, yearOfRelease);
                Console.WriteLine("Movie added Successfully");
            }

            static void Display()
            {

                var movies =  MovieManager.DisplayMovies();
                movies.ForEach(movie=> Console.WriteLine(movie));
            }
            
            static void Find()
            {
                Console.WriteLine("Enter ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var movie = MovieManager.FindMovieById(id);
                Console.WriteLine(movie);
            }

            static void Remove()
            {
                Console.WriteLine("Enter id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                MovieManager.RemoveMovie(id);
                Console.WriteLine("Movie Removed Successfuly\n");
            }

            static void Update()
            {
                Console.WriteLine("Enter id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Movie name: ");
                string name = Console.ReadLine();
                MovieManager.UpdateMovieName(id,name);
                Console.WriteLine("Movie Updated successfully");
            }

        }
    }
}

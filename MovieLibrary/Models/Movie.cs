using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int YearOfRelease { get; set; }

        public Movie()
        {
            
        }


        public Movie(int id, string name, string genre)
        {
            Id = id;
            Name = name;
            Genre = genre;
        }

        public Movie(int id, string name, string genre, int yearOfRelease): this(id,name, genre)
        {
            YearOfRelease = yearOfRelease;
        }

        public static Movie AddMovie(int id,string name,string genre,int yearOfRelease)
        {
            return new Movie(id,name,genre,yearOfRelease);
        }

        public override string ToString()
        {
            return $"================Movie ID.{Id}====================\n" +
                $"Movie Name: {Name}\n" +
                $"Movie Genre: {Genre}\n" +
                $"Year of Release: {YearOfRelease}\n" +
                $"================================================";
        }
    }
}

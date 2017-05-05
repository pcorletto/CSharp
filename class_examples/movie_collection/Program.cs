using System;
using System.Collections;
using System.Collections.Generic;

namespace movie_collection
{
    class Movie
    {
        public string Title{get; set;}
        public string Genre{get; set;}
        public int ReleaseYear{get; set;}
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Movie firstOne = new Movie();
            firstOne.Title = "Guardians Of The Galaxy, Vol. 2";
            firstOne.Genre = "Sci Fi";
            firstOne.ReleaseYear = 2017;

            Movie secondOne = new Movie();
            secondOne.Title = "This Is Not What I Expected";
            secondOne.Genre = "Romance";
            secondOne.ReleaseYear = 2017;

            Movie thirdOne = new Movie();
            thirdOne.Title = "Chuck";
            thirdOne.Genre = "Sports";
            thirdOne.ReleaseYear = 2017;
            
            List<Movie> movieCollection = new List<Movie>();

            movieCollection.Add(firstOne);
            movieCollection.Add(secondOne);
            movieCollection.Add(thirdOne);

            foreach(Movie listing in movieCollection)
            {
                Console.WriteLine("Title: " + listing.Title + "\n" + "Genre: " + listing.Genre + "\n" + "Release Year: " + listing.ReleaseYear);
            }
            
        }
    }
}

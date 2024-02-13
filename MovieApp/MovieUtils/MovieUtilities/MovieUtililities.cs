using MovieApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.MovieUtils
{
    public class MovieUtilities
    {
        public static List<Movie> SelectAll()

        //logic layer method that connects and communicates with the data layer/tier
        {
            //create a data access object 
            //return MovieData's MovieSelectAll method
            MovieData md = new MovieData();

            return md.MovieSelectAll();

        }
        public void Update(int id, string title, string director)
        {
            //transform fields/raw data into an object
            //mapping

            Movie MovieToUpdate = new Movie(id, title, director);
            //create movie data object
            MovieData md = new MovieData();
            //call the movie update, passing the Movie object we create
            md.MovieUpdate(MovieToUpdate);

        }

    }
}

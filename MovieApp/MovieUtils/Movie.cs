using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.MovieUtils
{
    public class Movie
    {   //private properies or members
        private string title;

        private string director;

        private int id;

        //overloaded constructor
        public Movie(int id, string title, string director)

        {
            //call the property accessors 
            Id = id;

            Title = title;

            Director = director;

        }


        public int Id

        {

            get { return id; }

            set { id = value; }

        }


        public string Title

        {

            get { return title; }

            set { title = value; }

        }

        public string Director

        {

            get { return director; }

            set { director = value; }

        }
    }
}

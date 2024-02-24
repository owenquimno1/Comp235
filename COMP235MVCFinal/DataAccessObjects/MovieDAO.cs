using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using COMP235MVCFinal.Models;
using System.Data.SqlClient;

namespace COMP235MVCFinal.DataAccessObjects
{
    public class MovieDAO
    {
        string conString ="Data Source=localhost;Initial Catalog=Movies;Integrated Security=True";
        public Movie getMovieById(int id)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Id,Title,Director,Description FROM Movies where Id=@Id";
            cmd.Parameters.AddWithValue("Id", id);
            List<Movie> movies = new List<Movie>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Movie m = new Movie(
            Convert.ToInt32(reader["Id"]),
            reader["Title"].ToString(),
            reader["Director"].ToString(),
            reader["Description"].ToString()
            );
            return m;
        }


        public void InsertMovie(Movie m)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Movies(Title, Director) VALUES(@Title, @Director)";
            cmd.Parameters.AddWithValue("@Title", m.Title);
            cmd.Parameters.AddWithValue("@Director", m.Director);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public Movies getAllMovies()
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Id,Title,Director FROM Movies";
            List<Movie> ms = new List<Movie>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Movie m = new Movie(
                Convert.ToInt32(reader["Id"]),
                reader["Title"].ToString(),
                reader["Director"].ToString()
                );
                ms.Add(m);
            }
            Movies allMovies = new Movies(); // create an instance of the class assign the collection and return it
            allMovies.Items = ms;
            return allMovies;
        }




    }
}
using MovieApp.Data.ConnectionHandler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Data
{
    class MovieData
    {
        public List<Movie> MovieSelectAll()
        {
            List<Movie> movies = new List<Movie>();
            SqlConnection con = new
            SqlConnection(Connections.ConnectionString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT ID, Title, Director FROM Movies";

            using (con)
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    movies.Add(new Movie(
                    (int)reader["Id"],
                    (string)reader["Title"],
                    (string)reader["Director"]));
                }
            }
            return movies;
        }
    }

}


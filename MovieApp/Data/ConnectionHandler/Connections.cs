using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Data.ConnectionHandler
{
    public class Connections
    {
        //represents ADO.NET connection string to the SQL DB
        //set to static and readonly so it cannot be updated outside of this class
        private static readonly string connectionString;


        static Connections()
        {
            //ADO.NET connection string
            //Data Source - server we are connecting to
            //Initial Catalog - DB we are connecting to
            //Integrated Security - allows for windows auth
            //Trust Server Certificate - for additional security
            connectionString = "Data Source=localhost; Initial Catalog=Movies; Integrated Security=True; TrustServerCertificate=True";
        }
        //property accessor method

        public static string ConnectionString()
        {
            return connectionString;
        }


    }
}

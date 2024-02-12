using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Data.ConnectionHandler
{
    public class Connections
    {
        private static readonly string connectionString;
        static Connections()
        {
            connectionString = < Your connection string goes here >
        }
        public static string ConnectionString()
        {
            return connectionString;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenStoreApp.Helpers
{
    public static class Database
    {
        private static string connectionString = "Data Source=DESKTOP-URN6SR5\\SQLEXPRESS;Initial Catalog=BookHavenStoreDB;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        internal static string GetConnectionString()
        {
            // Replace with your actual connection string
            return "Data Source=DESKTOP-URN6SR5\\SQLEXPRESS;Initial Catalog=BookHavenStoreDB;Integrated Security=True;TrustServerCertificate=True";
        }
    }
}

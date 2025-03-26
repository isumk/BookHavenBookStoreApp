using System;
using System.Data.SqlClient;

namespace BookHavenApp.DataAccess
{
    public static class Database
    {
        public static string ConnectionString { get; } =
            "Data Source=DESKTOP-URN6SR5\\SQLEXPRESS;Initial Catalog=BookHavenStoreDB;Integrated Security=True;TrustServerCertificate=True";

        
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}


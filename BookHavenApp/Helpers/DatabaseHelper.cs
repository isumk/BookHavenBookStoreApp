using System;
using System.Data;
using System.Data.SqlClient;

namespace BookHavenStoreApp.Helpers
{
    public class DatabaseHelper
    {
        private static readonly string connectionString = "Data Source=DESKTOP-URN6SR5\\SQLEXPRESS;Initial Catalog=BookHavenStoreDB;Integrated Security=True;TrustServerCertificate=True";

        // Get database connection
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Execute a non-query command (INSERT, UPDATE, DELETE)
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // Execute a query and return a DataTable
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}


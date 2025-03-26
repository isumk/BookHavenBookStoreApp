using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BookHavenApp.Models;

public class CustomerRepo
{
    private readonly string connectionString = "Data Source=DESKTOP-URN6SR5\\SQLEXPRESS;Initial Catalog=BookHavenStoreDB;Integrated Security=True;TrustServerCertificate=True";

    public List<Customer> GetAllCustomers()
    {
        List<Customer> customers = new List<Customer>();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT CustomerId, Name FROM Customers";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            CustomerId = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }
        }

        return customers;
    }
}

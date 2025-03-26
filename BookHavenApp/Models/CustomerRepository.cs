using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using BookHavenApp.DataAccess;

namespace BookHavenApp.Models
{
    public class CustomerRepository
    {
        private readonly string connectionString = Database.ConnectionString;

        public List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        CustomerId = (int)reader["CustomerId"],
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Contact = reader["Contact"].ToString(),
                        Address = reader["Address"].ToString()
                    });
                }
            }
            return customers;
        }

        public void AddCustomer(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Customers (Name, Email, Contact, Address) VALUES (@Name, @Email, @Contact, @Address)", conn);
                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Contact", customer.Contact);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Customers SET Name=@Name, Email=@Email, Contact=@Contact, Address=@Address WHERE CustomerId=@CustomerId", conn);
                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Contact", customer.Contact);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerId=@CustomerId", conn);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Customer> SearchCustomers(string keyword)
        {
            var customers = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE Name LIKE @keyword OR Contact LIKE @keyword", conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        CustomerId = (int)reader["CustomerId"],
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Contact = reader["Contact"].ToString(),
                        Address = reader["Address"].ToString()
                    });
                }
            }
            return customers;
        }
    }
}

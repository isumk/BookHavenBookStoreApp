using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using BookHavenApp.DataAccess;

namespace BookHavenApp.Models
{
    public class SupplierRepository
    {
        private string connectionString = Database.ConnectionString;

        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Suppliers", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    suppliers.Add(new Supplier
                    {
                        SupplierId = (int)reader["SupplierId"],
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString()
                    });
                }
            }
            return suppliers;
        }

        public void AddSupplier(Supplier supplier)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Suppliers (Name, Email, Phone, Address) VALUES (@Name, @Email, @Phone, @Address)", conn);
                cmd.Parameters.AddWithValue("@Name", supplier.Name);
                cmd.Parameters.AddWithValue("@Email", supplier.Email);
                cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
                cmd.Parameters.AddWithValue("@Address", supplier.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateSupplier(Supplier supplier)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Suppliers SET Name=@Name, Email=@Email, Phone=@Phone, Address=@Address WHERE SupplierId=@SupplierId", conn);
                cmd.Parameters.AddWithValue("@SupplierId", supplier.SupplierId);
                cmd.Parameters.AddWithValue("@Name", supplier.Name);
                cmd.Parameters.AddWithValue("@Email", supplier.Email);
                cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
                cmd.Parameters.AddWithValue("@Address", supplier.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSupplier(int supplierId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Suppliers WHERE SupplierId=@SupplierId", conn);
                cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Supplier> SearchSuppliers(string keyword)
        {
            List<Supplier> suppliers = new List<Supplier>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Suppliers WHERE Name LIKE @keyword OR Email LIKE @keyword OR Phone LIKE @keyword", conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    suppliers.Add(new Supplier
                    {
                        SupplierId = (int)reader["SupplierId"],
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString()
                    });
                }
            }
            return suppliers;
        }
    }
}

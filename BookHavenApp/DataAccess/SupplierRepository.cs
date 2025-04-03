using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookHavenStoreApp.Helpers;
using BookHavenStoreApp.Models;

namespace BookHavenStoreApp.DataAccess
{
    public class SupplierRepository
    {
        private readonly string connectionString = Database.GetConnectionString();


        // ✅ Get All Suppliers
        public DataTable GetAllSuppliers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Suppliers";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // ✅ Add a New Supplier
        public bool AddSupplier(Supplier supplier)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Suppliers (Name, Phone, Email, Address) VALUES (@Name, @Phone, @Email, @Address)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", supplier.Name);
                cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
                cmd.Parameters.AddWithValue("@Email", supplier.Email);
                cmd.Parameters.AddWithValue("@Address", supplier.Address);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ✅ Update Supplier Details
        public bool UpdateSupplier(Supplier supplier)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Suppliers SET Name=@Name, Phone=@Phone, Email=@Email, Address=@Address WHERE SupplierID=@SupplierID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
                cmd.Parameters.AddWithValue("@Name", supplier.Name);
                cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
                cmd.Parameters.AddWithValue("@Email", supplier.Email);
                cmd.Parameters.AddWithValue("@Address", supplier.Address);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ✅ Delete a Supplier
        public bool DeleteSupplier(int supplierId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Suppliers WHERE SupplierID=@SupplierID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SupplierID", supplierId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ✅ Get Supplier Orders
        public DataTable GetSupplierOrders()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM SupplierOrders";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // ✅ Place a Supplier Order
        public bool PlaceSupplierOrder(int supplierId, int bookId, int quantity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO SupplierOrders (SupplierID, BookID, Quantity, Status) VALUES (@SupplierID, @BookID, @Quantity, 'Pending')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SupplierID", supplierId);
                cmd.Parameters.AddWithValue("@BookID", bookId);
                cmd.Parameters.AddWithValue("@Quantity", quantity);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ✅ Mark Order as Received and Update Stock
        public bool MarkOrderAsReceived(int orderId, int bookId, int quantity)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Update order status
                    string updateOrderQuery = "UPDATE SupplierOrders SET Status='Received' WHERE OrderID=@OrderID";
                    SqlCommand updateOrderCmd = new SqlCommand(updateOrderQuery, conn, transaction);
                    updateOrderCmd.Parameters.AddWithValue("@OrderID", orderId);
                    updateOrderCmd.ExecuteNonQuery();

                    // Update book stock
                    string updateStockQuery = "UPDATE Books SET Stock = Stock + @Quantity WHERE BookID=@BookID";
                    SqlCommand updateStockCmd = new SqlCommand(updateStockQuery, conn, transaction);
                    updateStockCmd.Parameters.AddWithValue("@Quantity", quantity);
                    updateStockCmd.Parameters.AddWithValue("@BookID", bookId);
                    updateStockCmd.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}

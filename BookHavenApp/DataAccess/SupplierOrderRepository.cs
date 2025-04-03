using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookHavenStoreApp.Models;
using BookHavenStoreApp.Helpers;

namespace BookHavenStoreApp.DataAccess
{
    public class SupplierOrderRepository
    {
        // Add a supplier order
        public static bool AddSupplierOrder(int supplierId, int bookId, int quantity)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "INSERT INTO SupplierOrders (SupplierId, BookId, Quantity) VALUES (@SupplierId, @BookId, @Quantity)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Mark an order as completed and update stock
        public static bool CompleteSupplierOrder(int orderId, int bookId, int quantity)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "UPDATE SupplierOrders SET Status = 'Completed' WHERE OrderId = @OrderId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);

                    conn.Open();
                    bool orderUpdated = cmd.ExecuteNonQuery() > 0;

                    if (orderUpdated)
                    {
                        BookRepository bookRepo = new BookRepository(); // Create an instance
                        bool stockUpdated = bookRepo.UpdateStock(bookId, quantity); // Use instance method
                        return stockUpdated;
                    }

                    return false;
                }
            }
        }
    }
}

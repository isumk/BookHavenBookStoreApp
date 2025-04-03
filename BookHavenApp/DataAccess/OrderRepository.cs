using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookHavenStoreApp.Models;
using BookHavenStoreApp.Helpers;


namespace BookHavenStoreApp.DataAccess
{
    public class OrderRepository
    {
        private readonly string connectionString = Database.GetConnectionString();

        // Get all orders (Order History)
        public DataTable GetAllOrders()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT OrderID, CustomerID, OrderDate, Status, FinalAmount FROM Orders ORDER BY OrderDate DESC";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    DataTable ordersTable = new DataTable();
                    adapter.Fill(ordersTable);
                    return ordersTable;
                }
            }
        }

        // Get order details
        public DataTable GetOrderDetails(int orderID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT oi.OrderItemID, oi.BookID, b.Title AS BookTitle, oi.Quantity, oi.Price, oi.Total
                                 FROM OrderItems oi
                                 JOIN Books b ON oi.BookID = b.BookID
                                 WHERE oi.OrderID = @OrderID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderID);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable orderDetailsTable = new DataTable();
                        adapter.Fill(orderDetailsTable);
                        return orderDetailsTable;
                    }
                }
            }
        }
    }
}

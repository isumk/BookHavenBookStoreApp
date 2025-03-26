using BookHavenApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookHavenApp;

namespace BookHavenApp.DataAccess
{
    public class OrderRepo
    {
        private readonly Database _database;

        public OrderRepo()
        {
            _database = new Database();
        }

        public List<Order> GetOrders()
        {
            var orders = new List<Order>();
            using (var connection = _database.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Orders";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orders.Add(new Order
                    {
                        OrderId = Convert.ToInt32(reader["OrderId"]),
                        CustomerId = Convert.ToInt32(reader["CustomerId"]),
                        OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                        Status = reader["Status"].ToString()
                    });
                }
            }
            return orders;
        }

        public void AddOrder(Order order)
        {
            using (var connection = _database.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Orders (CustomerId, OrderDate, Status) VALUES (@CustomerId, @OrderDate, @Status)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                command.Parameters.AddWithValue("@Status", order.Status);
                command.ExecuteNonQuery();
            }
        }

        public List<OrderItem> GetOrderItems(int orderId)
        {
            var orderItems = new List<OrderItem>();
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM OrderItems WHERE OrderId = @OrderId";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@OrderId", orderId);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orderItems.Add(new OrderItem
                    {
                        OrderItemId = Convert.ToInt32(reader["OrderItemId"]),
                        OrderId = Convert.ToInt32(reader["OrderId"]),
                        BookId = Convert.ToInt32(reader["BookId"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Price = Convert.ToDecimal(reader["Price"])
                    });
                }
            }
            return orderItems;
        }

        public void UpdateOrderStatus(int orderId, string status)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Orders SET Status = @Status WHERE OrderId = @OrderId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@OrderId", orderId);
                command.ExecuteNonQuery();
            }
        }

        public void CompletePendingOrder(int orderId)
        {
            UpdateOrderStatus(orderId, "Completed");
        }
    }
}

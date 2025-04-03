using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookHavenStoreApp.Helpers;
using BookHavenStoreApp.Models;

namespace BookHavenStoreApp.DataAccess
{
    public class OrderRepository
    {
        private readonly string connectionString = Database.GetConnectionString();

        // ✅ 1. Add a New Order
        public int AddOrder(Order order)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Insert Order
                    string queryOrder = @"
                        INSERT INTO Orders (CustomerID, FinalAmount) 
                        OUTPUT INSERTED.OrderID 
                        VALUES (@CustomerID, @FinalAmount)";

                    SqlCommand cmdOrder = new SqlCommand(queryOrder, conn, transaction);
                    cmdOrder.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                    cmdOrder.Parameters.AddWithValue("@FinalAmount", order.FinalAmount);
                    int orderID = (int)cmdOrder.ExecuteScalar();

                    // Insert Order Items & Update Stock
                    foreach (var item in order.OrderItems)
                    {
                        string queryItem = @"
                            INSERT INTO OrderItems (OrderID, BookID, Quantity, Price) 
                            VALUES (@OrderID, @BookID, @Quantity, @Price)";

                        SqlCommand cmdItem = new SqlCommand(queryItem, conn, transaction);
                        cmdItem.Parameters.AddWithValue("@OrderID", orderID);
                        cmdItem.Parameters.AddWithValue("@BookID", item.BookID);
                        cmdItem.Parameters.AddWithValue("@Quantity", item.Quantity);
                        cmdItem.Parameters.AddWithValue("@Price", item.Price);
                        cmdItem.ExecuteNonQuery();

                        // Update Stock
                        string queryStock = "UPDATE Books SET StockQuantity = StockQuantity - @Quantity WHERE BookID = @BookID";
                        SqlCommand cmdStock = new SqlCommand(queryStock, conn, transaction);
                        cmdStock.Parameters.AddWithValue("@Quantity", item.Quantity);
                        cmdStock.Parameters.AddWithValue("@BookID", item.BookID);
                        cmdStock.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return orderID;
                }
                catch
                {
                    transaction.Rollback();
                    return -1;
                }
            }
        }

        // ✅ 2. Get All Orders (Order History)
        public DataTable GetAllOrders()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT o.OrderID, o.OrderDate, o.CustomerID, c.Name
                    FROM Orders o
                    INNER JOIN Customers c ON o.CustomerID = c.CustomerID
                    ORDER BY o.OrderDate DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable ordersTable = new DataTable();
                adapter.Fill(ordersTable);
                return ordersTable;
            }
        }

        // ✅ 3. Get Order Details (Books in Order)
        public DataTable GetOrderDetails(int orderID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT b.Title, oi.Quantity, oi.Price, oi.Total 
                    FROM OrderItems oi
                    INNER JOIN Books b ON oi.BookID = b.BookID
                    WHERE oi.OrderID = @OrderID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OrderID", orderID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable orderDetailsTable = new DataTable();
                adapter.Fill(orderDetailsTable);
                return orderDetailsTable;
            }
        }

        // ✅ 4. Update an Order (Change Items)
        public bool UpdateOrder(Order order)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Update Order Final Amount
                    string queryUpdateOrder = "UPDATE Orders SET FinalAmount = @FinalAmount WHERE OrderID = @OrderID";
                    SqlCommand cmdUpdateOrder = new SqlCommand(queryUpdateOrder, conn, transaction);
                    cmdUpdateOrder.Parameters.AddWithValue("@OrderID", order.OrderID);
                    cmdUpdateOrder.Parameters.AddWithValue("@FinalAmount", order.FinalAmount);
                    cmdUpdateOrder.ExecuteNonQuery();

                    // Remove Old Order Items
                    string queryDeleteItems = "DELETE FROM OrderItems WHERE OrderID = @OrderID";
                    SqlCommand cmdDeleteItems = new SqlCommand(queryDeleteItems, conn, transaction);
                    cmdDeleteItems.Parameters.AddWithValue("@OrderID", order.OrderID);
                    cmdDeleteItems.ExecuteNonQuery();

                    // Insert Updated Order Items
                    foreach (var item in order.OrderItems)
                    {
                        string queryItem = @"
                            INSERT INTO OrderItems (OrderID, BookID, Quantity, Price) 
                            VALUES (@OrderID, @BookID, @Quantity, @Price)";

                        SqlCommand cmdItem = new SqlCommand(queryItem, conn, transaction);
                        cmdItem.Parameters.AddWithValue("@OrderID", order.OrderID);
                        cmdItem.Parameters.AddWithValue("@BookID", item.BookID);
                        cmdItem.Parameters.AddWithValue("@Quantity", item.Quantity);
                        cmdItem.Parameters.AddWithValue("@Price", item.Price);
                        cmdItem.ExecuteNonQuery();
                    }

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

        // ✅ 5. Delete an Order
        public bool DeleteOrder(int orderID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Delete Order Items
                    string queryDeleteItems = "DELETE FROM OrderItems WHERE OrderID = @OrderID";
                    SqlCommand cmdDeleteItems = new SqlCommand(queryDeleteItems, conn, transaction);
                    cmdDeleteItems.Parameters.AddWithValue("@OrderID", orderID);
                    cmdDeleteItems.ExecuteNonQuery();

                    // Delete Order
                    string queryDeleteOrder = "DELETE FROM Orders WHERE OrderID = @OrderID";
                    SqlCommand cmdDeleteOrder = new SqlCommand(queryDeleteOrder, conn, transaction);
                    cmdDeleteOrder.Parameters.AddWithValue("@OrderID", orderID);
                    cmdDeleteOrder.ExecuteNonQuery();

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

        // ✅ 6. Send Order to POS (Mark as Completed)
        public bool SendToPOS(int orderID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Orders SET Status = 'Completed' WHERE OrderID = @OrderID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OrderID", orderID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}

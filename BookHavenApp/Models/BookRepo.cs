using BookHavenApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BookHavenApp.DataAccess
{
    public class BookRepo
    {
        private readonly Database _database;

        public BookRepo()
        {
            _database = new Database();
        }

        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();
            using (var connection = _database.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Books";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    books.Add(new Book
                    {
                        BookId = Convert.ToInt32(reader["BookId"]),
                        Title = reader["Title"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        StockQuantity = Convert.ToInt32(reader["StockQuantity"])
                    });
                }
            }
            return books;
        }

        public Book GetBookById(int bookId)
        {
            Book book = null;
            using (var connection = _database.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Books WHERE BookId = @BookId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookId", bookId);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    book = new Book
                    {
                        BookId = Convert.ToInt32(reader["BookId"]),
                        Title = reader["Title"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        StockQuantity = Convert.ToInt32(reader["StockQuantity"])
                    };
                }
            }
            return book;
        }

        public void ReduceStock(int bookId, int quantitySold)
        {
            using (var connection = _database.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Books SET StockQuantity = StockQuantity - @QuantitySold WHERE BookId = @BookId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@QuantitySold", quantitySold);
                command.Parameters.AddWithValue("@BookId", bookId);
                command.ExecuteNonQuery();
            }
        }
    }
}

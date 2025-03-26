using BookHavenApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenApp.Models
{
    public static class BookRepository
    {
        public static List<Book> GetBooks(string searchQuery)
        {
            var books = new List<Book>();
            using (var conn = new SqlConnection(Database.ConnectionString))
            {
                string query = "SELECT * FROM Books WHERE Title LIKE @SearchQuery OR Author LIKE @SearchQuery OR ISBN LIKE @SearchQuery";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");

                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var book = new Book
                    {
                        BookId = (int)reader["BookId"],
                        Title = reader["Title"].ToString(),
                        Author = reader["Author"].ToString(),
                        Genre = reader["Genre"].ToString(),
                        ISBN = reader["ISBN"].ToString(),
                        Price = (decimal)reader["Price"],
                        StockQuantity = (int)reader["StockQuantity"]
                    };
                    books.Add(book);
                }
            }
            return books;
        }
        public static bool BookCodeExists(string bookCode)
        {
            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Books WHERE ISBN = @ISBN";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ISBN", bookCode);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static void AddBook(Book book)
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            {
                string query = "INSERT INTO Books (Title, Author, Genre, ISBN, Price, StockQuantity) VALUES (@Title, @Author, @Genre, @ISBN, @Price, @StockQuantity)";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Genre", book.Genre);
                command.Parameters.AddWithValue("@ISBN", book.ISBN);
                command.Parameters.AddWithValue("@Price", book.Price);
                command.Parameters.AddWithValue("@StockQuantity", book.StockQuantity);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void UpdateBook(Book book)
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            {
                string query = "UPDATE Books SET Title = @Title, Author = @Author, Genre = @Genre, ISBN = @ISBN, Price = @Price, StockQuantity = @StockQuantity WHERE BookId = @BookId";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Genre", book.Genre);
                command.Parameters.AddWithValue("@ISBN", book.ISBN);
                command.Parameters.AddWithValue("@Price", book.Price);
                command.Parameters.AddWithValue("@StockQuantity", book.StockQuantity);
                command.Parameters.AddWithValue("@BookId", book.BookId);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteBook(int bookId)
        {
            using (var conn = new SqlConnection(Database.ConnectionString))
            {
                string query = "DELETE FROM Books WHERE BookId = @BookId";
                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@BookId", bookId);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }


    }

}

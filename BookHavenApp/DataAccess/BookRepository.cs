using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BookHavenStoreApp.Models;
using BookHavenStoreApp.Helpers;
using BookHavenStoreApp.Models;

namespace BookHavenStoreApp.DataAccess
{
    public class BookRepository
    {
        // Fetch all books
        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM Books WHERE IsActive = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(new Book
                            {
                                BookId = Convert.ToInt32(reader["BookId"]),
                                ISBN = reader["ISBN"].ToString(),  // Added ISBN
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                Genre = reader["Genre"].ToString(),  // Added Genre
                                Price = Convert.ToDecimal(reader["Price"]),
                                StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                                ReorderLevel = reader["ReorderLevel"] != DBNull.Value ? Convert.ToInt32(reader["ReorderLevel"]) : 0,

                            });
                        }
                    }
                }
            }

            return books;
        }

        // Fetch books with low stock (to place supplier orders)
        public List<Book> GetLowStockBooks()
        {
            List<Book> lowStockBooks = new List<Book>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM Books WHERE StockQuantity <= ReorderLevel";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lowStockBooks.Add(new Book
                            {
                                BookId = Convert.ToInt32(reader["BookId"]),
                                ISBN = reader["ISBN"].ToString(),  // Added ISBN
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                Genre = reader["Genre"].ToString(),  // Added Genre
                                Price = Convert.ToDecimal(reader["Price"]),
                                StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                                ReorderLevel = Convert.ToInt32(reader["ReorderLevel"])
                            });
                        }
                    }
                }
            }

            return lowStockBooks;
        }

        // Update stock after supplier delivery
        public bool UpdateStock(int bookId, int quantity)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "UPDATE Books SET StockQuantity = StockQuantity + @Quantity WHERE BookId = @BookId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@BookId", bookId);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Add a new book
        public bool AddBook(Book book)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "INSERT INTO Books (ISBN, Title, Author, Genre, Price, StockQuantity, ReorderLevel) VALUES (@ISBN, @Title, @Author, @Genre, @Price, @StockQuantity, @ReorderLevel)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ISBN", book.ISBN);  // Added ISBN
                    cmd.Parameters.AddWithValue("@Title", book.Title);
                    cmd.Parameters.AddWithValue("@Author", book.Author);
                    cmd.Parameters.AddWithValue("@Genre", book.Genre);  // Added Genre
                    cmd.Parameters.AddWithValue("@Price", book.Price);
                    cmd.Parameters.AddWithValue("@StockQuantity", book.StockQuantity);
                    cmd.Parameters.AddWithValue("@ReorderLevel", book.ReorderLevel);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Update an existing book
        public bool UpdateBook(Book book)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "UPDATE Books SET ISBN=@ISBN, Title=@Title, Author=@Author, Genre=@Genre, Price=@Price, StockQuantity=@StockQuantity, ReorderLevel=@ReorderLevel WHERE BookId=@BookId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ISBN", book.ISBN);  // Added ISBN
                    cmd.Parameters.AddWithValue("@Title", book.Title);
                    cmd.Parameters.AddWithValue("@Author", book.Author);
                    cmd.Parameters.AddWithValue("@Genre", book.Genre);  // Added Genre
                    cmd.Parameters.AddWithValue("@Price", book.Price);
                    cmd.Parameters.AddWithValue("@StockQuantity", book.StockQuantity);
                    cmd.Parameters.AddWithValue("@ReorderLevel", book.ReorderLevel);
                    cmd.Parameters.AddWithValue("@BookId", book.BookId);


                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Delete a book
        public bool DeleteBook(int bookId)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "UPDATE Books SET IsActive = 0 WHERE BookId = @BookId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookId", bookId);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        // Search books by Title, Author, or Genre
        public List<Book> SearchBooks(string searchTerm)
        {
            List<Book> books = new List<Book>();

            using (SqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT * FROM Books WHERE Title LIKE @SearchTerm OR Author LIKE @SearchTerm OR Genre LIKE @SearchTerm";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(new Book
                            {
                                BookId = Convert.ToInt32(reader["BookId"]),
                                ISBN = reader["ISBN"].ToString(),  // Added ISBN
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                Genre = reader["Genre"].ToString(),  // Added Genre
                                Price = Convert.ToDecimal(reader["Price"]),
                                StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                                ReorderLevel = reader["ReorderLevel"] != DBNull.Value ? Convert.ToInt32(reader["ReorderLevel"]) : 0,
                            });
                        }
                    }
                }
            }

            return books;
        }
        public Book GetBookByID(int bookID)
        {
            Book book = null;
            string query = "SELECT * FROM Books WHERE BookID = @BookID";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BookID", bookID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            book = new Book
                            {
                                BookId = Convert.ToInt32(reader["BookID"]),
                                Title = reader["Title"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                StockQuantity = Convert.ToInt32(reader["StockQuantity"])
                            };
                        }
                    }
                }
            }
            return book;
        }

    }
}

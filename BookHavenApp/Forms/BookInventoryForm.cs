using BookHavenApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHavenApp.Forms
{
    public partial class BookInventoryForm: Form
    {
        public BookInventoryForm()
        {
            InitializeComponent();
        }

        private void BookInventoryForm_Load(object sender, EventArgs e)
        {
            // Load books from the database when the form is loaded
            LoadBooks();
        }
        private void LoadBooks()
        {
            // Fetch books from the database and bind to the DataGridView
            dgvBooks.DataSource = BookRepository.GetBooks(txtSearch.Text);
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Add new book from the fields in the form
            var newBook = new Book
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Genre = txtGenre.Text,
                ISBN = txtISBN.Text,
                Price = decimal.Parse(txtPrice.Text),
                StockQuantity = int.Parse(txtQuantity.Text)
            };

            BookRepository.AddBook(newBook);
            MessageBox.Show("Book Added Successfully");
            LoadBooks(); // Reload the book list after adding

            if (BookRepository.BookCodeExists(txtISBN.Text))
            {
                MessageBox.Show("A book with this Book Code already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the selected book from the DataGridView
            var selectedBook = dgvBooks.SelectedRows[0].DataBoundItem as Book;
            if (selectedBook != null)
            {
                // Update the selected book
                selectedBook.Title = txtTitle.Text;
                selectedBook.Author = txtAuthor.Text;
                selectedBook.Genre = txtGenre.Text;
                selectedBook.ISBN = txtISBN.Text;
                selectedBook.Price = decimal.Parse(txtPrice.Text);
                selectedBook.StockQuantity = int.Parse(txtQuantity.Text);

                BookRepository.UpdateBook(selectedBook);
                MessageBox.Show("Book Updated Successfully");
                LoadBooks(); // Reload the book list after updating
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the selected book from the DataGridView
            var selectedBook = dgvBooks.SelectedRows[0].DataBoundItem as Book;
            if (selectedBook != null)
            {
                // Confirm delete
                var result = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Delete the book
                    BookRepository.DeleteBook(selectedBook.BookId);
                    MessageBox.Show("Book Deleted Successfully");
                    LoadBooks(); // Reload the book list after deletion
                }
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Reload books with the search filter
            LoadBooks();
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // When a row is clicked, populate the textboxes with the selected book's data
            if (e.RowIndex >= 0)
            {
                var selectedBook = dgvBooks.Rows[e.RowIndex].DataBoundItem as Book;
                if (selectedBook != null)
                {
                    txtTitle.Text = selectedBook.Title;
                    txtAuthor.Text = selectedBook.Author;
                    txtGenre.Text = selectedBook.Genre;
                    txtISBN.Text = selectedBook.ISBN;
                    txtPrice.Text = selectedBook.Price.ToString();
                    txtQuantity.Text = selectedBook.StockQuantity.ToString();
                }
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            LoadBooks(); // Refresh the book list whenever the search text changes
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            txtISBN.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtSearch.Clear();
            txtGenre.Clear();
        }

    }
}

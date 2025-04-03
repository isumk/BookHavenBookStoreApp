using System;
using System.Data;
using System.Windows.Forms;
using BookHavenStoreApp.DataAccess;
using BookHavenStoreApp.Models;

namespace BookHavenStoreApp.Forms
{
    public partial class BookInventoryForm : Form
    {
        private readonly BookRepository bookRepo = new BookRepository();//Create an Instance

        public BookInventoryForm()
        {
            InitializeComponent();
            LoadBooks(); // Load books on form load
            PopulateCategories(); // Load categories into ComboBox
        }

        private void LoadBooks()
        {
            dgvBooks.DataSource = bookRepo.GetAllBooks();
        }

        private void PopulateCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(new string[]
            {
                "Fiction", "Non-fiction", "Mystery", "Fantasy", "Sci-Fi",
                "Biography", "Romance", "Thriller", "History"
            });
        }


        

        private void ClearFields()
        {
            txtISBN.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            cmbCategory.SelectedIndex = -1;
            txtPrice.Clear();
            txtStock.Clear();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtISBN.Text) ||
                string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                cmbCategory.SelectedItem == null ||
                !decimal.TryParse(txtPrice.Text, out _) ||
                !int.TryParse(txtStock.Text, out _))
            {
                MessageBox.Show("Please fill in all fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                Book book = new Book
                {
                    ISBN = txtISBN.Text.Trim(),
                    Title = txtTitle.Text.Trim(),
                    Author = txtAuthor.Text.Trim(),
                    Genre = cmbCategory.SelectedItem?.ToString(),
                    Price = Convert.ToDecimal(txtPrice.Text),
                    StockQuantity = Convert.ToInt32(txtStock.Text)
                };

                bool success = bookRepo.AddBook(book);
                if (success)
                {
                    MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBooks();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Error adding book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBooks.Rows[e.RowIndex];

                txtISBN.Text = row.Cells["ISBN"].Value.ToString();
                txtTitle.Text = row.Cells["Title"].Value.ToString();
                txtAuthor.Text = row.Cells["Author"].Value.ToString();
                cmbCategory.SelectedItem = row.Cells["Genre"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtStock.Text = row.Cells["StockQuantity"].Value.ToString();
            }
        }

        private void BtnSearchBook_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please enter a title, author, or ISBN to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadBooks(); // Reload all books if search text is empty
                return;
            }

            dgvBooks.DataSource = bookRepo.SearchBooks(searchText);


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["BookId"].Value);
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool success = bookRepo.DeleteBook(bookId);
                if (success)
                {
                    MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBooks();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Error deleting book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
               
                MessageBox.Show("Please select a book to update from the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (ValidateInputs())
            {
                int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["BookId"].Value);

                Book book = new Book
                {
                    BookId = bookId,
                    ISBN = txtISBN.Text.Trim(),
                    Title = txtTitle.Text.Trim(),
                    Author = txtAuthor.Text.Trim(),
                    Genre = cmbCategory.SelectedItem?.ToString(),
                    Price = Convert.ToDecimal(txtPrice.Text),
                    StockQuantity = Convert.ToInt32(txtStock.Text)
                };

                bool success = bookRepo.UpdateBook(book);
                if (success)
                {
                    MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBooks();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Error updating book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            BtnSearchBook_Click(sender, e);
        }

        private void BookInventoryForm_Load(object sender, EventArgs e)
        {

        }

    }
}

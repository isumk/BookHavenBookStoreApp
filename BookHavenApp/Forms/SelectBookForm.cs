using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHavenStoreApp.Models;
using BookHavenStoreApp.Helpers;
using BookHavenStoreApp.DataAccess;

namespace BookHavenStoreApp.Forms
{
    public partial class SelectBookForm : Form
    {
        private BookRepository bookRepo = new BookRepository();
        private List<Book> books = new List<Book>();
        private Book selectedBook = null;
        public SelectBookForm()
        {
            InitializeComponent();
        }
        public OrderItem GetSelectedOrderItem()
        {
            return new OrderItem
            {
                BookID = selectedBook.BookId,
                BookTitle = selectedBook.Title,
                Price = selectedBook.Price,
                Quantity = int.Parse(txtQuantity.Text)
            };
        }

       

        // Form Load event, you can add any initialization logic here
        private void SelectBookForm_Load(object sender, EventArgs e)
        {
            books = bookRepo.GetAllBooks();
            dgvBooks.DataSource = books;

            dgvBooks.Columns["BookID"].Visible = false;
            dgvBooks.Columns["ISBN"].Visible = false;
            dgvBooks.Columns["StockQuantity"].Visible = true;

            dgvBooks.Columns["Title"].HeaderText = "Book Title";
            dgvBooks.Columns["Price"].DefaultCellStyle.Format = "C";
        }

        // TextBox for quantity clicked event
        private void txtQuantity_Click(object sender, EventArgs e)
        {
            // Logic for when the quantity TextBox is clicked (optional)
        }

        // DataGridView cell content click event (for selecting book)
        private void dgvBookList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedBook = books[e.RowIndex];
            }
        }

        // Add selected book and quantity to cart on button click
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (selectedBook == null)
            {
                MessageBox.Show("Please select a book.");
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Enter a valid quantity.");
                return;
            }

            if (qty > selectedBook.StockQuantity)
            {
                MessageBox.Show($"Only {selectedBook.StockQuantity} in stock.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

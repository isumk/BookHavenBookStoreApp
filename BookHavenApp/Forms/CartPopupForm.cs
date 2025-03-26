using BookHavenApp.Helpers;
using BookHavenApp.Models;
using BookHavenApp.Models.BookHavenApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BookHavenApp.DataAccess;

namespace BookHavenApp.Forms
{
    public partial class CartPopupForm : Form
    {
        // Repository to load books from the database
        private BookRepo bookRepo = new BookRepo();

        // List to store selected cart items
        public List<CartItem> CartItems { get; private set; } = new List<CartItem>();

        // Constructor — takes optional existing cart items so they can be modified
        public CartPopupForm(List<CartItem> existingCartItems = null)
        {
            InitializeComponent();

            // If there are existing items, load them into the cart
            if (existingCartItems != null)
            {
                CartItems = existingCartItems;
                UpdatePopupCartGrid();
            }

            // Load books into the selection grid
            LoadBooks();
        }

        // Load books from BookRepo and display in the dgvBookSelection DataGridView
        private void LoadBooks()
        {
            var books = bookRepo.GetAllBooks(); // Retrieve all books from database
            dgvBookSelection.DataSource = books;

            // Hide unnecessary columns if any
            dgvBookSelection.Columns["Stock"].Visible = false;

            // Format columns for better readability
            dgvBookSelection.Columns["BookId"].HeaderText = "ID";
            dgvBookSelection.Columns["Title"].HeaderText = "Book Title";
            dgvBookSelection.Columns["Price"].DefaultCellStyle.Format = "C2"; // Currency format
        }

        // Event handler when Add To Cart button is clicked
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            // Make sure a book is selected before adding
            if (dgvBookSelection.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book first.");
                return;
            }

            // Retrieve selected book details
            var row = dgvBookSelection.SelectedRows[0];
            int bookId = Convert.ToInt32(row.Cells["BookId"].Value);
            string title = row.Cells["Title"].Value.ToString();
            decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
            int quantity = (int)numQuantity.Value;

            // Validate that quantity is not zero or negative
            if (quantity <= 0)
            {
                MessageBox.Show("Please select a valid quantity.");
                return;
            }

            // Check if the item is already in the cart — if yes, just update quantity
            var existingItem = CartItems.FirstOrDefault(i => i.BookId == bookId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                // Add new cart item to the list
                CartItems.Add(new CartItem
                {
                    BookId = bookId,
                    Title = title,
                    Price = price,
                    Quantity = quantity
                });
            }

            // Update the cart items grid view to show the latest items
            UpdatePopupCartGrid();
        }

        // Updates the cart display DataGridView to reflect changes
        private void UpdatePopupCartGrid()
        {
            dgvCartPopup.DataSource = null;
            dgvCartPopup.DataSource = CartItems;

            // Update headers and formatting for the cart grid
            dgvCartPopup.Columns["BookId"].HeaderText = "ID";
            dgvCartPopup.Columns["BookTitle"].HeaderText = "Title";
            dgvCartPopup.Columns["Price"].HeaderText = "Price";
            dgvCartPopup.Columns["Price"].DefaultCellStyle.Format = "C2"; // Currency format
            dgvCartPopup.Columns["Quantity"].HeaderText = "Qty";
        }

        // Done button click event — closes popup and returns cart items to the parent form
       

        private void dgvBookSelection_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDone_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Return control with success result
            this.Close();
        }
    }
}

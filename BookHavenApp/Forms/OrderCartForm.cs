using BookHavenStoreApp.DataAccess;
using BookHavenStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BookHavenStoreApp.Forms
{
    public partial class OrderCartForm : Form
    {
        private List<OrderItem> cartItems;
        private BookRepository bookRepo;

        // Constructor that accepts an existing cart
        public OrderCartForm(List<OrderItem> existingCartItems)
        {
            InitializeComponent();
            cartItems = existingCartItems ?? new List<OrderItem>();
            bookRepo = new BookRepository();
            LoadBooks();
            LoadCartItems();
        }

        // ✅ Load Books into DataGridView
        private void LoadBooks()
        {
            dgvBookList.DataSource = bookRepo.GetAllBooks();
            dgvBookList.Columns["BookID"].Visible = false;  // Hide BookID
            dgvBookList.Columns["StockQuantity"].Visible = true;    // Show available stock
        }

        // ✅ Load Cart Items into DataGridView
        private void LoadCartItems()
        {
            dgvCartItems.DataSource = null;
            dgvCartItems.DataSource = cartItems;
            dgvCartItems.Columns["OrderItemID"].Visible = false;  // Hide OrderItemID
            dgvCartItems.Columns["Total"].Visible = true;         // Show total price
        }

        // ✅ Add Book to Cart
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvBookList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to add to the cart.");
                return;
            }

            int bookID = Convert.ToInt32(dgvBookList.SelectedRows[0].Cells["BookID"].Value);
            int stockAvailable = Convert.ToInt32(dgvBookList.SelectedRows[0].Cells["StockQuantity"].Value);

            // Validate quantity input
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            // Ensure quantity does not exceed stock
            if (quantity > stockAvailable)
            {
                MessageBox.Show("Not enough stock available.");
                return;
            }

            // Check if book is already in cart
            OrderItem existingItem = cartItems.FirstOrDefault(item => item.BookID == bookID);
            if (existingItem != null)
            {
                // Update quantity only (Total is auto-calculated)
                if (existingItem.Quantity + quantity > stockAvailable)
                {
                    MessageBox.Show("Cannot add more than available stock.");
                    return;
                }
                existingItem.Quantity += quantity;
            }
            else
            {
                // Add new book to cart
                Book selectedBook = bookRepo.GetBookByID(bookID);
                cartItems.Add(new OrderItem
                {
                    BookID = selectedBook.BookId,
                    BookTitle = selectedBook.Title,
                    Price = selectedBook.Price,
                    Quantity = quantity
                });
            }

            LoadCartItems();
            txtQuantity.Clear(); // Clear input field
        }

        // ✅ Remove Book from Cart
        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (dgvCartItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to remove from the cart.");
                return;
            }

            int selectedIndex = dgvCartItems.SelectedRows[0].Index;
            cartItems.RemoveAt(selectedIndex);
            LoadCartItems();
        }

        // ✅ Save and Close Form
        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        // ✅ Get Cart Items (to pass back to `OrderManagementForm`)
        public List<OrderItem> GetCartItems()
        {
            return cartItems;
        }
    }
}

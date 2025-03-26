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
    public partial class OrderManagementForm : Form
    {
        // Repositories to handle database operations for orders, customers, and books
        private readonly OrderRepo orderRepo = new OrderRepo();
        private readonly CustomerRepo customerRepo = new CustomerRepo();
        private readonly BookRepo bookRepo = new BookRepo();

        public OrderManagementForm()
        {
            InitializeComponent();
            LoadCustomers(); // Load customers in the ComboBox
            LoadOrders();    // Load existing orders in the DataGridView
        }

        // Load customers into the ComboBox for adding new orders
        private void LoadCustomers()
        {
            var customers = customerRepo.GetAllCustomers();
            cmbCustomer.DataSource = customers;
            cmbCustomer.DisplayMember = "Name";       // Show customer names
            cmbCustomer.ValueMember = "CustomerId";   // Store CustomerId as value
        }

        // Load all orders into the dgvOrders grid
        private void LoadOrders()
        {
            var orders = orderRepo.GetOrders();
            dgvOrders.DataSource = orders;

            // Rename column headers for clarity
            dgvOrders.Columns["OrderId"].HeaderText = "Order ID";
            dgvOrders.Columns["CustomerName"].HeaderText = "Customer";
            dgvOrders.Columns["OrderDate"].HeaderText = "Date";
            dgvOrders.Columns["TotalAmount"].HeaderText = "Total";
            dgvOrders.Columns["Status"].HeaderText = "Status";
        }

        // Event handler for adding a new order
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer.");
                return;
            }

            var customer = (Customer)cmbCustomer.SelectedItem;

            // Open the cart popup to select books for the order
            CartPopupForm cartPopup = new CartPopupForm();
            if (cartPopup.ShowDialog() == DialogResult.OK && cartPopup.CartItems.Any())
            {
                // Calculate total amount of the order
                decimal total = cartPopup.CartItems.Sum(i => i.Price * i.Quantity);

                // Create a new order object with items
                var order = new Order
                {
                    CustomerId = customer.CustomerId,
                    OrderDate = DateTime.Now,
                    TotalAmount = total,
                    Status = "Pending",
                    OrderItems = cartPopup.CartItems.Select(ci => new OrderItem
                    {
                        BookId = ci.BookId,
                        Quantity = ci.Quantity,
                        Price = ci.Price
                    }).ToList()
                };

                // Save order to the database
                orderRepo.AddOrder(order);

                MessageBox.Show("Order created successfully.");
                LoadOrders(); // Refresh order list after adding
            }
        }

        // When an order is selected, display its items in the order items grid
        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);
                var items = orderRepo.GetOrderItems(orderId);
                dgvOrderItems.DataSource = items;
            }
        }

        // Event handler for sending a selected order to the POS for checkout
        private void btnSendToPOS_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to send to POS.");
                return;
            }

            var orderRow = dgvOrders.SelectedRows[0];
            int orderId = Convert.ToInt32(orderRow.Cells["OrderId"].Value);
            string status = orderRow.Cells["Status"].Value.ToString();

            if (status != "Pending")
            {
                MessageBox.Show("Only pending orders can be sent to POS.");
                return;
            }

            // Convert order items to cart items to pass to the POS form
            var orderItems = orderRepo.GetOrderItems(orderId);
            var cartItems = orderItems.Select(oi => new CartItem
            {
                BookId = oi.BookId,
                Title = bookRepo.GetAllBooks().FirstOrDefault(b => b.BookId == oi.BookId)?.Title,
                Price = oi.Price,
                Quantity = oi.Quantity
            }).ToList();

            // Open the POS form with the cart items
            SalesPOSForm posForm = new SalesPOSForm(cartItems, orderId);
            posForm.ShowDialog();

            LoadOrders(); // Reload orders after processing checkout
        }

        // Event handler to cancel a selected pending order
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to cancel.");
                return;
            }

            int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderId"].Value);
            string status = dgvOrders.SelectedRows[0].Cells["Status"].Value.ToString();

            if (status != "Pending")
            {
                MessageBox.Show("Only pending orders can be cancelled.");
                return;
            }

            // Confirm cancellation
            var confirm = MessageBox.Show("Are you sure you want to cancel this order?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                orderRepo.UpdateOrderStatus(orderId, "Cancelled");
                MessageBox.Show("Order cancelled.");
                LoadOrders(); // Refresh orders after cancellation
            }
        }
    }
}

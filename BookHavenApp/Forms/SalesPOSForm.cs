using BookHavenApp.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BookHavenApp.DataAccess;
using System.Drawing.Printing;
using BookHavenApp.Helpers;
using BookHavenApp.Models.BookHavenApp.Models;


namespace BookHavenApp.Forms
{
    public partial class SalesPOSForm : Form
    {
        private readonly BookRepo bookRepo = new BookRepo();
        private readonly OrderRepo orderRepo = new OrderRepo();
        private readonly CustomerRepo customerRepo = new CustomerRepo();

        private List<CartItem> cartItems = new List<CartItem>();   // In-memory cart
        private int? loadedOrderId = null;                         // Store if order was loaded from Order Management

        public SalesPOSForm()
        {
            InitializeComponent();
            LoadCustomers();
        }

        // Overloaded constructor to accept cart items from Order Management
        public SalesPOSForm(List<CartItem> orderCartItems, int orderId)
        {
            InitializeComponent();
            LoadCustomers();
            loadedOrderId = orderId;
            cartItems = orderCartItems;
            RefreshCart();
        }

        // Load customers into the customer ComboBox
        private void LoadCustomers()
        {
            var customers = customerRepo.GetAllCustomers();
            cmbCustomer.DataSource = customers;
            cmbCustomer.DisplayMember = "Name";
            cmbCustomer.ValueMember = "CustomerId";
        }

        // Add books to cart by showing the CartPopupForm
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            CartPopupForm cartPopup = new CartPopupForm();
            if (cartPopup.ShowDialog() == DialogResult.OK && cartPopup.CartItems.Any())
            {
                // Merge popup items with existing cart
                foreach (var item in cartPopup.CartItems)
                {
                    var existingItem = cartItems.FirstOrDefault(i => i.BookId == item.BookId);
                    if (existingItem != null)
                        existingItem.Quantity += item.Quantity;
                    else
                        cartItems.Add(item);
                }
                RefreshCart();
            }
        }

        // Refresh DataGridView to show updated cart
        private void RefreshCart()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = cartItems;
            dgvCart.Columns["BookId"].Visible = false;
            CalculateTotal();
        }

        // Calculate the cart total including discount
        private void CalculateTotal()
        {
            decimal subtotal = cartItems.Sum(i => i.Price * i.Quantity);
            decimal discount = (subtotal * numDiscount.Value) / 100;
            decimal total = subtotal - discount;
            txtGrandTotal.Text = $"Total: {total:C}";
        }

        // Handle discount changes
        private void nudDiscount_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        // Remove selected item from cart
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                var selectedItem = (CartItem)dgvCart.SelectedRows[0].DataBoundItem;
                cartItems.Remove(selectedItem);
                RefreshCart();
            }
        }

        // Checkout process
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Cart is empty.");
                return;
            }

            if (cmbCustomer.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer.");
                return;
            }

            decimal subtotal = cartItems.Sum(i => i.Price * i.Quantity);
            decimal discountAmount = (subtotal * numDiscount.Value) / 100;
            decimal finalTotal = subtotal - discountAmount;
            var customer = (Customer)cmbCustomer.SelectedItem;

            // Save order as completed
            var order = new Order
            {
                CustomerId = customer.CustomerId,
                OrderDate = DateTime.Now,
                TotalAmount = finalTotal,
                Status = "Completed",
                OrderItems = cartItems.Select(ci => new OrderItem
                {
                    BookId = ci.BookId,
                    Quantity = ci.Quantity,
                    Price = ci.Price
                }).ToList()
            };

            // If this POS was loaded from an existing order (pending), update it instead of creating a new one
            if (loadedOrderId != null)
            {
                orderRepo.CompletePendingOrder(loadedOrderId.Value);
                orderRepo.UpdateOrderStatus(loadedOrderId.Value, "Completed");
            }
            else
            {
                orderRepo.AddOrder(order);
            }

            // Update book stock
            foreach (var item in cartItems)
            {
                bookRepo.ReduceStock(item.BookId, item.Quantity);
            }

            // Generate and display receipt
            GenerateAndShowReceipt(customer.Name, finalTotal, discountAmount);

            // Reset POS after checkout
            cartItems.Clear();
            RefreshCart();
            numDiscount.Value = 0; // Reset discount to zero
        }


        // Generate receipt and print preview
        private void GenerateAndShowReceipt(string customerName, decimal finalTotal, decimal discount)
        {
            StringBuilder receiptBuilder = new StringBuilder();
            receiptBuilder.AppendLine("===== BookHaven Store Receipt =====");
            receiptBuilder.AppendLine($"Date: {DateTime.Now}");
            receiptBuilder.AppendLine($"Customer: {customerName}");
            receiptBuilder.AppendLine("-----------------------------------");
            foreach (var item in cartItems)
            {
                receiptBuilder.AppendLine($"{item.Title} x{item.Quantity} @ {item.Price:C} = {(item.Price * item.Quantity):C}");
            }
            receiptBuilder.AppendLine("-----------------------------------");
            receiptBuilder.AppendLine($"Subtotal: {(cartItems.Sum(i => i.Price * i.Quantity)):C}");
            receiptBuilder.AppendLine($"Discount: {discount:C}");
            receiptBuilder.AppendLine($"Total: {finalTotal:C}");
            receiptBuilder.AppendLine("===================================");

            // Save as .txt
            File.WriteAllText("receipt.txt", receiptBuilder.ToString());

            // Show receipt in popup
            ReceiptPreviewForm receiptForm = new ReceiptPreviewForm(receiptBuilder.ToString());
            receiptForm.ShowDialog();

            // Optionally, trigger PDF export if needed (extension)
        }
    }
}

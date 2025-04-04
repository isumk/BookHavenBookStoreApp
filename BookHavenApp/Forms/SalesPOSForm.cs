using BookHavenStoreApp.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using BookHavenStoreApp.Helpers;
using BookHavenStoreApp.Models.BookHavenApp.Models;
using BookHavenStoreApp.DataAccess;


namespace BookHavenStoreApp.Forms
{
    public partial class SalesPOSForm : Form
    {
        private readonly List<OrderItem> cartItems = new List<OrderItem>();
        private readonly BookRepository bookRepo = new BookRepository();
        // Removed the instantiation of CustomerRepository since it is a static class
        public SalesPOSForm()
        {
            InitializeComponent();
        }
        private void SalesPOSForm_Load(object sender, EventArgs e)
        {
            cmbCustomers.DataSource = CustomerRepository.GetAllCustomers();
            cmbCustomers.DisplayMember = "CustomerName";
            cmbCustomers.ValueMember = "CustomerID";
            RefreshCartGrid();
        }

        private void btnSelectBook_Click(object sender, EventArgs e)
        {
            using (var popup = new SelectBookForm())
            {
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    var selectedItem = popup.GetSelectedOrderItem();
                    var existing = cartItems.FirstOrDefault(i => i.BookID == selectedItem.BookID);
                    if (existing != null)
                        existing.Quantity += selectedItem.Quantity;
                    else
                        cartItems.Add(selectedItem);

                    RefreshCartGrid();
                    UpdateTotals();
                }
            }

        }
        private void RefreshCartGrid()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = cartItems;
            dgvCart.Columns["OrderItemID"].Visible = false;
            dgvCart.Columns["OrderID"].Visible = false;
        }
        private void UpdateTotals()
        {
            decimal total = cartItems.Sum(item => item.Total);
            decimal discount = 0;

            decimal.TryParse(txtDiscount.Text, out discount);
            txtTotalAmount.Text = total.ToString("0.00");
            txtFinalAmount.Text = (total - discount).ToString("0.00");
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                int index = dgvCart.SelectedRows[0].Index;
                cartItems.RemoveAt(index);
                RefreshCartGrid();
                UpdateTotals();
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Cart is empty!");
                return;
            }

            var order = new Order
            {
                CustomerID = (int)cmbCustomers.SelectedValue,
                OrderDate = DateTime.Now,
                Status = "Completed",
                Discount = decimal.Parse(txtDiscount.Text),
                FinalAmount = decimal.Parse(txtFinalAmount.Text),
                OrderItems = cartItems // Ensure Items property is set
            };

            var repo = new OrderRepository();
            int orderId = repo.AddOrder(order, cartItems);
            MessageBox.Show($"Sale completed! Order ID: {orderId}");

            GenerateTemporaryReceipt(order); // Pass the order object instead of orderId
            cartItems.Clear();
            RefreshCartGrid();
            UpdateTotals();
               //Generate a recipt in Desktop
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Receipt_Order_{orderId}.pdf");
            ReceiptPdfHelper.GenerateReceipt(order, cartItems, path);
            MessageBox.Show("Receipt PDF generated at: " + path);

        }

        private void GenerateTemporaryReceipt(Order order)
        {
            string receipt = $"--- BookHaven Receipt ---\n";
            receipt += $"Order Date: {order.OrderDate}\n";
            receipt += $"Customer ID: {order.CustomerID}\n";
            receipt += $"--------------------------------\n";

            foreach (var item in order.OrderItems)
            {
                receipt += $"{item.BookTitle} x {item.Quantity} @ {item.Price:C} = {item.Quantity * item.Price:C}\n";
            }

            receipt += $"--------------------------------\n";
            receipt += $"Discount: {order.Discount:C}\n";
            receipt += $"Final Total: {order.FinalAmount:C}\n";
            receipt += $"Status: {order.Status}\n";
            receipt += $"--------------------------------\n";
            receipt += $"Thank you for shopping with BookHaven!";

            MessageBox.Show(receipt, "Temporary Receipt");
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}

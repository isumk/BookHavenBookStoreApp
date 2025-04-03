using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using BookHavenStoreApp.DataAccess;
using BookHavenStoreApp.Models;
using BookHavenStoreApp.Forms;
using System.Linq;

namespace BookHavenStoreApp.Forms
{
    public partial class OrderManagementForm : Form
    {
        private OrderRepository orderRepository;
        private BookRepository bookRepository;
        
        private List<OrderItem> cartItems;

        public OrderManagementForm()
        {
            InitializeComponent();
            orderRepository = new OrderRepository();
            bookRepository = new BookRepository();
            
            cartItems = new List<OrderItem>();

            LoadOrders();
            LoadCustomers();
            LoadOrderTypes();
        }

        // ✅ Load Orders into DataGridView  
        private void LoadOrders()
        {
            dgvOrders.DataSource = orderRepository.GetAllOrders();
        }

        // ✅ Load Customers into ComboBox  
        private void LoadCustomers()
        {
            var customers = CustomerRepository.GetAllCustomers();
            if (customers != null && customers.Count() > 0)
            {
                cmbCustomer.DataSource = customers;
                cmbCustomer.DisplayMember = "CustomerName";
                cmbCustomer.ValueMember = "CustomerID";
            }
            else
            {
                MessageBox.Show("No customers found! Please add customers first.");
            }
        }

        // ✅ Load Order Types  
        private void LoadOrderTypes()
        {
            cmbOrderType.Items.Clear();
            cmbOrderType.Items.Add("Pickup");
            cmbOrderType.Items.Add("Delivery");
            cmbOrderType.SelectedIndex = 0;
        }

        // ✅ Open Popup Cart to Add Books to Order  
        private void btnAddBooks_Click_1(object sender, EventArgs e)
        {
            OrderCartForm cartForm = new OrderCartForm(cartItems);
            if (cartForm.ShowDialog() == DialogResult.OK)
            {
                cartItems = cartForm.GetCartItems();
                UpdateFinalAmount();
            }
        }

        // ✅ Calculate Final Amount from Cart Items  
        private void UpdateFinalAmount()
        {
            decimal totalAmount = cartItems.Sum(item => item.Total);
            txtTotalAmount.Text = totalAmount.ToString("0.00");
        }

        // ✅ Create a New Order  
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Please add books to the order.");
                return;
            }

            // Validate stock before placing order
            foreach (var item in cartItems)
            {
                Book book = bookRepository.GetBookByID(item.BookID);
                if (book.StockQuantity < item.Quantity)
                {
                    MessageBox.Show($"Not enough stock for {book.Title}. Available: {book.StockQuantity}");
                    return;
                }
            }

            Order newOrder = new Order
            {
                CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue),
                FinalAmount = Convert.ToDecimal(txtTotalAmount.Text),
                OrderItems = cartItems
            };

            int orderID = orderRepository.AddOrder(newOrder);
            if (orderID > 0)
            {
                MessageBox.Show("Order added successfully!");
                cartItems.Clear();
                LoadOrders();
                txtTotalAmount.Text = "0.00";
            }
            else
            {
                MessageBox.Show("Failed to add order.");
            }
        }

        // ✅ Load Order Details When Selecting an Order  
        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int orderID = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);
                dgvOrderDetails.DataSource = orderRepository.GetOrderDetails(orderID);
            }
        }



        // ✅ Update an Existing Order  
        private void btnUpdateOrder_Click_1(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an order to update.");
                return;
            }

            int orderID = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);
            Order updatedOrder = new Order
            {
                OrderID = orderID,
                CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue),
                FinalAmount = Convert.ToDecimal(txtTotalAmount.Text),
                OrderItems = cartItems
            };

            bool success = orderRepository.UpdateOrder(updatedOrder);
            if (success)
            {
                MessageBox.Show("Order updated successfully!");
                LoadOrders();
            }
            else
            {
                MessageBox.Show("Failed to update order.");
            }
        }   

        // ✅ Delete an Order  
        private void btnDeleteOrder_Click_1(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an order to delete.");
                return;
            }

            int orderID = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);
            bool success = orderRepository.DeleteOrder(orderID);

            if (success)
            {
                MessageBox.Show("Order deleted successfully!");
                LoadOrders();
            }
            else
            {
                MessageBox.Show("Failed to delete order.");
            }
        }



        private void OrderManagementForm_Load(object sender, EventArgs e)
        {

        }

        // ✅ Send Order to POS 
        private void btnSendToPOS_Click_1(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an order to send to POS.");
                return;
            }

            int orderID = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);
            bool success = orderRepository.SendToPOS(orderID);

            if (success)
            {
                MessageBox.Show("Order sent to POS successfully!");
                LoadOrders();
            }
            else
            {
                MessageBox.Show("Failed to send order to POS.");
            }
        }


    }
}

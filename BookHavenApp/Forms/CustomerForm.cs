using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHavenApp.Models;


namespace BookHavenApp.Forms
{
   

    public partial class CustomerForm: Form
    {
        private CustomerRepository customerRepo = new CustomerRepository();
        private int selectedCustomerId = -1;
        public CustomerForm()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadCustomers()
        {
            dgvCustomers.DataSource = customerRepo.GetAllCustomers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Name and Phone are required.");
                return;
            }

            Customer customer = new Customer
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Contact = txtPhone.Text,
                Address = txtAddress.Text
            };

            customerRepo.AddCustomer(customer);
            LoadCustomers();
            ClearFields();
            MessageBox.Show("Customer added successfully!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Please select a customer to update.");
                return;
            }

            Customer customer = new Customer
            {
                CustomerId = selectedCustomerId,
                Name = txtName.Text,
                Email = txtEmail.Text,
                Contact = txtPhone.Text,
                Address = txtAddress.Text
            };

            customerRepo.UpdateCustomer(customer);
            LoadCustomers();
            ClearFields();
            MessageBox.Show("Customer updated successfully!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Please select a customer to delete.");
                return;
            }

            customerRepo.DeleteCustomer(selectedCustomerId);
            LoadCustomers();
            ClearFields();
            MessageBox.Show("Customer deleted successfully!");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            dgvCustomers.DataSource = customerRepo.SearchCustomers(keyword);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtSearch.Clear();
            selectedCustomerId = -1;
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                selectedCustomerId = Convert.ToInt32(row.Cells["CustomerId"].Value);
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["Contact"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
            }
        }
    }
}

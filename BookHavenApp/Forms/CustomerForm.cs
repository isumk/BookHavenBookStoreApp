using System;
using System.Windows.Forms;
using System.Xml.Linq;
using BookHavenStoreApp.DataAccess;
using BookHavenStoreApp.Models;
using BookHavenStoreApp.Forms;
using System.Collections.Generic;

namespace BookHavenStoreApp.Forms
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
            LoadCustomers();
        }
        private void CustomerManagementForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadCustomers()
        {
            dgvCustomers.DataSource = CustomerRepository.GetAllCustomers();
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text
            };

            bool success = CustomerRepository.AddCustomer(customer);
            if (success)
            {
                MessageBox.Show("Customer added successfully!");
                LoadCustomers();
            }
            else
            {
                MessageBox.Show("Error adding customer.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer.");
                return;
            }

            int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerId"].Value);
            Customer customer = new Customer
            {
                CustomerId = customerId,
                Name = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text
            };

            bool success = CustomerRepository.UpdateCustomer(customer);
            if (success)
            {
                MessageBox.Show("Customer updated successfully!");
                LoadCustomers();
            }
            else
            {
                MessageBox.Show("Error updating customer.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer.");
                return;
            }

            int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerId"].Value);
            bool success = CustomerRepository.DeleteCustomer(customerId);
            if (success)
            {
                MessageBox.Show("Customer deleted successfully!");
                LoadCustomers();
            }
            else
            {
                MessageBox.Show("Error deleting customer.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            dgvCustomers.DataSource = CustomerRepository.SearchCustomers(searchText);
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

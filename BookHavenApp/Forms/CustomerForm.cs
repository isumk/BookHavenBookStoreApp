using System;
using System.Windows.Forms;
using BookHavenStoreApp.DataAccess;
using BookHavenStoreApp.Models;
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

        private void LoadCustomers()
        {
            dgvCustomers.DataSource = CustomerRepository.GetAllCustomers();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

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
                ClearFields();
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

            if (!ValidateInputs())
                return;

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
                ClearFields();
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
                ClearFields();
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

        // Real-time search while typing in the search box
        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                // Reload the full list when the search field is cleared
                LoadCustomers();
            }
            else
            {
                dgvCustomers.DataSource = CustomerRepository.SearchCustomers(searchText);
            }
        }

        // CellClick event handler to populate the text boxes with the selected row's data
        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure a row was clicked
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                // Populate textboxes with the values from the selected row
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }
    }
}

using BookHavenApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHavenApp.Forms
{
    public partial class SupplierForm: Form
    {
        private SupplierRepository supplierRepo = new SupplierRepository();
        private int selectedSupplierId = -1;

        public SupplierForm()
        {
            InitializeComponent();
            LoadSuppliers();
        }
        private void LoadSuppliers()
        {
            dgvSuppliers.DataSource = supplierRepo.GetAllSuppliers();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Name and Phone are required.");
                return;
            }

            Supplier supplier = new Supplier
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text
            };

            supplierRepo.AddSupplier(supplier);
            LoadSuppliers();
            ClearFields();
            MessageBox.Show("Supplier added successfully!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedSupplierId == -1)
            {
                MessageBox.Show("Please select a supplier to update.");
                return;
            }

            Supplier supplier = new Supplier
            {
                SupplierId = selectedSupplierId,
                Name = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text
            };

            supplierRepo.UpdateSupplier(supplier);
            LoadSuppliers();
            ClearFields();
            MessageBox.Show("Supplier updated successfully!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedSupplierId == -1)
            {
                MessageBox.Show("Please select a supplier to delete.");
                return;
            }

            supplierRepo.DeleteSupplier(selectedSupplierId);
            LoadSuppliers();
            ClearFields();
            MessageBox.Show("Supplier deleted successfully!");
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
            selectedSupplierId = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            dgvSuppliers.DataSource = supplierRepo.SearchSuppliers(keyword);
        }

        private void dgvSuppliers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSuppliers.Rows[e.RowIndex];
                selectedSupplierId = Convert.ToInt32(row.Cells["SupplierId"].Value);
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
            }
        }
    }
}

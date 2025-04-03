using BookHavenStoreApp.DataAccess;
using BookHavenStoreApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHavenStoreApp.Forms
{
    public partial class SupplierForm : Form
    {
        private readonly SupplierRepository supplierRepo = new SupplierRepository();

        public SupplierForm()
        {
            InitializeComponent();
            LoadSuppliers();
            LoadOrders();
            LoadBooks();
        }

        private void LoadSuppliers()
        {
            DataTable suppliers = supplierRepo.GetAllSuppliers();
            dgvSuppliers.DataSource = suppliers;
            cmbSupplier.DataSource = suppliers;
            cmbSupplier.DisplayMember = "Name";
            cmbSupplier.ValueMember = "SupplierID";
        }
        private void LoadBooks()
        {
            BookRepository bookRepo = new BookRepository();
            List<BookHavenStoreApp.Models.Book> books = bookRepo.GetAllBooks();
            cmbBook.DataSource = books;
            cmbBook.DisplayMember = "Title";
            cmbBook.ValueMember = "BookID";
        }

        private void LoadOrders()
        {
            dgvOrders.DataSource = supplierRepo.GetSupplierOrders();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier
            {
                Name = txtSupplierName.Text,
                Phone = txtContact.Text,
                Email = txtEmail.Text,
                Address = txtAddress.Text
            };

            if (supplierRepo.AddSupplier(supplier))
            {
                MessageBox.Show("Supplier added successfully!");
                LoadSuppliers();
            }
            else
            {
                MessageBox.Show("Error adding supplier.");
            }
        }

        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier
            {
                SupplierID = Convert.ToInt32(dgvSuppliers.SelectedRows[0].Cells["SupplierID"].Value),
                Name = txtSupplierName.Text,
                Phone = txtContact.Text,
                Email = txtEmail.Text,
                Address = txtAddress.Text
            };

            if (supplierRepo.UpdateSupplier(supplier))
            {
                MessageBox.Show("Supplier updated successfully!");
                LoadSuppliers();
            }
            else
            {
                MessageBox.Show("Error updating supplier.");
            }
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            int supplierId = Convert.ToInt32(dgvSuppliers.SelectedRows[0].Cells["SupplierID"].Value);
            if (supplierRepo.DeleteSupplier(supplierId))
            {
                MessageBox.Show("Supplier deleted successfully!");
                LoadSuppliers();
            }
            else
            {
                MessageBox.Show("Error deleting supplier.");
            }
        }

        private void btnMarkAsReceived_Click(object sender, EventArgs e)
        {
            int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);
            int bookId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["BookID"].Value);
            int quantity = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Quantity"].Value);

            if (supplierRepo.MarkOrderAsReceived(orderId, bookId, quantity))
            {
                MessageBox.Show("Stock updated successfully!");
                LoadOrders();
            }
            else
            {
                MessageBox.Show("Error updating stock.");
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (cmbSupplier.SelectedItem == null || cmbBook.SelectedItem == null || string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Please select a supplier, book, and enter quantity.");
                return;
            }

            int supplierId = Convert.ToInt32(cmbSupplier.SelectedValue);
            int bookId = Convert.ToInt32(cmbBook.SelectedValue);
            int quantity;

            if (!int.TryParse(txtQuantity.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            bool success = supplierRepo.PlaceSupplierOrder(supplierId, bookId, quantity);
            if (success)
            {
                MessageBox.Show("Order placed successfully!");
                LoadOrders();
            }
            else
            {
                MessageBox.Show("Error placing order.");
            }
        }
    }
}

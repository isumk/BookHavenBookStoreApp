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
    public partial class SelectCustomerForm: Form
    {
        private CustomerRepo customerRepo = new CustomerRepo();
        public Customer SelectedCustomer { get; private set; }
        public SelectCustomerForm()
        {
            InitializeComponent();
            LoadCustomers();
        }
        private void LoadCustomers()
        {
            dgvCustomers.DataSource = customerRepo.GetAllCustomers();
        }
        private void SelectCustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedCustomer = (Customer)dgvCustomers.Rows[e.RowIndex].DataBoundItem;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                SelectedCustomer = (Customer)dgvCustomers.SelectedRows[0].DataBoundItem;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}

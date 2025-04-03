using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHavenStoreApp.Helpers;
using BookHavenStoreApp;
using BookHavenStoreApp.Forms;
using BookHavenStoreApp.Models;
using BookHavenStoreApp.Models.BookHavenApp.Models;

namespace BookHavenStoreApp.Forms
{
    public partial class MainForm: Form
    {
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private string userRole; // Store the logged-in user's role

        public MainForm(User user)
        {
            InitializeComponent();
            userRole = user.Role; // Get role from User object
            lblUserRole.Text = "Role: " + userRole;
            ApplyRoleBasedAccess(); // Apply restrictions based on role
        }

        private void OpenChildForm(Form childForm)
        {
            panelContainer.Controls.Clear();//Clears the Panel
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            childForm.FormBorderStyle = FormBorderStyle.None;
            panelContainer.Controls.Add(childForm);
            childForm.Show();//Shows selected Form inside Pnael
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BookInventoryForm());
        }

        private void btncustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CustomerForm());
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SalesPOSForm());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new OrderManagement());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }
        private void ApplyRoleBasedAccess()
        {
            lblUserRole.Text = $"Role: {userRole}"; // Display role directly
            if (userRole == "Staff")
            {
                btnSuppliers.Visible = false;
                btnReports.Visible = false;
                btnDashboard.Visible = false;
            }
            else if (userRole == "Admin")
            {
                // Admin has full access
            }
            else
            {
                MessageBox.Show("Unauthorized Access", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SupplierForm());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReportsForm());
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

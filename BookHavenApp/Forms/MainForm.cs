using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHavenApp;
using BookHavenApp.Forms;
using BookHavenApp.Models;
using BookHavenApp.DataAccess;
using BookHavenApp.Models.BookHavenApp.Models;

namespace BookHavenApp.Forms
{
    public partial class MainForm: Form
    {
        private string currentUserRole;
     
        public MainForm(string userRole )
        {
            InitializeComponent();
            currentUserRole = userRole;
            CustomizeSidebar();
           

        }
        private void CustomizeSidebar()
        {
            lblUserRole.Text = $"Role: {currentUserRole}";
            if (currentUserRole == "Staff")
            {
                btnSuppliers.Visible = false;
                btnReports.Visible = false;
                btnDashboard.Visible = false;
            }
        }
        
        private void LoadForm(Form childForm)
        {
            panelContainer.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(childForm);
            childForm.Show();
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadForm(new AdminDashboardForm());
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            LoadForm(new BookInventoryForm());
        }

        private void btncustomers_Click(object sender, EventArgs e)
        {
            LoadForm(new CustomerForm());
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            LoadForm(new SalesPOSForm());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            LoadForm(new OrderManagementForm());
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            LoadForm(new SupplierForm());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            LoadForm(new ReportsForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadFormInPanel(Form form)
        {
            panelContainer.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(form);
            form.Show();
        }
    }
}

using BookHavenApp.DataAccess;
using BookHavenApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHavenApp.Forms;
using BookHavenApp.Helpers;
using System.Configuration;

namespace BookHavenApp.Forms
{
    public partial class LoginForm: Form
    {
        public LoginForm()
        {
            InitializeComponent();
            lblError.Visible = false;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Please enter both username and password.";
                lblError.Visible = true;
                return;
            }

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT UserId, Username, PasswordHash, Role FROM Users WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string storedHash = reader["PasswordHash"].ToString();
                            if (SecurityHelper.VerifyPassword(password, storedHash))
                            {
                                // Login successful
                                User loggedInUser = new User
                                {
                                    UserId = Convert.ToInt32(reader["UserId"]),
                                    Username = reader["Username"].ToString(),
                                    Role = reader["Role"].ToString()
                                };

                                // Open MainForm with user info
                                this.Hide();
                                MainForm mainForm = new MainForm(loggedInUser.Role);
                                mainForm.Show();
                            }
                            else
                            {
                                lblError.Text = "Incorrect password.";
                                lblError.Visible = true;
                            }
                        }
                        else
                        {
                            lblError.Text = "User not found.";
                            lblError.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = $"Login error: {ex.Message}";
                lblError.Visible = true;
            }
        }
    }
}
 

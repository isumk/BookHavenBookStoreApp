
using BookHavenStoreApp.Models;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BookHavenStoreApp.Forms;
using BookHavenStoreApp.Helpers;
using BookHavenStoreApp.Helpers;
using BookHavenStoreApp.Models;
using BookHavenStoreApp.DataAccess;


namespace BookHavenStoreApp.Forms
{
    public partial class LoginForm: Form
    {
        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        public LoginForm()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Incorrect password.");
                return;
            }

            try
            {
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT UserId, Username, Password, Role FROM Users WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string storedHash = reader["Password"].ToString();
                            if (SecurityHelper.VerifyPassword(password, storedHash))
                            {
                                // Login successful
                                User loggedInUser = new User
                                {
                                    UserId = Convert.ToInt32(reader["UserId"]),
                                    Username = reader["Username"].ToString(),
                                    Role = reader["Role"].ToString() // Store the role here
                                };

                                // Open MainForm with the User object
                                this.Hide();
                                MainForm mainForm = new MainForm(loggedInUser); // Pass User object instead of string
                                mainForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect password.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("User not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}");
            }
        }
    }
}
    
    

 

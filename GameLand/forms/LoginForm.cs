using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using GameLand.forms;

namespace GameLand
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            string ic = textBoxIC.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            string connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT Name FROM Users WHERE ICNumber = @IC AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IC", ic);
                cmd.Parameters.AddWithValue("@Password", password);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    string name = result.ToString();
                    MessageBox.Show("Login successful!");

                    this.Hide(); // Optional: hide login form
                    UserDashboardForm form = new UserDashboardForm(name, ic); // Pass name and IC
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Invalid IC or Password.");
                }
            }
        }


        private void title_Click(object sender, EventArgs e)
        {

        }
    }
}

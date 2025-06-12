using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

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
                string query = "SELECT COUNT(*) FROM Users WHERE ICNumber = @IC AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IC", ic);
                cmd.Parameters.AddWithValue("@Password", password);

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Login successful!");
                }
                else
                {
                    MessageBox.Show("Invalid IC or Password.");
                }
            }
        }
    }
}

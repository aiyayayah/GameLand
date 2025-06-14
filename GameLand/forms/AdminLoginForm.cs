using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using GameLand.forms;

namespace GameLand
{
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
        }

        private void textBoxStaffID_TextChanged(object sender, EventArgs e)
        {
            // Optional: you can handle validations here
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            // Optional: you can handle validations here
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string staffID = textBoxStaffID.Text.Trim();
            string password = textBoxPassword.Text;

            if (string.IsNullOrWhiteSpace(staffID) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both Staff ID and Password.");
                return;
            }
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GameLand;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); 

                    string query = "SELECT COUNT(*) FROM Admins WHERE StaffID = @StaffID AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StaffID", staffID);
                        cmd.Parameters.AddWithValue("@Password", password);

                        int result = (int)cmd.ExecuteScalar();

                        if (result > 0)
                        {
                            MessageBox.Show("Login successful! Welcome Admin.");

                            AdminUserListForm form = new AdminUserListForm();
                            form.Show();
                            this.Hide(); // optional: hide the login form
                        }
                        else
                        {
                            MessageBox.Show("Invalid Staff ID or Password.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:\n" + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

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

            try
            {
                // Use the correct endpoint name from App.config
                GameLandWebServiceRef.GameServiceSoapClient client = new GameLandWebServiceRef.GameServiceSoapClient("GameServiceSoap");

                string result = client.AdminLogin(staffID, password);

                if (result == "Success")
                {
                    MessageBox.Show("Login successful! Welcome Admin.");
                    AdminUserListForm form = new AdminUserListForm();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Staff ID or Password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Service error:\n" + ex.Message);
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

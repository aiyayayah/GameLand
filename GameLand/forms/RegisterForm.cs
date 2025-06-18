using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using GameLand.Services;

namespace GameLand
{
    public partial class labelLogin : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;

        public labelLogin()
        {
            InitializeComponent();
        }


        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string ic = textBoxIC.Text;
            string password = textBoxPassword.Text;
            string confirm = textBoxConfirm.Text;

            if (name == "" || ic == "" || password == "" || confirm == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Call web service
            try
            {
                GameLandWebServiceRef.GameServiceSoapClient client = new GameLandWebServiceRef.GameServiceSoapClient("GameServiceSoap");

                string result = client.RegisterUser(name, ic, password);

                MessageBox.Show(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM Users WHERE ICNumber = @ICNumber AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ICNumber", textBoxIC.Text);
                cmd.Parameters.AddWithValue("@Password", textBoxPassword.Text);

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Login successful!");
                   
                }
                else
                {
                    MessageBox.Show("Invalid credentials.");
                }
            }
        }

        private void txtIC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide(); // optional: hides the registration form
        }

        private void labelConfirm_Click(object sender, EventArgs e)
        {

        }

        private void title_Click(object sender, EventArgs e)
        {

        }
    }
}

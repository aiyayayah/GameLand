using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using GameLand.Services;
using GameLand.forms;

namespace GameLand
{
    public partial class RegisterForm : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string ic = textBoxIC.Text;
            string password = textBoxPassword.Text;
            string confirm = textBoxConfirm.Text;
            string email = textBoxEmail.Text;
            string phone = textBoxPhone.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ic) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirm) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            try
            {
                GameLandWebServiceRef.GameServiceSoapClient client = new GameLandWebServiceRef.GameServiceSoapClient("GameServiceSoap");
                string hashedPassword = HashPassword(password);
                string result = client.RegisterUser(name, ic, hashedPassword, email, phone);


                if (result.Contains("Registration successful"))
                {
                    MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string ic = textBoxIC.Text;
            string password = textBoxPassword.Text;

            try
            {
                var client = new GameLandWebServiceRef.GameServiceSoapClient("GameServiceSoap");
                string hashedPassword = HashPassword(password); // hash before sending
                string result = client.LoginUser(ic, hashedPassword);

                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UserDashboardForm dashboard = new UserDashboardForm(result, ic);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid IC or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message);
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

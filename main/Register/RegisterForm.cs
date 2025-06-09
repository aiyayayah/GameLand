using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Cryptography;


namespace Register
{
    public partial class RegisterForm: Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //register button
        private void button1_Click(object sender, EventArgs e)
        {
            string icNumber = textBox1.Text.Trim();
            string password = textBox2.Text;

            if (string.IsNullOrEmpty(icNumber))
            {
                MessageBox.Show("IC Number cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedPassword = HashPassword(password);

            MessageBox.Show($"Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Launch LoginForm and pass the IC and hashed password
            LoginForm loginForm = new LoginForm(icNumber, hashedPassword);
            loginForm.Show();
            this.Hide();
        }


        //ic number 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //password
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Convert to hex string
                }
                return builder.ToString();
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}

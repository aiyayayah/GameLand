using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Register
{
    public partial class LoginForm : Form
    {
        // For demo only: Simulated user database
        private string registeredIC = "123456789012"; // Replace with actual stored IC
        private string registeredHashedPassword;      // Replace with stored hash

        public LoginForm(string ic, string hashedPassword)
        {
            InitializeComponent();
            registeredIC = ic;
            registeredHashedPassword = hashedPassword;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string enteredIC = textBox1.Text.Trim();
            string enteredPassword = textBox2.Text;

            if (enteredIC == registeredIC && HashPassword(enteredPassword) == registeredHashedPassword)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Proceed to next form or dashboard
            }
            else
            {
                MessageBox.Show("Invalid IC or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string ic = textBox1.Text.Trim();
            string password = textBox2.Text;
            string hashedPassword = HashPassword(password);

            using HttpClient client = new HttpClient();

            var loginData = new { IcNumber = ic, HashedPassword = hashedPassword };

            var response = await client.PostAsJsonAsync("http://localhost:5204/users/login", loginData);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // proceed...
            }
            else
            {
                MessageBox.Show("Invalid IC or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task LoginUserAsync(string ic, string hashedPassword)
        {
            using HttpClient client = new HttpClient();

            var loginRequest = new User { IcNumber = ic, HashedPassword = hashedPassword };
            var response = await client.PostAsJsonAsync("http://localhost:5204/users/login", loginRequest);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Navigate to dashboard or next form here
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Login failed: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HashPassword(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        private class User
        {
            public string IcNumber { get; set; }
            public string HashedPassword { get; set; }
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }
    }
}

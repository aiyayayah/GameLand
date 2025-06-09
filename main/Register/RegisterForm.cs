using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string ic = textBox1.Text.Trim();
            string password = textBox2.Text;
            string hashedPassword = HashPassword(password);

            await RegisterUserAsync(ic, hashedPassword);
        }

        private async Task RegisterUserAsync(string ic, string hashedPassword)
        {
            using HttpClient client = new HttpClient();

            var user = new User { IcNumber = ic, HashedPassword = hashedPassword };
            var response = await client.PostAsJsonAsync("http://localhost:5204/users/register", user);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Registration successful via API!");
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Registration failed: {error}");
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

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Register
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            string ic = textBoxIc.Text.Trim();
            string password = textBoxPassword.Text;
            string hashedPassword = HashPassword(password);

            await RegisterUserAsync(ic, hashedPassword);
        }

        private async Task RegisterUserAsync(string ic, string hashedPassword)
        {
            using HttpClient client = new HttpClient();

            var user = new User { IcNumber = ic, HashedPassword = hashedPassword };

            var response = await client.PostAsJsonAsync("https://localhost:5001/users/register", user);

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

        // Local class (same as API model)
        private class User
        {
            public string IcNumber { get; set; }
            public string HashedPassword { get; set; }
        }
    }
}

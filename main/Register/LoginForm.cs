using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Security.Cryptography;
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

            bool loginSuccess = await LoginUserAsync(ic, hashedPassword);

            if (loginSuccess)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Proceed to dashboard or next form
            }
            else
            {
                MessageBox.Show("Invalid IC or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> LoginUserAsync(string ic, string hashedPassword)
        {
            using HttpClient client = new HttpClient();

            var user = new User { IcNumber = ic, HashedPassword = hashedPassword };

            try
            {
                var response = await client.PostAsJsonAsync("http://localhost:5204/users/login", user);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Login failed: " + error);
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Could not connect to the API. Make sure it's running.\n\n" + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
    }
}

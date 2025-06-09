using System;
using System.Windows.Forms;

namespace Register
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void userRegisterButton(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(); 
            registerForm.Show();
            this.Hide();
        }

        private void userLoginButton(object sender, EventArgs e)
        {
            string dummyIC = "123456789012";
            string dummyHashedPassword = "e3afed0047b08059d0fada10f400c1e5"; // Sample hash

            LoginForm loginForm = new LoginForm(dummyIC, dummyHashedPassword);
            loginForm.Show();
            this.Hide();
        }

        private void adminLoginButton(object sender, EventArgs e)
        {
            AdminLoginForm adminLogin = new AdminLoginForm();
            adminLogin.Show();
            this.Hide();
        }
    }
}

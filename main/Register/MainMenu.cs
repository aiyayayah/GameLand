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
            LoginForm loginForm = new LoginForm(); // No parameters
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

using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using GameLand.forms;
using GameLand.GameLandWebServiceRef; // Namespace for service reference

namespace GameLand
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            string ic = textBoxIC.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            try
            {
                GameLandWebServiceRef.GameServiceSoapClient client = new GameLandWebServiceRef.GameServiceSoapClient();

                string name = client.LoginUser(ic, password);

                if (!string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Login successful!");
                    this.Hide();
                    UserDashboardForm form = new UserDashboardForm(name, ic);
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Invalid IC or Password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed due to a service error:\n" + ex.Message);
            }
        }


        private void title_Click(object sender, EventArgs e)
        {

        }
    }
}

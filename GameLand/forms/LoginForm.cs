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



        private void title_Click(object sender, EventArgs e)
        {

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string ic = textBoxIC.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            try
            {
                GameLandWebServiceRef.GameServiceSoapClient client = new GameLandWebServiceRef.GameServiceSoapClient("GameServiceSoap");

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
    }
}

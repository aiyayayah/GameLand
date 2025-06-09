using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register
{
    public partial class AdminLoginForm: Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Simple hardcoded credentials (replace with secure storage)
            if (username == "admin" && password == "admin123")
            {
                MessageBox.Show("Welcome, Admin!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Open admin dashboard here
            }
            else
            {
                MessageBox.Show("Invalid admin credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

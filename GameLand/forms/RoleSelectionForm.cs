using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLand
{
    public partial class RoleSelectionForm: Form
    {
        public RoleSelectionForm()
        {
            InitializeComponent();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            RegisterForm userForm = new RegisterForm();
            userForm.Show();
            this.Hide(); // hide current form
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminLoginForm adminForm = new AdminLoginForm();
            adminForm.Show();
            this.Hide(); // hide current form
        }

        private void title_Click(object sender, EventArgs e)
        {

        }
    }
}

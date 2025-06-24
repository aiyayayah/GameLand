using GameLand.GameLandWebServiceRef;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GameLand.forms
{
    public partial class EditUserInfo : Form
    {
        private readonly string originalIC;

        public EditUserInfo(string name, string ic, string email, string phone)
        {
            InitializeComponent();
            originalIC = ic;

            textBoxName.Text = name;
            textBoxIC.Text = ic;
            textBoxEmail.Text = email;
            textBoxPhone.Text = phone;

            textBoxIC.ReadOnly = true;
        }

        private void EditUserInfo_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string phone = textBoxPhone.Text.Trim();

            try
            {
                var client = new GameServiceSoapClient("GameServiceSoap");

                bool success = client.UpdateUserInfo(originalIC, name, email, phone);

                if (success)
                {
                    MessageBox.Show("User info updated successfully.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update failed. No changes were made.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

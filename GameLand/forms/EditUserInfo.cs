using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLand.forms
{
    public partial class EditUserInfo: Form
    {
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string phone = textBoxPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string updateQuery = @"
                    UPDATE Users
                    SET Name = @Name, Email = @Email, Phone = @Phone
                    WHERE ICNumber = @IC";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@IC", originalIC);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User info updated successfully.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Update failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }

}
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GameLand.forms
{
    public partial class UserDashboardForm: Form
    {
        private string connectionString;
        private string userName;
        private string userIC;
        public UserDashboardForm(string name, string ic)
        {
            InitializeComponent();
            userName = name;
            userIC = ic;
            connectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
        }

        private void LoadAvailableItems()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ItemID, Name, IsAvailable FROM Items";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvItems.DataSource = table;
            }
        }
        private void LoadUserBorrowedItems()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT br.RecordID, i.Name, br.BorrowDate
            FROM BorrowRecords br
            JOIN Items i ON br.ItemID = i.ItemID
            WHERE br.UserIC = @ic AND br.ReturnDate IS NULL";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ic", userIC);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvItems.DataSource = table;
            }
        }
        private void UserDashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {userName}!";
            LoadAvailableItems(); // or LoadUserBorrowedItems()
        }

        private void btnBorrow_Click_1(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count == 0) return;

            int itemId = Convert.ToInt32(dgvItems.SelectedRows[0].Cells["ItemID"].Value);
            bool isAvailable = Convert.ToBoolean(dgvItems.SelectedRows[0].Cells["IsAvailable"].Value);

            if (!isAvailable)
            {
                MessageBox.Show("Item is not available.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand borrowCmd = new SqlCommand("INSERT INTO BorrowRecords (UserIC, ItemID) VALUES (@ic, @itemId)", conn);
                borrowCmd.Parameters.AddWithValue("@ic", userIC);
                borrowCmd.Parameters.AddWithValue("@itemId", itemId);
                borrowCmd.ExecuteNonQuery();

                SqlCommand updateItemCmd = new SqlCommand("UPDATE Items SET IsAvailable = 0 WHERE ItemID = @itemId", conn);
                updateItemCmd.Parameters.AddWithValue("@itemId", itemId);
                updateItemCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Item borrowed successfully!");
            LoadAvailableItems();
        }

        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count == 0) return;

            int recordId = Convert.ToInt32(dgvItems.SelectedRows[0].Cells["RecordID"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand getItemIdCmd = new SqlCommand("SELECT ItemID FROM BorrowRecords WHERE RecordID = @id", conn);
                getItemIdCmd.Parameters.AddWithValue("@id", recordId);
                int itemId = Convert.ToInt32(getItemIdCmd.ExecuteScalar());

                SqlCommand returnCmd = new SqlCommand("UPDATE BorrowRecords SET ReturnDate = GETDATE() WHERE RecordID = @id", conn);
                returnCmd.Parameters.AddWithValue("@id", recordId);
                returnCmd.ExecuteNonQuery();

                SqlCommand updateItemCmd = new SqlCommand("UPDATE Items SET IsAvailable = 1 WHERE ItemID = @itemId", conn);
                updateItemCmd.Parameters.AddWithValue("@itemId", itemId);
                updateItemCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Item returned successfully!");
            LoadUserBorrowedItems();
        }
    }
}

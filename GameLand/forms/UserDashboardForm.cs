using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GameLand.forms
{
    public partial class UserDashboardForm : Form
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
                string query = @"
            SELECT 
                gc.ItemID, 
                gc.ItemName, 
                gc.ItemPlatform, 
                gc.ItemStatus, 
                gc.ItemCharges,
                RIGHT(gc.UserIC, 4) AS UserIC_Last4
            FROM GameCards gc";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvAvailableItems.DataSource = table;

                // Optional: Set custom headers
                dgvAvailableItems.Columns["ItemID"].HeaderText = "ID";
                dgvAvailableItems.Columns["ItemName"].HeaderText = "Game Name";
                dgvAvailableItems.Columns["ItemPlatform"].HeaderText = "Platform";
                dgvAvailableItems.Columns["ItemStatus"].HeaderText = "Status";
                dgvAvailableItems.Columns["ItemCharges"].HeaderText = "Charges (RM)";
                dgvAvailableItems.Columns["UserIC_Last4"].HeaderText = "User IC (Last 4)";
            }
        }




        private void LoadUserBorrowedItems()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT br.RecordID, gc.ItemID, gc.ItemName, br.BorrowDate
            FROM BorrowRecords br
            JOIN GameCards gc ON br.ItemID = gc.ItemID
            WHERE br.UserIC = @ic AND br.ReturnDate IS NULL";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ic", userIC);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvBorrowedItems.DataSource = table;
            }
        }


private void UserDashboardForm_Load(object sender, EventArgs e)
{
    lblWelcome.Text = $"Welcome, {userName}!";
    LoadAvailableItems();
    LoadUserBorrowedItems();
}

        private void btnBorrow_Click_1(object sender, EventArgs e)
        {
            if (dgvAvailableItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to borrow.");
                return;
            }

            string itemId = dgvAvailableItems.SelectedRows[0].Cells["ItemID"].Value.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand borrowCmd = new SqlCommand(
                    "INSERT INTO BorrowRecords (UserIC, ItemID, BorrowDate) VALUES (@ic, @itemId, GETDATE())", conn);
                borrowCmd.Parameters.AddWithValue("@ic", userIC);
                borrowCmd.Parameters.AddWithValue("@itemId", itemId);
                borrowCmd.ExecuteNonQuery();

                SqlCommand updateCmd = new SqlCommand(
                    "UPDATE GameCards SET ItemStatus = 'Not Available', UserIC = @ic WHERE ItemID = @itemId", conn);
                updateCmd.Parameters.AddWithValue("@itemId", itemId);
                updateCmd.Parameters.AddWithValue("@ic", userIC);
                updateCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Item borrowed successfully!");
            LoadAvailableItems();
            LoadUserBorrowedItems();
        }

        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            if (dgvBorrowedItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to return.");
                return;
            }

            int recordId = Convert.ToInt32(dgvBorrowedItems.SelectedRows[0].Cells["RecordID"].Value);
            string itemId = dgvBorrowedItems.SelectedRows[0].Cells["ItemID"].Value.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand returnCmd = new SqlCommand(
                    "UPDATE BorrowRecords SET ReturnDate = GETDATE() WHERE RecordID = @id", conn);
                returnCmd.Parameters.AddWithValue("@id", recordId);
                returnCmd.ExecuteNonQuery();

                SqlCommand updateItemCmd = new SqlCommand(
                    "UPDATE GameCards SET ItemStatus = 'Available', UserIC = NULL WHERE ItemID = @itemId", conn);
                updateItemCmd.Parameters.AddWithValue("@itemId", itemId);
                updateItemCmd.ExecuteNonQuery();
            }

            MessageBox.Show("Item returned successfully!");
            LoadAvailableItems();
            LoadUserBorrowedItems();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
            // Optional label click event handler
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: handle clicks inside DataGridView
        }

        private void dgvBorrowedItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

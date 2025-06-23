using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using GameLand.GameLandWebServiceRef;
using GameLand.Services;

namespace GameLand.forms
{

    public partial class AdminUserListForm : Form
    {

        private GameCardService _gameCardService;
        private GameServiceSoapClient _webServiceClient;

        public AdminUserListForm()
        {
            InitializeComponent();
            _gameCardService = new GameCardService();
            _webServiceClient = new GameServiceSoapClient("GameServiceSoap");
        }


        private void AdminUserListForm_Load_1(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = "SELECT * FROM Users";
                 

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewUsers.DataSource = dt;
                    dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                if (dataGridViewUsers.Columns.Contains("Password"))
                {
                    dataGridViewUsers.Columns["Password"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user list: " + ex.Message);
            }
        }
        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; 

            string userIC = dataGridViewUsers.Rows[e.RowIndex].Cells["ICNumber"].Value.ToString();
            LoadUserTransactions(userIC);
        }


        private void LoadUserTransactions(string userIC)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = @"
                SELECT 
                    br.RecordID,
                    br.ItemID,
                    gc.ItemName AS GameName,
                    br.BorrowDate,
                    br.ReturnDate
                FROM BorrowRecords br
                INNER JOIN GameCards gc ON br.ItemID = gc.ItemID
                WHERE br.UserIC = @UserIC AND br.ReturnDate IS NULL";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@UserIC", userIC);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dt.Columns.Add("Penalty", typeof(double));

                    foreach (DataRow row in dt.Rows)
                    {
                        DateTime borrowDate = Convert.ToDateTime(row["BorrowDate"]);
                        DateTime returnDate = DateTime.Now;

                        double penalty = _webServiceClient.CalculatePenalty(borrowDate, returnDate);
                        row["Penalty"] = penalty;
                    }

                    dgvUserTransactions.DataSource = dt;
                    dgvUserTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvUserTransactions.Columns["Penalty"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions: " + ex.Message);
            }
        }



        private void btnUpdateReturn_Click(object sender, EventArgs e)
        {
            if (dgvUserTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to update.");
                return;
            }

            int recordId = Convert.ToInt32(dgvUserTransactions.SelectedRows[0].Cells["RecordID"].Value);

            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string updateQuery = @"
                UPDATE BorrowRecords  
                SET ReturnDate = @ReturnDate 
                WHERE RecordID = @RecordID";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@ReturnDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@RecordID", recordId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Return date updated.");

                // Refresh transaction list
                string userIC = dataGridViewUsers.SelectedRows[0].Cells["UserIC"].Value.ToString();
                LoadUserTransactions(userIC);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating return date: " + ex.Message);
            }
        }

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdateReturn_Click_1(object sender, EventArgs e)
        {
            // Make sure a user is selected
            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user first.");
                return;
            }

            // Make sure a borrow record is selected
            if (dgvUserTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a borrow record to update.");
                return;
            }

            // Get selected record ID
            int recordId = Convert.ToInt32(dgvUserTransactions.SelectedRows[0].Cells["RecordID"].Value);

            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string updateQuery = @"
                UPDATE BorrowRecords 
                SET ReturnDate = @ReturnDate 
                WHERE RecordID = @RecordID";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@ReturnDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@RecordID", recordId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Return date updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Record might not exist.");
                    }
                }

                // Reload transactions for the same user
                string userIC = dataGridViewUsers.SelectedRows[0].Cells["ICNumber"].Value.ToString();
                LoadUserTransactions(userIC);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating return date: " + ex.Message);
            }
        }

        private void dgvUserTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            string userIC = dataGridViewUsers.SelectedRows[0].Cells["ICNumber"].Value.ToString();

            string connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Check for active borrowings
                SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM BorrowRecords WHERE UserIC = @ic AND ReturnDate IS NULL", conn);
                checkCmd.Parameters.AddWithValue("@ic", userIC);

                int activeBorrowings = (int)checkCmd.ExecuteScalar();

                if (activeBorrowings > 0)
                {
                    MessageBox.Show("Cannot delete user. They have active borrowings.");
                    return;
                }

                // Delete user
                SqlCommand deleteCmd = new SqlCommand("DELETE FROM Users WHERE ICNumber = @ic", conn);
                deleteCmd.Parameters.AddWithValue("@ic", userIC);

                int rowsAffected = deleteCmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("User deleted successfully.");
                    AdminUserListForm_Load_1(null, null); // Reload user list
                }
                else
                {
                    MessageBox.Show("Failed to delete user.");
                }
            }
        }

    }
}

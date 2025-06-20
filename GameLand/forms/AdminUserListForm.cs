using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace GameLand.forms
{
    public partial class AdminUserListForm : Form
    {
        public AdminUserListForm()
        {
            InitializeComponent();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user list: " + ex.Message);
            }
        }
        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Skip header

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
                SELECT RecordID, ItemID, BorrowDate, ReturnDate 
                FROM Transactions 
                WHERE UserIC = @UserIC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@UserIC", userIC);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUserTransactions.DataSource = dt;

                    dgvUserTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                UPDATE Transactions 
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


    }
}

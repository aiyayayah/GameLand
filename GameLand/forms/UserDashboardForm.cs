using System;
using System.Data;
using System.Windows.Forms;
using GameLand.Services;
using GameLand.GameLandWebServiceRef;

namespace GameLand.forms
{
    public partial class UserDashboardForm : Form
    {
        private string userName;
        private string userIC;
        private GameCardService _gameCardService;
        private GameServiceSoapClient _webServiceClient;

        public UserDashboardForm(string name, string ic)
        {
            InitializeComponent();
            userName = name;
            userIC = ic;
            _gameCardService = new GameCardService();

            // Use named endpoint to avoid "multiple endpoint" error
            _webServiceClient = new GameServiceSoapClient("GameServiceSoap");
        }

        private void UserDashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {userName}!";
            LoadAvailableItems();
            LoadUserBorrowedItems();
        }

        private void LoadAvailableItems()
        {
            DataTable table = _gameCardService.GetAvailableItems();

            // Add a new column for masked IC
            if (!table.Columns.Contains("MaskedIC"))
                table.Columns.Add("MaskedIC", typeof(string));

            foreach (DataRow row in table.Rows)
            {
                if (row["UserIC_Last4"] != DBNull.Value)
                {
                    string last4 = row["UserIC_Last4"].ToString();
                    row["MaskedIC"] = "********" + last4;
                }
            }

            dgvAvailableItems.DataSource = table;

            dgvAvailableItems.Columns["ItemID"].HeaderText = "ID";
            dgvAvailableItems.Columns["ItemName"].HeaderText = "Game Name";
            dgvAvailableItems.Columns["ItemPlatform"].HeaderText = "Platform";
            dgvAvailableItems.Columns["ItemStatus"].HeaderText = "Status";
            dgvAvailableItems.Columns["ItemCharges"].HeaderText = "Charges (RM)";
            if (dgvAvailableItems.Columns.Contains("MaskedIC"))
            {
                dgvAvailableItems.Columns["MaskedIC"].HeaderText = "Borrower";
            }

            // Optional: Hide raw UserIC_Last4 column
            if (dgvAvailableItems.Columns.Contains("UserIC_Last4"))
            {
                dgvAvailableItems.Columns["UserIC_Last4"].Visible = false;
            }
        }

        private void LoadUserBorrowedItems()
        {
            dgvBorrowedItems.DataSource = _gameCardService.GetUserBorrowedItems(userIC);
        }

        private void btnBorrow_Click_1(object sender, EventArgs e)
        {
            if (dgvAvailableItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to borrow.");
                return;
            }

            string itemId = dgvAvailableItems.SelectedRows[0].Cells["ItemID"].Value.ToString();

            try
            {
                string result = _webServiceClient.BorrowItem(userIC, itemId);

                if (result == "Success")
                {
                    MessageBox.Show("Item borrowed successfully!");
                    LoadAvailableItems();
                    LoadUserBorrowedItems();
                }
                else
                {
                    MessageBox.Show(result); // Will show if item is not available
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Borrow failed: " + ex.Message);
            }
        }


        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            if (dgvBorrowedItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to return.");
                return;
            }

            try
            {
                int recordId = Convert.ToInt32(dgvBorrowedItems.SelectedRows[0].Cells["RecordID"].Value);
                string itemId = dgvBorrowedItems.SelectedRows[0].Cells["ItemID"].Value.ToString();

                DateTime borrowDate = Convert.ToDateTime(dgvBorrowedItems.SelectedRows[0].Cells["BorrowDate"].Value);
                DateTime returnDate = DateTime.Now;

                double penalty = _webServiceClient.CalculatePenalty(borrowDate, returnDate);

                // Check if penalty is due
                if (penalty > 0)
                {
                    MessageBox.Show($"Total penalty: RM{penalty:F2}\nPlease proceed to the counter to make the payment.", "Penalty Due", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // stop here, do not return the item yet
                }

                // No penalty, proceed with return
                string result = _webServiceClient.ReturnItem(recordId, itemId);

                if (result == "Success")
                {
                    MessageBox.Show("Item returned successfully!");
                    LoadAvailableItems();
                    LoadUserBorrowedItems();
                }
                else
                {
                    MessageBox.Show("Return failed: " + result);
                }


                MessageBox.Show("Item returned successfully!");
                LoadAvailableItems();
                LoadUserBorrowedItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Return failed: " + ex.Message);
            }
        }



        private void lblWelcome_Click(object sender, EventArgs e)
        {
            // Optional label logic
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional grid click logic
        }

        private void dgvBorrowedItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional grid click logic
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Optional textbox logic
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;
using GameLand.Services;
using GameLandWebServiceRef; // Namespace from your added Web Service Reference

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
            _webServiceClient = new GameServiceSoapClient(); // Initialize web service client
        }

        private void UserDashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {userName}!";
            LoadAvailableItems();
            LoadUserBorrowedItems();
        }

        private void LoadAvailableItems()
        {
            dgvAvailableItems.DataSource = _gameCardService.GetAvailableItems();

            dgvAvailableItems.Columns["ItemID"].HeaderText = "ID";
            dgvAvailableItems.Columns["ItemName"].HeaderText = "Game Name";
            dgvAvailableItems.Columns["ItemPlatform"].HeaderText = "Platform";
            dgvAvailableItems.Columns["ItemStatus"].HeaderText = "Status";
            dgvAvailableItems.Columns["ItemCharges"].HeaderText = "Charges (RM)";
            dgvAvailableItems.Columns["UserIC_Last4"].HeaderText = "User IC (Last 4)";
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
                _gameCardService.BorrowItem(userIC, itemId);
                MessageBox.Show("Item borrowed successfully!");
                LoadAvailableItems();
                LoadUserBorrowedItems();
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

            int recordId = Convert.ToInt32(dgvBorrowedItems.SelectedRows[0].Cells["RecordID"].Value);
            string itemId = dgvBorrowedItems.SelectedRows[0].Cells["ItemID"].Value.ToString();

            try
            {
                _gameCardService.ReturnItem(recordId, itemId);
                MessageBox.Show("Item returned successfully!");
                LoadAvailableItems();
                LoadUserBorrowedItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Return failed: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double hours))
            {
                try
                {
                    // Call the web service to calculate charge
                    double charge = _webServiceClient.CalculateCharge(hours);
                    MessageBox.Show("Total charge: RM" + charge.ToString("F2"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error contacting web service: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number of hours.");
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

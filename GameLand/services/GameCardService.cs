using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GameLand.Services
{
    public class GameCardService
    {
        private readonly string connectionString;

        public GameCardService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
        }

        public DataTable GetAvailableItems()
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
                return table;
            }
        }

        public DataTable GetUserBorrowedItems(string userIC)
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
                return table;
            }
        }

        public void BorrowItem(string userIC, string itemId)
        {
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
        }

        public void ReturnItem(int recordId, string itemId)
        {
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
        }
    }
}

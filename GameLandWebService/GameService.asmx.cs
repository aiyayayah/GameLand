using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;

namespace GameLandWebService
{
    [WebService(Namespace = "http://gameland.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GameService : WebService
    {

        [WebMethod]
        public string RegisterUser(string name, string ic, string password, string email, string phone)

        {
            string connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM Users WHERE ICNumber = @IC";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@IC", ic);

                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    return "IC already exists.";
                }

                string insertQuery = "INSERT INTO Users (Name, ICNumber, Password, Email, Phone) VALUES (@Name, @IC, @Password, @Email, @Phone)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@IC", ic);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.ExecuteNonQuery();


                return "Registration successful.";
            }
        }
        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }


        [WebMethod]
        public string LoginUser(string ic, string password)
        {
            string hashedPassword = HashPassword(password); // 🔒 ADD THIS
            string connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT Name FROM Users WHERE ICNumber = @IC AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IC", ic);
                cmd.Parameters.AddWithValue("@Password", hashedPassword); // 🔁 Use hashedPassword here

                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : null;
            }
        }


        [WebMethod]
        public string AdminLogin(string staffID, string password)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConn"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Admins WHERE StaffID = @StaffID AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StaffID", staffID);
                cmd.Parameters.AddWithValue("@Password", password);

                int count = (int)cmd.ExecuteScalar();
                return count > 0 ? "Success" : "Fail";
            }
        }

        [WebMethod]
        public double CalculatePenalty(DateTime borrowDate, DateTime returnDate)
        {
            TimeSpan duration = returnDate.Date - borrowDate.Date;
            int totalDays = duration.Days;

            if (totalDays <= 1) // within 1 day
            {
                return 0.0;
            }

            int overdueDays = totalDays - 7;

            if (overdueDays > 0)
            {
                return overdueDays * 5.0; // RM5 per day
            }

            return 0.0;
        }

        [WebMethod]
        public string BorrowItem(string userIC, string itemId)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConn"].ConnectionString))
            {
                conn.Open();

                // Step 1: Check how many items the user has currently borrowed and not returned
                SqlCommand countCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM BorrowRecords WHERE UserIC = @ic AND ReturnDate IS NULL", conn);
                countCmd.Parameters.AddWithValue("@ic", userIC);

                int borrowedCount = (int)countCmd.ExecuteScalar();
                if (borrowedCount >= 3)
                {
                    return "Borrowing limit reached. You can only borrow up to 3 items.";
                }

                // Step 2: Check if the item is available
                SqlCommand checkCmd = new SqlCommand("SELECT ItemStatus FROM GameCards WHERE ItemID = @itemId", conn);
                checkCmd.Parameters.AddWithValue("@itemId", itemId);
                string status = (string)checkCmd.ExecuteScalar();

                if (status != "Available")
                {
                    return "Item is not available.";
                }

                // Step 3: Insert borrow record
                SqlCommand borrowCmd = new SqlCommand(
                    "INSERT INTO BorrowRecords (UserIC, ItemID, BorrowDate) VALUES (@ic, @itemId, GETDATE())", conn);
                borrowCmd.Parameters.AddWithValue("@ic", userIC);
                borrowCmd.Parameters.AddWithValue("@itemId", itemId);
                borrowCmd.ExecuteNonQuery();

                // Step 4: Update game card status
                SqlCommand updateCmd = new SqlCommand(
                    "UPDATE GameCards SET ItemStatus = 'Not Available', UserIC = @ic WHERE ItemID = @itemId", conn);
                updateCmd.Parameters.AddWithValue("@ic", userIC);
                updateCmd.Parameters.AddWithValue("@itemId", itemId);
                updateCmd.ExecuteNonQuery();

                return "Success";
            }
        }


        [WebMethod]
        public string ReturnItem(int recordId, string itemId)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConn"].ConnectionString))
            {
                conn.Open();

                // Step 1: Update return date
                SqlCommand updateReturn = new SqlCommand(
                    "UPDATE BorrowRecords SET ReturnDate = GETDATE() WHERE RecordID = @recordId", conn);
                updateReturn.Parameters.AddWithValue("@recordId", recordId);
                updateReturn.ExecuteNonQuery();

                // Step 2: Set item as available
                SqlCommand updateItem = new SqlCommand(
                    "UPDATE GameCards SET ItemStatus = 'Available', UserIC = NULL WHERE ItemID = @itemId", conn);
                updateItem.Parameters.AddWithValue("@itemId", itemId);
                updateItem.ExecuteNonQuery();

                return "Success";
            }
        }


        [WebMethod]
        public string CheckConnectionString()
        {
            var conn = ConfigurationManager.ConnectionStrings["myConn"];
            return conn != null ? "Connection string found " : "myConn not found in Web.config";
        }

        [WebMethod]
        public bool UpdateUserInfo(string icNumber, string name, string email, string phone)
        {
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
                    cmd.Parameters.AddWithValue("@IC", icNumber);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public string DeleteUser(string ic)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // Check for active borrowings
                    string checkQuery = "SELECT COUNT(*) FROM BorrowRecords WHERE UserIC = @ic AND ReturnDate IS NULL";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@ic", ic);
                    int active = (int)checkCmd.ExecuteScalar();

                    if (active > 0)
                    {
                        return "This user has active borrowings and cannot be deleted.";
                    }

                    // Delete user
                    string deleteQuery = "DELETE FROM Users WHERE ICNumber = @ic";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                    deleteCmd.Parameters.AddWithValue("@ic", ic);
                    int rows = deleteCmd.ExecuteNonQuery();

                    if (rows > 0)
                        return "Success";
                    else
                        return "No user found to delete.";
                }
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }


    }
}

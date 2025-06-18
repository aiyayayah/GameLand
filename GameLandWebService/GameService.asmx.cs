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
        public string RegisterUser(string name, string ic, string password)
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

                string insertQuery = "INSERT INTO Users (Name, ICNumber, Password) VALUES (@Name, @IC, @Password)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@IC", ic);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.ExecuteNonQuery();

                return "Registration successful.";
            }
        }


        [WebMethod]
        public string LoginUser(string ic, string password)
        {
            string connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT Name FROM Users WHERE ICNumber = @IC AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IC", ic);
                cmd.Parameters.AddWithValue("@Password", password);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return result.ToString(); // Return user name
                }
                else
                {
                    return null; // Login failed
                }
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
        public double CalculateCharge(double hours)
        {
            return hours * 5.00;
        }


        [WebMethod]
        public string CheckConnectionString()
        {
            var conn = ConfigurationManager.ConnectionStrings["myConn"];
            return conn != null ? "Connection string found ✅" : "❌ myConn not found in Web.config";
        }

    }
}

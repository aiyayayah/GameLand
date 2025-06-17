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
        public string Hello()
        {
            return "Hello from GameLand!";
        }

        [WebMethod]
        public double CalculateCharge(double hours)
        {
            return hours * 5.00; 
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
        public string CheckConnectionString()
        {
            var conn = ConfigurationManager.ConnectionStrings["myConn"];
            return conn != null ? "Connection string found ✅" : "❌ myConn not found in Web.config";
        }

    }
}

using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;
using GameCardAPI.Models;

namespace GameCardAPI.Controllers
{
    public class CardTransactionController : ApiController
    {
        string connStr = ConfigurationManager.ConnectionStrings["myConn"].ConnectionString;

        [HttpPost]
        [Route("api/borrow")]
        public IHttpActionResult BorrowCard(BorrowRequest request)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Borrows (UserID, CardID, BorrowDate) VALUES (@UserID, @CardID, GETDATE())";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", request.UserID);
                cmd.Parameters.AddWithValue("@CardID", request.CardID);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return Ok(new { message = "Card borrowed successfully." });
            }
        }

        [HttpPost]
        [Route("api/return")]
        public IHttpActionResult ReturnCard(BorrowRequest request)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE Borrows SET ReturnDate = GETDATE() WHERE UserID = @UserID AND CardID = @CardID AND ReturnDate IS NULL";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", request.UserID);
                cmd.Parameters.AddWithValue("@CardID", request.CardID);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return Ok(new { message = "Card returned successfully." });
            }
        }
    }
}

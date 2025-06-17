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
            return hours * 5.00; // Example: RM5/hour
        }
    }
}

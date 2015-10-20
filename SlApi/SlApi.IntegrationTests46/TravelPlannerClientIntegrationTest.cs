using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlApi.Models;
using SlApi.Models.TravelPlanner.Request;

namespace SlApi.IntegrationTests
{
    [TestClass]
    public class TravelPlannerClientIntegrationTest
    {
       
        [TestMethod]
        public void GeometryIntegrationSuccessTest()
        {
            
            var token = EnvironmentHelper.GetEnvironmentVariable("TravelPlannerClientApiToken");
            var client = new TravelPlannerClient(token)
            {
                GzipEnabled = true
            };
            var result = client.Geometry(new GeometryRequest
            {
                Ref = "54"
            });
            Assert.IsTrue(result.StatusCode == StatusCode.Ok);

        }
    }
}

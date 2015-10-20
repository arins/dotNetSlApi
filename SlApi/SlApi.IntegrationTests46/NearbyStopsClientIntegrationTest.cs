using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlApi.Core;
using SlApi.Models.NearbyStations.Request;

namespace SlApi.IntegrationTests
{
    [TestClass]
    public class NearbyStopsClientIntegrationTest
    {
        [TestMethod]
        public void NearbystopsSuccessTest()
        {
            
            var token = EnvironmentHelper.GetEnvironmentVariable("NearbyStopsClientApiToken");
            var client = new NearbyStopsClient(token)
            {
                GzipEnabled = true,
                ApiToken = token
            };
            try
            {
                var stopLocations = client.Nearbystops(new NearbyStopsRequest
                {
                    MaxResults = 10,
                    OriginCoordLong = 17.998996D,
                    OriginCoordLat = 59.358675D
                });
                var first = stopLocations.LocationList.StopLocation.FirstOrDefault();
                Assert.IsTrue(first != null);
                Assert.IsTrue(first.Name.ToLower().Contains("solna"));
            }
            catch (HttpRequestException ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        
    }
}

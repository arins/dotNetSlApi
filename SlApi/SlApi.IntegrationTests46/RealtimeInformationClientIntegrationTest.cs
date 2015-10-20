using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlApi.Models.RealtimeInformation.Request;

namespace SlApi.IntegrationTests
{
    [TestClass]
    public class RealtimeInformationClientIntegrationTest
    {
        [TestMethod]
        public void RealtimeDeparturesTestSuccess()
        {
            var token = EnvironmentHelper.GetEnvironmentVariable("RealtimeInformationClientApiToken");
            var client = new RealtimeInformationClient(token)
            {
                GzipEnabled = true,
                
            };
            var result = client.RealtimeDepartures(new RealtimeDeparturesRequest());
            Assert.IsTrue(result.ResponseData.LatestUpdate.Year > 2014);
        }
    }
}

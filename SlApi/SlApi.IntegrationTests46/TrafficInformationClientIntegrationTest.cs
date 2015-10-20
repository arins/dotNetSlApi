using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlApi.Models;

namespace SlApi.IntegrationTests
{
    [TestClass]
    public class TrafficInformationClientIntegrationTest
    {
        [TestMethod]
        public void TrafficInformationClientTest()
        {
            var token = EnvironmentHelper.GetEnvironmentVariable("TrafficInformationClientApiToken");
            var t = new TrafficInformationClient(token);
            var result = t.GetTrafficInformation();
            Assert.IsTrue(result.StatusCode == StatusCode.Ok);
        }
    }
}

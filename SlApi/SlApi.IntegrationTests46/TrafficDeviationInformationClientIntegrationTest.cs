using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlApi.Models.RealtimeInformation.Request;
using SlApi.Models.TrafficDeviationInformation.Request;

namespace SlApi.IntegrationTests
{
    [TestClass]
    public class TrafficDeviationInformationClientIntegrationTest
    {
        [TestMethod]
        public void GetTrafficDeviationInformationIntegrationFailTest()
        {
            var token = EnvironmentHelper.GetEnvironmentVariable("TrafficDeviationInformationClientApiToken");
            var client = new TrafficDeviationInformationClient(token)
            {
                GzipEnabled = true,

            };
            var result = client.GetTrafficDeviationInformation(new TrafficDeviationInformationRequest());
            if (result.ResponseData.Any())
            {
                Assert.IsTrue(result.ResponseData.All(r => r.Created.Date.Year > 2013));
            }

        }
    }
}

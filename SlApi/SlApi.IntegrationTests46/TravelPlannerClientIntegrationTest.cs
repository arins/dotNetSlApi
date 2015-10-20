using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlApi.Core;
using SlApi.Models;
using SlApi.Models.PlaceSearch.Request;
using SlApi.Models.PlaceSearch.Response;
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

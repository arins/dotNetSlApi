using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlApi.Core;
using SlApi.Models;
using SlApi.Models.PlaceSearch.Request;
using SlApi.Models.PlaceSearch.Response;

namespace SlApi.IntegrationTests
{
    [TestClass]
    public class PlaceSearchClientIntegrationTest
    {
        [TestMethod]
        public void SearchFailTest()
        {
            
            var token = EnvironmentHelper.GetEnvironmentVariable("PlaceSearchClientApiToken");
            var client = new PlaceSearchClient(token, "https://arin.sinabian.se/")
            {
                GzipEnabled = true,
                ApiToken = token
            };
            Sites sites = null;
            try
            {
                sites = client.Search(new PlaceSearchRequest
                {
                    MaxResults = 10,
                    SearchString = "solna",
                    StationsOnly = false
                });
            }
            catch (HttpRequestException)
            {
                Assert.IsTrue(sites == null);
            }

        }

        [TestMethod]
        public void SearchSuccessTest()
        {
            
            var token = EnvironmentHelper.GetEnvironmentVariable("PlaceSearchClientApiToken");
            var client = new PlaceSearchClient
            {
                GzipEnabled = true,
                ApiToken = token
            };
            var result = client.Search(new PlaceSearchRequest
            {
                MaxResults = 10,
                SearchString = "solna",
                StationsOnly = false
            });
            Assert.IsTrue(result.StatusCode == StatusCode.Ok);

            var station = result.ResponseData.FirstOrDefault();

            Assert.IsTrue(station != null);
            Assert.IsTrue(station.Name.ToLower().Contains("solna"));

        }
    }
}

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SlApi.Core;
using SlApi.Models;
using SlApi.Models.PlaceSearch.Request;

namespace SlApi.Tests
{
    [TestClass]
    [DeploymentItem("TestData\\PlaceSearchClient\\success.json", "TestData\\PlaceSearchClient")]
    public class PlaceSearchClientTest : SlApiTest
    {

        public string GetTestResponse()
        {
            return GetSampleResponse("TestData\\PlaceSearchClient\\success.json");
        }

        [TestMethod]
        public void Search()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/typeahead.json/?SearchString=Solna&StationsOnly=false&key=" + fakekey)))
                .Returns(GetTestResponse);
            var search = new PlaceSearchClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };


            var result = search.Search(new PlaceSearchRequest
            {
                SearchString = "Solna",
                StationsOnly = false
            });
            Assert.IsTrue(result.ResponseData.Count() == 10);
            Assert.IsTrue(result.StatusCode == StatusCode.Ok);
            var first = result.ResponseData.FirstOrDefault();
            var last = result.ResponseData.LastOrDefault();
            Assert.IsTrue(first != null);
            Assert.IsTrue(last != null);
            Assert.IsTrue(last != first);

            Assert.IsTrue(first.Name.Equals("Solna (Solna)"));
            Assert.IsTrue(first.X == "18011865");
            Assert.IsTrue(first.Y == "59364312");
            Assert.IsTrue(first.Latitude == 18.011865);
            Assert.IsTrue(first.Longitude == 59.364312);
            Assert.IsTrue(first.SiteId.Equals(9509));

            Assert.IsTrue(last.Latitude == 17.986731);
            Assert.IsTrue(last.Longitude == 9.375783);
        }

        [TestMethod]
        public void SearchAsync()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/typeahead.json/?SearchString=Solna&StationsOnly=false&key=" + fakekey)))
                .ReturnsAsync(GetTestResponse());
            var search = new PlaceSearchClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };


            var resultAsync = search.SearchAsync(new PlaceSearchRequest
            {
                SearchString = "Solna",
                StationsOnly = false
            });

            resultAsync.Wait();
            var result = resultAsync.Result;
            Assert.IsTrue(result.ResponseData.Count() == 10);
            Assert.IsTrue(result.StatusCode == StatusCode.Ok);
            var first = result.ResponseData.FirstOrDefault();
            var last = result.ResponseData.LastOrDefault();
            Assert.IsTrue(first != null);
            Assert.IsTrue(last != null);
            Assert.IsTrue(last != first);

            Assert.IsTrue(first.Name.Equals("Solna (Solna)"));
            Assert.IsTrue(first.X == "18011865");
            Assert.IsTrue(first.Y == "59364312");
            Assert.IsTrue(first.Latitude == 18.011865);
            Assert.IsTrue(first.Longitude == 59.364312);
            Assert.IsTrue(first.SiteId.Equals(9509));

            Assert.IsTrue(last.Latitude == 17.986731);
            Assert.IsTrue(last.Longitude == 9.375783);

        }
    }
}

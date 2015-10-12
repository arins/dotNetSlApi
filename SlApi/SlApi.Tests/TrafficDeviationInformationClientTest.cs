using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SlApi.Core;
using SlApi.Models.TrafficDeviationInformation.Request;

namespace SlApi.Tests
{
    [TestClass]
    [DeploymentItem("TestData\\TrafficDeviationInformationClient\\success.json", "TestData\\TrafficDeviationInformationClient")]
    public class TrafficDeviationInformationClientTest : SlApiTest
    {

        public string GetTestResponse()
        {
            return GetSampleResponse("TestData\\TrafficDeviationInformationClient\\success.json");

        }

        [TestMethod]
        public void TrafficDeviationInformationTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/deviations.json/?key=" + fakekey)))
                .Returns(GetTestResponse);
            var t = new TrafficDeviationInformationClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper())
            {
                ApiToken = fakekey
            });

          
            var result = t.GetTrafficDeviationInformation(new TrafficDeviationInformationRequest());

            var f = result.ResponseData.FirstOrDefault();
            Assert.IsTrue(f!=null);
            var date = new DateTime(2015, 9, 4, 16, 14, 13);
            DateTime.SpecifyKind(date, DateTimeKind.Local);
            
            Assert.IsTrue(!f.MainNews);
            Assert.IsTrue(f.Details.StartsWith("Förändringar i busstrafiken"));




        }

        [TestMethod]
        public void TrafficDeviationInformationAsyncTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/deviations.json/?key=" + fakekey)))
                .ReturnsAsync(GetTestResponse());
            var t = new TrafficDeviationInformationClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };


            var responseAsync = t.GetTrafficDeviationInformationAsync(new TrafficDeviationInformationRequest());

            responseAsync.Wait();
            var result = responseAsync.Result;
            var f = result.ResponseData.FirstOrDefault();
            Assert.IsTrue(f != null);
            var date = new DateTime(2015, 9, 4, 16, 14, 13);
            DateTime.SpecifyKind(date, DateTimeKind.Local);

            Assert.IsTrue(!f.MainNews);
            Assert.IsTrue(f.Details.StartsWith("Förändringar i busstrafiken"));

        }
    }
}

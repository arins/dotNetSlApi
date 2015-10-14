using System;
using System.IO;
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

        public Stream GetTestResponse()
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(GetSampleResponse("TestData\\TrafficDeviationInformationClient\\success.json"));
            sw.AutoFlush = true;
            ms.Seek(0, SeekOrigin.Begin);
            return ms;

        }

        [TestMethod]
        public void TrafficDeviationInformationTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = HttpRequestMocker.GetMockedRequesterFor(new Uri(
                            "https://api.sl.se/api2/deviations.json/?key=" + fakekey), GetTestResponse());
            var t = new TrafficDeviationInformationClient(new HttpClient("https://api.sl.se/", mockedHttpRequest, new UrlHelper())
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
            var mockedHttpRequest = HttpRequestMocker.GetMockedRequesterFor(new Uri(
                            "https://api.sl.se/api2/deviations.json/?key=" + fakekey), GetTestResponse());
            var t = new TrafficDeviationInformationClient(new HttpClient("https://api.sl.se/", mockedHttpRequest, new UrlHelper()))
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

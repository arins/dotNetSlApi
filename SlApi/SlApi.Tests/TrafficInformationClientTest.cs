using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SlApi.Core;
using SlApi.Models.TrafficInformation.Response;

namespace SlApi.Tests
{
    [TestClass]
    [DeploymentItem("TestData\\TrafficInformationClient\\success.json", "TestData\\TrafficInformationClient")]
    public class TrafficInformationClientTest : SlApiTest
    {

        public Stream GetTestResponse()
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(GetSampleResponse("TestData\\TrafficInformationClient\\success.json"));
            sw.AutoFlush = true;
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
            

        }

        [TestMethod]
        public void TrafficInformationTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = HttpRequestMocker.GetMockedRequesterFor(new Uri(
                            "https://api.sl.se/api2/trafficsituation.json/?key=" + fakekey), GetTestResponse());
            var t = new TrafficInformationClient(new HttpClient("https://api.sl.se/", mockedHttpRequest, new UrlHelper())
            {
                ApiToken = fakekey
            });

          
            var result = t.GetTrafficInformation();

            var f = result.ResponseData.TrafficTypes.FirstOrDefault();
            Assert.IsTrue(f!=null);
            Assert.IsTrue(f.Id == 2);
            Assert.IsTrue(f.Name == "Tunnelbana");
            Assert.IsTrue(f.Type== TraficTypeEnum.Metro);
            Assert.IsTrue(f.StatusIcon == "EventGood");
            var firstEvent = f.Events.FirstOrDefault();
            Assert.IsTrue(firstEvent != null);
            Assert.IsTrue(firstEvent.EventId == 3489);
            Assert.IsTrue(firstEvent.Message == "Hissen vid Alby mellan biljetthallen och plattformen för tågen mot Ropsten, är avstängd tills vidare för underhållsarbeten.");
            Assert.IsTrue(firstEvent.SortIndex == 100);



        }

        [TestMethod]
        public void TrafficInformationAsyncTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = HttpRequestMocker.GetMockedRequesterFor(new Uri(
                            "https://api.sl.se/api2/trafficsituation.json/?key=" + fakekey), GetTestResponse());
            var t = new TrafficInformationClient(new HttpClient("https://api.sl.se/", mockedHttpRequest, new UrlHelper()))
            {
                ApiToken = fakekey
            };
            var responseAsync = t.GetTrafficInformationAsync();
            responseAsync.Wait();
            var result = responseAsync.Result;
            var f = result.ResponseData.TrafficTypes.FirstOrDefault();
            Assert.IsTrue(f != null);
            Assert.IsTrue(f.Id == 2);
            Assert.IsTrue(f.Name == "Tunnelbana");
            Assert.IsTrue(f.Type == TraficTypeEnum.Metro);
            Assert.IsTrue(f.StatusIcon == "EventGood");
            var firstEvent = f.Events.FirstOrDefault();
            Assert.IsTrue(firstEvent != null);
            Assert.IsTrue(firstEvent.EventId == 3489);
            Assert.IsTrue(firstEvent.Message == "Hissen vid Alby mellan biljetthallen och plattformen för tågen mot Ropsten, är avstängd tills vidare för underhållsarbeten.");
            Assert.IsTrue(firstEvent.SortIndex == 100);

        }
    }
}

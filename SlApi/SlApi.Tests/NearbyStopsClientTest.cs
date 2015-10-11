using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SlApi.Core;
using SlApi.Models;
using SlApi.Models.NearbyStations.Request;

namespace SlApi.Tests
{
    [TestClass]
    [DeploymentItem("TestData\\NearbyStopsClient\\success.json", "TestData\\NearbyStopsClient")]
    public class NearbyStopsClientTest : SlApiTest
    {
       

        [TestMethod]
        public void NearbystopsTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/nearbystops.json/?originCoordLat=59.365602&originCoordLong=17.998137&key=" + fakekey)))
                .Returns(GetNearbyStationDataForTest);
            var t = new NearbyStopsClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper())
            {
                ApiToken = fakekey
            });

          
            var result = t.Nearbystops(new NearbyStopsRequest
            {
                OriginCoordLat = 59.365602,
                OriginCoordLong = 17.998137
            });
            Assert.IsTrue(result.LocationList.StopLocation[0].Idx == 1);
            Assert.IsTrue(result.LocationList.StopLocation[0].Name == "Trappgränd (Solna)");
            Assert.IsTrue(result.LocationList.StopLocation[0].Id == "300103467");
            Assert.IsTrue(result.LocationList.StopLocation[0].SiteId == "03467");
            Assert.IsTrue(result.LocationList.StopLocation[0].Lat == 59.365571);


        }

        [TestMethod]
         public void SitesAsyncTest()
         {

             var fakekey = "fakekey";
             var mockedHttpRequest = new Mock<IHttpRequester>();
             mockedHttpRequest.Setup(
                 x =>
                     x.GetResponseAsync(
                         new Uri(
                             "https://api.sl.se/api2/nearbystops.json/?originCoordLat=59.365602&originCoordLong=17.998137&key=" + fakekey)))
                 .ReturnsAsync(GetNearbyStationDataForTest());
             var t = new NearbyStopsClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper())
             {
                 ApiToken = fakekey
             });


             var responseAsync = t.NearbystopsAsync(new NearbyStopsRequest
             {
                 OriginCoordLat = 59.365602,
                 OriginCoordLong = 17.998137
             });
             responseAsync.Wait();
             var result = responseAsync.Result;
            Assert.IsTrue(result.LocationList.StopLocation[0].Idx == 1);
             Assert.IsTrue(result.LocationList.StopLocation[0].Name == "Trappgränd (Solna)");
             Assert.IsTrue(result.LocationList.StopLocation[0].Id == "300103467");
            Assert.IsTrue(result.LocationList.StopLocation[0].SiteId == "03467");
            Assert.IsTrue(result.LocationList.StopLocation[0].Lat == 59.365571);

         }


        [TestMethod]
        public void NearbyStopsErrorTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/nearbystops.json/?originCoordLat=59.365602&originCoordLong=17.998137&key=" + fakekey)))
                .Returns(GetNearbyStationsErrorDataForTest);
            var t = new NearbyStopsClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper())
            {
                ApiToken = fakekey
            });


            var result = t.Nearbystops(new NearbyStopsRequest
            {
                OriginCoordLat = 59.365602,
                OriginCoordLong = 17.998137
            });
            Assert.IsTrue(result.LocationList.ErrorCode == ErrorCode.R0002);
            Assert.IsTrue(result.LocationList.ErrorText == "Ogiltiga eller saknade parametrar");


        }


        public string GetNearbyStationsErrorDataForTest()
        {
            return GetSampleResponse("NearbyStopsClient\\error.json");
        }


        public string GetNearbyStationDataForTest()
        {
            return GetSampleResponse("NearbyStopsClient\\success.json");
        }
    }
}

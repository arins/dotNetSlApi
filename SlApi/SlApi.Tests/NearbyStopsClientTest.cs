using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SlApi.Core;
using SlApi.Models;
using SlApi.Models.NearbyStations.Request;

namespace SlApi.Tests
{
    [TestClass]
    public class NearbyStopsClientTest
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
            return
                "{\"LocationList\":{  \"noNamespaceSchemaLocation\":\"\",  \"errorCode\":\"R0002\",  \"errorText\":\"Ogiltiga eller saknade parametrar\"  }}";
        }


        public string GetNearbyStationDataForTest()
        {
            return
                "{\"LocationList\":{  \"noNamespaceSchemaLocation\":\"hafasRestLocation.xsd\",  \"StopLocation\":[{ " +
                "   \"idx\":\"1\",    \"name\":\"Trappgränd (Solna)\",    \"id\":\"300103467\",    \"lat\":\"59.365571\", " +
                "   \"lon\":\"17.998435\",    \"dist\":\"17\"    },{    \"idx\":\"2\",    \"name\":\"Stråket (Solna)\",  " +
                "  \"id\":\"300103460\",    \"lat\":\"59.365004\",    \"lon\":\"17.995496\",    \"dist\":\"163\"    },{ " +
                "   \"idx\":\"3\",    \"name\":\"Vasalund (Solna)\",    \"id\":\"300103453\",    \"lat\":\"59.366299\", " +
                "   \"lon\":\"18.000898\",    \"dist\":\"175\"    },{    \"idx\":\"4\",    \"name\":\"Fotbollsstadion (Solna)\"," +
                "    \"id\":\"300103466\",    \"lat\":\"59.363234\",    \"lon\":\"17.997581\",    \"dist\":\"264\" " +
                "   },{    \"idx\":\"5\",    \"name\":\"Råsunda (Solna)\",    \"id\":\"300103469\",   " +
                " \"lat\":\"59.365337\",    \"lon\":\"17.993195\",    \"dist\":\"281\"    },{    \"idx\":\"6\",   " +
                " \"name\":\"Östervägen (Solna)\",    \"id\":\"300103448\",    \"lat\":\"59.367665\",   " +
                " \"lon\":\"17.995235\",    \"dist\":\"282\"    },{    \"idx\":\"7\",    \"name\":\"Solna centrum norra (Solna)\", " +
                "   \"id\":\"300103472\",    \"lat\":\"59.361696\",    \"lon\":\"17.999775\",    \"dist\":\"443\"  " +
                "  },{    \"idx\":\"8\",    \"name\":\"Frösundaleden (Solna)\",    \"id\":\"300103464\",  " +
                "  \"lat\":\"59.361678\",    \"lon\":\"18.000476\",    \"dist\":\"455\"    },{    \"idx\":\"9\",  " +
                "  \"name\":\"Pyramidvägen (Solna)\",    \"id\":\"300103459\",    \"lat\":\"59.366685\", " +
                "   \"lon\":\"18.006130\",    \"dist\":\"469\"    },{    \"idx\":\"10\",    \"name\":\"Dalvägen (Solna)\", " +
                "   \"id\":\"300103454\",    \"lat\":\"59.365346\",    \"lon\":\"18.006705\",    \"dist\":\"486\"    }]  }}";
        }
    }
}

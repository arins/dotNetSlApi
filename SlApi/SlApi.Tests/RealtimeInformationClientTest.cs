using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SlApi.Core;
using SlApi.Models;
using SlApi.Models.RealtimeInformation.Request;
using SlApi.Models.RealtimeInformation.Response;

namespace SlApi.Tests
{
    [TestClass]
    public class RealtimeInformationClientTest
    {

        public string GetTestResponse()
        {
            return
                "{\"StatusCode\":0,\"Message\":null,\"ExecutionTime\":463,\"ResponseData\":{\"L" +
                "atestUpdate\":\"2015-07-25T16:58:22\",\"DataAge\":2,\"Metros\":[{\"StopAreaName\"" +
                ":\"Solna centrum\",\"GroupOfLine\":\"Tunnelbanans blå linje\",\"DisplayTime\":\"5 mi" +
                "n\",\"SafeDestinationName\":\"Akalla\",\"GroupOfLineId\":3,\"DepartureGroupId\"" +
                ":1,\"PlatformMessage\":null,\"TransportMode\":\"METRO\",\"LineNumber\":\"11\",\"De" +
                "stination\":\"Akalla\",\"JourneyDirection\":1,\"SiteId\":9305},{\"StopAreaName\":" +
                "\"Solna centrum\",\"GroupOfLine\":\"Tunnelbanans blå linje\",\"DisplayTime\":\"10 " +
                "min\",\"SafeDestinationName\":\"Akalla\",\"GroupOfLineId\":3,\"DepartureGroupId\":1" +
                ",\"PlatformMessage\":null,\"TransportMode\":\"METRO\",\"LineNumber\":\"11\",\"Destin" +
                "ation\":\"Akalla\",\"JourneyDirection\":1,\"SiteId\":9305},{\"StopAreaName\":\"Solna " +
                "centrum\",\"GroupOfLine\":\"Tunnelbanans blå linje\",\"DisplayTime\":\"20 min\",\"Safe" +
                "DestinationName\":\"Akalla\",\"GroupOfLineId\":3,\"DepartureGroupId\":1,\"PlatformM" +
                "essage\":null,\"TransportMode\":\"METRO\",\"LineNumber\":\"11\",\"Destination\":\"A" +
                "kalla\",\"JourneyDirection\":1,\"SiteId\":9305},{\"StopAreaName\":\"Solna centrum\"" +
                ",\"GroupOfLine\":\"Tunnelbanans blå linje\",\"DisplayTime\":\"1 min\",\"SafeDestin" +
                "ationName\":\"Kungsträdgården\",\"GroupOfLineId\":3,\"DepartureGroupId\":2,\"Platf" +
                "ormMessage\":null,\"TransportMode\":\"METRO\",\"LineNumber\":\"11\",\"Destination\"" +
                ":\"Kungsträdgården\",\"JourneyDirection\":2,\"SiteId\":9305},{\"StopAreaName\":\"S" +
                "olna centrum\",\"GroupOfLine\":\"Tunnelbanans blå linje\",\"DisplayTime\":\"10 min" +
                "\",\"SafeDestinationName\":\"Kungsträdgården\",\"GroupOfLineId\":3,\"DepartureGroup" +
                "Id\":2,\"PlatformMessage\":null,\"TransportMode\":\"METRO\",\"LineNumber\":\"11\",\"D" +
                "estination\":\"Kungsträdgården\",\"JourneyDirection\":2,\"SiteId\":9305},{\"StopAreaN" +
                "ame\":\"Solna centrum\",\"GroupOfLine\":\"Tunnelbanans blå linje\",\"DisplayTime\":\"20" +
                " min\",\"SafeDestinationName\":\"Kungsträdgården\",\"GroupOfLineId\":3,\"DepartureGrou" +
                "pId\":2,\"PlatformMessage\":null,\"TransportMode\":\"METRO\",\"LineNumber\":\"11\",\"" +
                "Destination\":\"Kungsträdgården\",\"JourneyDirection\":2,\"SiteId\":9305}],\"Buses\"" +
                ":[{\"JourneyDirection\":2,\"GroupOfLine\":\"Ersättningsbuss\",\"StopAreaName\":\"Soln" +
                "a centrum\",\"StopAreaNumber\":17202,\"StopPointNumber\":17202,\"StopPointDesignation\"" +
                ":null,\"TimeTabledDateTime\":\"2015-07-25T16:59:00\",\"ExpectedDateTime\":\"2015-07-25T1" +
                "6:59:00\",\"DisplayTime\":\"Nu\",\"Deviations\":null,\"TransportMode\":\"BUS\",\"LineNum" +
                "ber\":\"22A\",\"Destination\":\"Alvik\",\"SiteId\":9305}],\"Trains\":[],\"Trams\":[],\"" +
                "Ships\":[],\"StopPointDeviations\":[{\"StopInfo\":{\"StopAreaNumber\":0,\"StopAreaName\"" +
                ":\"Solna centrum\",\"TransportMode\":\"n\\\\a\",\"GroupOfLine\":null},\"Deviation\":{\"Te" +
                "xt\":\"Buss 22A ersätter mellan Alvik och Solna station t o m 9/8. Buss 22B ersätter me" +
                "llan Gröndalsrampen och Sickla udde t o m 2/8. Använd reseplaneraren för att hitta det " +
                "bästa alternativet för din resa!\",\"Consequence\":null,\"ImportanceLevel\":9}},{\"Stop" +
                "Info\":{\"StopAreaNumber\":0,\"StopAreaName\":\"Solna centrum\",\"TransportMode\":\"n\\\\a\"" +
                ",\"GroupOfLine\":null},\"Deviation\":{\"Text\":\"Ersättningsbuss 22A avgår från Frösund" +
                "aleden.\",\"Consequence\":null,\"ImportanceLevel\":9}}]}}";
        }

        [TestMethod]
        public void RealtimeDeparturesTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/realtimedepartures.json/?SiteId=9305&TimeWindow=2&key=" + fakekey)))
                .Returns(GetTestResponse);
            var t = new RealtimeInformationClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };

          
            var result = t.RealtimeDepartures(new RealtimeDeparturesRequest
            {
                SiteId = 9305,
                TimeWindow = 2
            });

            var f = result.ResponseData.Metros.FirstOrDefault();
            Assert.IsTrue(f!=null);
            Assert.IsTrue(result.StatusCode == StatusCode.Ok);
            Assert.IsTrue(result.ResponseData.Buses.Count() == 1);
            Assert.IsTrue(!result.ResponseData.Ships.Any());
            Assert.IsTrue(result.ResponseData.Metros.Count() == 6);
            Assert.IsTrue(f.DisplayTime == "5 min");

        }

        [TestMethod]
        public void RealtimeDeparturesAsyncTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/realtimedepartures.json/?SiteId=9305&TimeWindow=2&key=" + fakekey)))
                .ReturnsAsync(GetTestResponse());
            var t = new RealtimeInformationClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };


            var responseAsync = t.RealtimeDeparturesAsync(new RealtimeDeparturesRequest
            {
                SiteId = 9305,
                TimeWindow = 2
            });
            responseAsync.Wait();
            var result = responseAsync.Result;
            var firstMetro = result.ResponseData.Metros.FirstOrDefault();
            var firstBus = result.ResponseData.Buses.FirstOrDefault();
            Assert.IsTrue(firstMetro != null);
            Assert.IsTrue(firstBus != null);

            Assert.IsTrue(result.StatusCode == StatusCode.Ok);
            Assert.IsTrue(result.ResponseData.Buses.Count() == 1);
            Assert.IsTrue(!result.ResponseData.Ships.Any());
            Assert.IsTrue(result.ResponseData.Metros.Count() == 6);
            Assert.IsTrue(firstMetro.DisplayTime == "5 min");
            Assert.IsTrue(firstMetro.TransportModeEnum == TransportModeEnum.Metro);
            Assert.IsTrue(firstBus.TransportModeEnum == TransportModeEnum.Bus);

        }
    }
}

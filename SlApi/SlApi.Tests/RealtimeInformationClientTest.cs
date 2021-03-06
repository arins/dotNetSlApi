﻿using System;
using System.IO;
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
    [DeploymentItem("TestData\\RealtimeInformationClient\\success.json", "TestData\\RealtimeInformationClient")]
    public class RealtimeInformationClientTest : SlApiTest
    {

        public Stream GetTestResponse()
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(GetSampleResponse("TestData\\RealtimeInformationClient\\success.json"));
            sw.AutoFlush = true;
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        [TestMethod]
        public void RealtimeDeparturesTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = HttpRequestMocker.GetMockedRequesterFor(new Uri(
                            "https://api.sl.se/api2/realtimedepartures.json/?SiteId=9305&TimeWindow=2&key=" + fakekey), GetTestResponse());
            var t = new RealtimeInformationClient(new HttpClient("https://api.sl.se/", mockedHttpRequest, new UrlHelper()))
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
            var mockedHttpRequest = HttpRequestMocker.GetMockedRequesterFor(new Uri(
                            "https://api.sl.se/api2/realtimedepartures.json/?SiteId=9305&TimeWindow=2&key=" + fakekey), GetTestResponse());
            var t = new RealtimeInformationClient(new HttpClient("https://api.sl.se/", mockedHttpRequest, new UrlHelper()))
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

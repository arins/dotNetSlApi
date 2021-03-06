﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlApi.Core;
using SlApi.Models;
using SlApi.Models.NearbyStations.Request;

namespace SlApi.Tests
{
    [TestClass]
    [DeploymentItem("TestData\\NearbyStopsClient\\success.json", "TestData\\NearbyStopsClient")]
    [DeploymentItem("TestData\\NearbyStopsClient\\error.json", "TestData\\NearbyStopsClient")]
    public class NearbyStopsClientTest : SlApiTest
    {
       

        [TestMethod]
        public void NearbystopsTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = HttpRequestMocker.GetMockedRequesterFor(new Uri(
                            "https://api.sl.se/api2/nearbystops.json/?originCoordLat=59.365602&originCoordLong=17.998137&key=" + fakekey), GetNearbyStationDataForTest());
            var t = new NearbyStopsClient(new HttpClient("https://api.sl.se/", mockedHttpRequest, new UrlHelper())
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
            Assert.IsTrue(Math.Abs(result.LocationList.StopLocation[0].Lat - 59.365571) < 0.0001);
        }

        [TestMethod]
        public void SitesAsyncTest()
        {
            var fakekey = "fakekey";
            var mockedHttpRequest = HttpRequestMocker.GetMockedRequesterFor(new Uri(
                "https://api.sl.se/api2/nearbystops.json/?originCoordLat=59.365602&originCoordLong=17.998137&key=" +
                fakekey), GetNearbyStationDataForTest());
            var t = new NearbyStopsClient(new HttpClient("https://api.sl.se/", mockedHttpRequest, new UrlHelper())
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
            Assert.IsTrue(Math.Abs(result.LocationList.StopLocation[0].Lat - 59.365571) < 0.0001);

        }


        [TestMethod]
        public void NearbyStopsErrorTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = HttpRequestMocker.GetMockedRequesterFor(new Uri(
                            "https://api.sl.se/api2/nearbystops.json/?originCoordLat=59.365602&originCoordLong=17.998137&key=" + fakekey), GetNearbyStationsErrorDataForTest());
            var t = new NearbyStopsClient(new HttpClient("https://api.sl.se/", mockedHttpRequest, new UrlHelper())
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


        public Stream GetNearbyStationsErrorDataForTest()
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(GetSampleResponse("TestData\\NearbyStopsClient\\error.json"));
            sw.AutoFlush = true;
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }


        public Stream GetNearbyStationDataForTest()
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(GetSampleResponse("TestData\\NearbyStopsClient\\success.json"));
            sw.AutoFlush = true;
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
    }
}

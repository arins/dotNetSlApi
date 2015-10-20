using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SlApi.Core;
using SlApi.Models;
using SlApi.Models.TravelPlanner.Request;

namespace SlApi.Tests
{
    [TestClass]
    [DeploymentItem("TestData\\TravelPlannerClient\\success.json", "TestData\\TravelPlannerClient")]
    [DeploymentItem("TestData\\TravelPlannerClient\\success-multizonetest.json", "TestData\\TravelPlannerClient")]
    [DeploymentItem("TestData\\TravelPlannerClient\\error.json", "TestData\\TravelPlannerClient")]
    [DeploymentItem("TestData\\GeometryClient\\testData.json", "TestData\\GeometryClient")]
    public class TravelPlannerClientTest : SlApiTest
    {

        

        [TestMethod]
        public void TripTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = HttpRequestMocker.GetMockedRequesterFor(new Uri(
                            "https://api.sl.se/api2/TravelplannerV2/trip.json/?date=2015-09-07&time=22:00&originId=9305&destId=9001&key=" + fakekey), GetTestResponse());
            var t = new TravelPlannerClient(new HttpClient("https://api.sl.se/", mockedHttpRequest, new UrlHelper())
            {
                ApiToken = fakekey
            });
            var result = t.Trip(new TripRequest {DateTime = new DateTime(2015,9, 7,22,0,0,DateTimeKind.Local),OriginId = "9305", DestId = "9001" });
            var f = result.TripList.Trip.FirstOrDefault();
            Assert.IsTrue(f != null);
            var leg = f.LegList.Leg.FirstOrDefault();
            Assert.IsTrue(leg != null);
            Assert.IsTrue(leg.Direction == "Kungsträdgården");

        }

        [TestMethod]
        public void TripAsyncTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = HttpRequestMocker.GetMockedRequesterFor(new Uri(
                            "https://api.sl.se/api2/TravelplannerV2/trip.json/?date=2015-09-07&time=22:00&originId=9305&destId=9001&key=" +
                            fakekey), GetTestResponse());
            
            var t = new TravelPlannerClient(new HttpClient("https://api.sl.se/", mockedHttpRequest, new UrlHelper())
            {
                ApiToken = fakekey
            });


            var resultAsync =
                t.TripAsync(new TripRequest
                {
                    DateTime = new DateTime(2015, 9, 7, 22, 0, 0, DateTimeKind.Local),
                    OriginId = "9305",
                    DestId = "9001"
                });
            resultAsync.Wait();
            var result = resultAsync.Result;
            var f = result.TripList.Trip.FirstOrDefault();

            Assert.IsTrue(f != null);
            var leg = f.LegList.Leg.FirstOrDefault();
            Assert.IsTrue(leg != null);
            Assert.IsTrue(leg.Direction == "Kungsträdgården");
        }


        [TestMethod]
        public void TripMultiZoneAsyncTest()
        {
            var fakekey = "fakekey";
            var mockedHttpRequest = HttpRequestMocker.GetMockedRequesterFor(new Uri(
                            "https://api.sl.se/api2/TravelplannerV2/trip.json/?date=2015-09-09&time=22:00&originId=9305&destId=9001&key=" +
                            fakekey), GetMultiZoneTest());
            var t = new TravelPlannerClient(new HttpClient("https://api.sl.se/", mockedHttpRequest, new UrlHelper())
            {
                ApiToken = fakekey
            });
            var resultAsync =
                t.TripAsync(new TripRequest
                {
                    DateTime = new DateTime(2015, 9, 9, 22, 0, 0, DateTimeKind.Local),
                    OriginId = "9305",
                    DestId = "9001"
                });
            resultAsync.Wait();
            var result = resultAsync.Result;
            var f = result.TripList.Trip.FirstOrDefault();

            Assert.IsTrue(f != null);
            var leg = f.LegList.Leg.FirstOrDefault();
            Assert.IsTrue(leg != null);
            Assert.IsTrue(leg.Direction == "Solna station");
            Assert.IsTrue(leg.Origin.Name == "Solna centrum");
        }

        [TestMethod]
        public void TripErrorResponseAsyncTest()
        {
            var fakekey = "fakekey";
            var mockedHttpRequest = HttpRequestMocker.GetMockedRequesterFor(new Uri(
                            "https://api.sl.se/api2/TravelplannerV2/trip.json/?date=2015-09-09&time=22:00&originId=9305&destId=9001&key=" +
                            fakekey), GetErrorResponse());
            var t = new TravelPlannerClient(new HttpClient("https://api.sl.se/", mockedHttpRequest, new UrlHelper())
            {
                ApiToken = fakekey
            });


            var resultAsync =
                t.TripAsync(new TripRequest
                {
                    DateTime = new DateTime(2015, 9, 9, 22, 0, 0, DateTimeKind.Local),
                    OriginId = "9305",
                    DestId = "9001"
                });
            resultAsync.Wait();
            var result = resultAsync.Result;
           Assert.IsTrue(result.StatusCode == StatusCode.KeyIsInvalid2);

            
        }

        [TestMethod]
        
        public void GeometryTest()
        {

            var fakekey = "fakekey";
            var journeref = "873021%2F296594%2F776520%2F97255%2F74%26startIdx%3D7%26endIdx%3D8%26lang%3Dsv%26format%3Djson%26";

            var httpRequest = HttpRequestMocker.GetMockedRequesterFor(
                new Uri(
                    "https://api.sl.se/api2/TravelplannerV2/geometry.json/?ref=" + journeref + "&key=" +
                    fakekey),

                GetGeometryResponseSample());
            var t = new TravelPlannerClient(new HttpClient("https://api.sl.se/", httpRequest, new UrlHelper())
            {
                ApiToken = fakekey
            });
            var result = t.Geometry(new GeometryRequest { Ref = journeref });
            var point = result.Geometry.Points.Point.FirstOrDefault();
            Assert.IsTrue(point != null);
            Assert.IsTrue(Math.Abs(point.Latitude - 59.361337) < 0.001);
            Assert.IsTrue(Math.Abs(point.Longitude - 17.996278) < 0.001);

        }


        [TestMethod]
        public void JourneydetailAsyncTest()
        {

            var fakekey = "fakekey";
            var journeref = "873021%2F296594%2F776520%2F97255%2F74%26startIdx%3D7%26endIdx%3D8%26lang%3Dsv%26format%3Djson%26";
            var mockedHttpRequest = HttpRequestMocker.GetMockedRequesterFor(
               new Uri("https://api.sl.se/api2/TravelplannerV2/geometry.json/?ref=" + journeref + "&key=" +
                            fakekey),

               GetGeometryResponseSample());
            var t = new TravelPlannerClient(new HttpClient("https://api.sl.se/", mockedHttpRequest, new UrlHelper())
            {
                ApiToken = fakekey
            });
            var resultAwait = t.GeometryAsync(new GeometryRequest { Ref = journeref });
            resultAwait.Wait();
            var result = resultAwait.Result;
            var point = result.Geometry.Points.Point.FirstOrDefault();
            Assert.IsTrue(point != null);
            Assert.IsTrue(Math.Abs(point.Latitude - 59.361337) < 0.001);
            Assert.IsTrue(Math.Abs(point.Longitude - 17.996278) < 0.001);


        }

        public Stream GetGeometryResponseSample()
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(GetSampleResponse("TestData\\GeometryClient\\testData.json"));
            sw.AutoFlush = true;
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public Stream GetErrorResponse()
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(GetSampleResponse("TestData\\TravelPlannerClient\\error.json"));
            sw.AutoFlush = true;
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public Stream GetTestResponse()
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(GetSampleResponse("TestData\\TravelPlannerClient\\success.json"));
            sw.AutoFlush = true;
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        public Stream GetMultiZoneTest()
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(GetSampleResponse("TestData\\TravelPlannerClient\\success-multizonetest.json"));
            sw.AutoFlush = true;
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
    }
}

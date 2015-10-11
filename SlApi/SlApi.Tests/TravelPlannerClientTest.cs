using System;
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
    public class TravelPlannerClientTest : SlApiTest
    {

        

        [TestMethod]
        public void TripTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/TravelplannerV2/trip.json/?date=2015-09-07&time=22:00&originId=9305&destId=9001&key=" + fakekey)))
                .Returns(GetTestResponse);
            var t = new TravelPlannerClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper())
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
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/TravelplannerV2/trip.json/?date=2015-09-07&time=22:00&originId=9305&destId=9001&key=" +
                            fakekey)))
                .ReturnsAsync(GetTestResponse());
            var t = new TravelPlannerClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper())
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
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/TravelplannerV2/trip.json/?date=2015-09-09&time=22:00&originId=9305&destId=9001&key=" +
                            fakekey)))
                .ReturnsAsync(GetMultiZoneTest());
            var t = new TravelPlannerClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper())
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
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/TravelplannerV2/trip.json/?date=2015-09-09&time=22:00&originId=9305&destId=9001&key=" +
                            fakekey)))
                .ReturnsAsync(GetErrorResponse());
            var t = new TravelPlannerClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper())
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

        public string GetErrorResponse()
        {
            return GetSampleResponse("TestData\\TravelPlannerClient\\error.json");
        }

        public string GetTestResponse()
        {
            return GetSampleResponse("TestData\\TravelPlannerClient\\success.json");

        }

        private string GetMultiZoneTest()
            {
                return GetSampleResponse("TestData\\TravelPlannerClient\\success-multizonetest.json");
        }
    }
}

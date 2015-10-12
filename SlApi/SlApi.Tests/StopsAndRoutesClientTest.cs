using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SlApi.Core;
using SlApi.Models.StopsAndRoutes.Response;

namespace SlApi.Tests
{
    [TestClass]
    [DeploymentItem("TestData\\StopsAndRoutesClient\\Sites\\success.json", "TestData\\StopsAndRoutesClient\\Sites")]
    [DeploymentItem("TestData\\StopsAndRoutesClient\\StopPoints\\success.json", "TestData\\StopsAndRoutesClient\\StopPoints")]
    [DeploymentItem("TestData\\StopsAndRoutesClient\\Lines\\success.json", "TestData\\StopsAndRoutesClient\\Lines")]
    [DeploymentItem("TestData\\StopsAndRoutesClient\\TransportMode\\success.json", "TestData\\StopsAndRoutesClient\\TransportMode")]
    [DeploymentItem("TestData\\StopsAndRoutesClient\\Jour\\success.json", "TestData\\StopsAndRoutesClient\\Jour")]
    public class StopsAndRoutesClientTest : SlApiTest
    {
       

        [TestMethod]
        public void SitesTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/LineData.json/?model=site&key=" + fakekey)))
                .Returns(GetTestResponseForSites);
            var t = new StopsAndRoutesClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };

          
            var result = t.Sites();
            Assert.IsTrue(result.ExecutionTime == 686);
            Assert.IsTrue(result.ResponseData.Result.Length == 25);
            Assert.IsTrue(result.ResponseData.Result[0].SiteId == 4432);
            Assert.IsTrue(result.ResponseData.Result[24].SiteId == 9248);
            

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
                            "https://api.sl.se/api2/LineData.json/?model=site&key=" + fakekey)))
                .ReturnsAsync(GetTestResponseForSites());
            var t = new StopsAndRoutesClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };


            var responseAsync = t.SitesAsync();
            responseAsync.Wait();
            var result = responseAsync.Result;
            Assert.IsTrue(result.ExecutionTime == 686);
            Assert.IsTrue(result.ResponseData.Result.Length == 25);
            Assert.IsTrue(result.ResponseData.Result[0].SiteId == 4432);
            Assert.IsTrue(result.ResponseData.Result[24].SiteId == 9248);

        }





        [TestMethod]
        public void StopPointsTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/LineData.json/?model=stopPoint&key=" + fakekey)))
                .Returns(GetTestResponseForStopPoints);
            var t = new StopsAndRoutesClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };


            var result = t.StopPoints();
            Assert.IsTrue(result.ExecutionTime == 792);
            Assert.IsTrue(result.ResponseData.Result.Length == 13);
            Assert.IsTrue(result.ResponseData.Result[0].StopPointNumber == 10001);
            Assert.IsTrue(result.ResponseData.Result[12].StopPointNumber == 10015);


        }


        [TestMethod]
        public void StopPointsAsyncTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/LineData.json/?model=stopPoint&key=" + fakekey)))
                .ReturnsAsync(GetTestResponseForStopPoints());
            var t = new StopsAndRoutesClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };


            var responseAsync = t.StopPointsAsync();
            responseAsync.Wait();
            var result = responseAsync.Result;
            Assert.IsTrue(result.ExecutionTime == 792);
            Assert.IsTrue(result.ResponseData.Result.Length == 13);
            Assert.IsTrue(result.ResponseData.Result[0].StopPointNumber == 10001);
            Assert.IsTrue(result.ResponseData.Result[12].StopPointNumber == 10015);

        }


        [TestMethod]
        public void LinesTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/LineData.json/?model=line&key=" + fakekey)))
                .Returns(GetTestResponseForLines);
            var t = new StopsAndRoutesClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };


            var result = t.Lines();
            Assert.IsTrue(result.ExecutionTime == 717);
            Assert.IsTrue(result.ResponseData.Result.Length == 29);
            Assert.IsTrue(result.ResponseData.Result[0].LineNumber == 1);
            Assert.IsTrue(result.ResponseData.Result[0].DefaultTransportMode == "blåbuss");
            Assert.IsTrue(result.ResponseData.Result[0].DefaultTransportModeCode == DefaultTransportModeCode.Metro);
            Assert.IsTrue(result.ResponseData.Result[28].LineNumber == 142);



        }


        [TestMethod]
        public void LinesAsyncTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/LineData.json/?model=line&key=" + fakekey)))
                .ReturnsAsync(GetTestResponseForLines());
            var t = new StopsAndRoutesClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };


            var responseAsync = t.LinesAsync();
            responseAsync.Wait();
            var result = responseAsync.Result;
            Assert.IsTrue(result.ExecutionTime == 717);
            Assert.IsTrue(result.ResponseData.Result.Length == 29);
            Assert.IsTrue(result.ResponseData.Result[0].LineNumber == 1);
            Assert.IsTrue(result.ResponseData.Result[0].DefaultTransportMode == "blåbuss");
            Assert.IsTrue(result.ResponseData.Result[0].DefaultTransportModeCode == DefaultTransportModeCode.Metro);
            Assert.IsTrue(result.ResponseData.Result[28].LineNumber == 142);

        }



        [TestMethod]
        public void TransportModeTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/LineData.json/?model=tran&key=" + fakekey)))
                .Returns(GetTestTransportMode);
            var t = new StopsAndRoutesClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };


            var result = t.TransportModes();
            Assert.IsTrue(result.ExecutionTime == 613);
            Assert.IsTrue(result.ResponseData.Result.Length == 6);
            Assert.IsTrue(result.ResponseData.Result[0].DefaultTransportModeCode == DefaultTransportModeCode.Bus);
            Assert.IsTrue(result.ResponseData.Result[0].DefaultTransportMode == "buss");
            Assert.IsTrue(result.ResponseData.Result[0].StopAreaTypeCode == StopAreaTypeCode.Busterm);



        }


        [TestMethod]
        public void TransportModeAsyncTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/LineData.json/?model=tran&key=" + fakekey)))
                .ReturnsAsync(GetTestTransportMode());
            var t = new StopsAndRoutesClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };


            var responseAsync = t.TransportModesAsync();
            responseAsync.Wait();
            var result = responseAsync.Result;
            Assert.IsTrue(result.ExecutionTime == 613);
            Assert.IsTrue(result.ResponseData.Result.Length == 6);
            Assert.IsTrue(result.ResponseData.Result[0].DefaultTransportModeCode == DefaultTransportModeCode.Bus);
            Assert.IsTrue(result.ResponseData.Result[0].DefaultTransportMode == "buss");
            Assert.IsTrue(result.ResponseData.Result[0].StopAreaTypeCode == StopAreaTypeCode.Busterm);

        }



        [TestMethod]
        public void JourneyPaternPointOnLineTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/LineData.json/?model=jour&key=" + fakekey)))
                .Returns(GetJourTest);
            var t = new StopsAndRoutesClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };


            var result = t.JourneyPaternPointOnLine();
            Assert.IsTrue(result.ExecutionTime == 872);
            Assert.IsTrue(result.ResponseData.Result.Length == 11);
            Assert.IsTrue(result.ResponseData.Result[0].DirectionCode == 1);
            Assert.IsTrue(result.ResponseData.Result[0].LineNumber == 1);
            Assert.IsTrue(result.ResponseData.Result[0].ExistsFromDate == new DateTime(2012, 06, 23));



        }


        [TestMethod]
        public void JourneyPaternPointOnLineAsyncTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/LineData.json/?model=jour&key=" + fakekey)))
                .ReturnsAsync(GetJourTest());
            var t = new StopsAndRoutesClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };


            var responseAsync = t.JourneyPaternPointOnLineAsync();
            responseAsync.Wait();
            var result = responseAsync.Result;

            Assert.IsTrue(result.ExecutionTime == 872);
            Assert.IsTrue(result.ResponseData.Result.Length == 11);
            Assert.IsTrue(result.ResponseData.Result[0].DirectionCode == 1);
            Assert.IsTrue(result.ResponseData.Result[0].LineNumber == 1);
            Assert.IsTrue(result.ResponseData.Result[0].ExistsFromDate == new DateTime(2012, 06, 23));
        }


        public string GetTestResponseForLines()
        {
            return GetSampleResponse("TestData\\StopsAndRoutesClient\\Lines\\success.json");

        }

        public string GetTestResponseForStopPoints()
        {
            return GetSampleResponse("TestData\\StopsAndRoutesClient\\StopPoints\\success.json");
        }

        public string GetTestResponseForSites()
        {
            return GetSampleResponse("TestData\\StopsAndRoutesClient\\Sites\\success.json");
        }

        public string GetTestTransportMode()
        {
            return GetSampleResponse("TestData\\StopsAndRoutesClient\\TransportMode\\success.json");

        }

        public string GetJourTest()
        {
            return GetSampleResponse("TestData\\StopsAndRoutesClient\\Jour\\success.json");

        }
    }
}

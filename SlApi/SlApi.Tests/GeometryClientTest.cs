
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SlApi.Core;
using SlApi.Models.TravelPlanner.Request;


namespace SlApi.Tests
{
    [TestClass]
    public class GeometryClientTest : SlApiTest
    {

        
        
        [TestMethod]
        public void GeometryTest()
        {
            
            var fakekey = "fakekey";
            var journeref = "873021%2F296594%2F776520%2F97255%2F74%26startIdx%3D7%26endIdx%3D8%26lang%3Dsv%26format%3Djson%26";

            var httpRequest = HttpRequestMocker.GetMockedRequesterFor(
                new Uri(
                    "https://api.sl.se/api2/TravelplannerV2/geometry.json/?ref=" + journeref + "&key=" +
                    fakekey),

                GetResponse());
            

            
            var t = new TravelPlannerClient(new HttpClient("https://api.sl.se/", httpRequest, new UrlHelper())
            {
                ApiToken = fakekey
            });

            
            

            var result = t.Geometry(new GeometryRequest {Ref = journeref});
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
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/TravelplannerV2/geometry.json/?ref=" + journeref + "&key=" +
                            fakekey)))
                .ReturnsAsync(GetResponse());
            var t = new TravelPlannerClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper())
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


        public string GetResponse()
        {
            return "{" +
                   "\"Geometry\":{" +
                   "  \"noNamespaceSchemaLocation\":\"hafasRestGeometry.xsd\"," +
                   "  \"Points\":{" +
                   "    \"Point\":[{" +
                   "      \"lat\":\"59.361337\"," +
                   "      \"lon\":\"17.996278\"" +
                   "      },{" +
                   "      \"lat\":\"59.363746\"," +
                   "      \"lon\":\"18.008198\"" +
                   "      }]" +
                   "    }" +
                   "  }" +
                   "}";
        }
    }
}

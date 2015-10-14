using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlApi.Core;
using SlApi.Models.TravelPlanner.Request;

namespace SlApi.Tests
{
    [TestClass]
    [DeploymentItem("TestData\\JourneyDetailClient\\success.json", "TestData\\JourneyDetailClient")]
    public class JourneyDetailClientTest : SlApiTest
    {


        
        [TestMethod]
        public void JourneyDetailTest()
        {

            var fakekey = "fakekey";
            var journeref = "773439%2F263400%2F652690%2F68534%2F74%3Fdate%3D2015-09-13%26station_evaId%3D400104547%26station_type%3Ddep%26lang%3Dsv%26format%3Djson%26";
            var mockedHttpRequest = HttpRequestMocker.GetMockedRequesterFor(new Uri(
                "https://api.sl.se/api2/TravelplannerV2/journeydetail.json/?ref=" + journeref + "&key=" +
                fakekey), GetTestResponse());
            var t = new TravelPlannerClient(new HttpClient("https://api.sl.se/", mockedHttpRequest, new UrlHelper())
            {
                ApiToken = fakekey
            });
            

            var result = t.JourneyDetail(new JourneyRequest {Ref = journeref});
            Assert.IsTrue(result.JourneyDetail.NoNamespaceSchemaLocation == "hafasRestJourneyDetail.xsd");
            Assert.IsTrue(result.JourneyDetail.Stops.Stop.Count == 9);
            var f = result.JourneyDetail.Stops.Stop.FirstOrDefault();
            Assert.IsTrue(f != null);
            Assert.IsTrue(!f.ArrivalDateTime.HasValue);
            Assert.IsTrue(f.DepartureDateTime.HasValue);
            Assert.IsTrue(f.DepartureDateTime.Value.Hour == 22);
            Assert.IsTrue(f.DepartureDateTime.Value.Minute == 16);
            Assert.IsTrue(f.DepartureDateTime.Value.Month == 9);
            Assert.IsTrue(f.DepartureDateTime.Value.Day == 13);
            var direction = result.JourneyDetail.Directions.Direction.FirstOrDefault();
            Assert.IsTrue(direction != null);
            Assert.IsTrue(direction.Text == "Solna station");
            Assert.IsTrue(direction.RouteIdxTo == 8);

            var line = result.JourneyDetail.Lines.Line.FirstOrDefault();
            Assert.IsTrue(line != null);
            Assert.IsTrue(line.Text == "22");
            Assert.IsTrue(line.RouteIdxTo == 8);


            var type = result.JourneyDetail.Types.Type.FirstOrDefault();
            Assert.IsTrue(type != null);
            Assert.IsTrue(type.Text == "TRAM");
            Assert.IsTrue(type.RouteIdxTo == 8);

            var message = result.JourneyDetail.RtuMessages.RtuMessage.FirstOrDefault();
            Assert.IsTrue(message != null);
            Assert.IsTrue(message.Text == "Buss mellan Alvik och Solna station");
        }


        public void JourneydetailAsyncTest()
        {

            var fakekey = "fakekey";
            var journeref = "773439%2F263400%2F652690%2F68534%2F74%3Fdate%3D2015-09-13%26station_evaId%3D400104547%26station_type%3Ddep%26lang%3Dsv%26format%3Djson%26";
            var mockedHttpRequest = HttpRequestMocker.GetMockedRequesterFor(new Uri(
                            "https://api.sl.se/api2/TravelplannerV2/journeydetail.json/?ref=" + journeref + "&key=" +
                            fakekey), GetTestResponse());
            
            var t = new TravelPlannerClient(new HttpClient("https://api.sl.se/", mockedHttpRequest, new UrlHelper())
            {
                ApiToken = fakekey
            });


            var resultAwait = t.JourneyDetailAsync(new JourneyRequest { Ref = journeref });
            resultAwait.Wait(1000);
            Assert.IsTrue(resultAwait.IsCompleted);
            var result = resultAwait.Result;
            Assert.IsTrue(result.JourneyDetail.NoNamespaceSchemaLocation == "hafasRestJourneyDetail.xsd");
            Assert.IsTrue(result.JourneyDetail.Stops.Stop.Count == 9);
            var f = result.JourneyDetail.Stops.Stop.FirstOrDefault();
            Assert.IsTrue(f != null);
            Assert.IsTrue(!f.ArrivalDateTime.HasValue);
            Assert.IsTrue(f.DepartureDateTime.HasValue);
            Assert.IsTrue(f.DepartureDateTime.Value.Hour == 22);
            Assert.IsTrue(f.DepartureDateTime.Value.Minute == 16);
            Assert.IsTrue(f.DepartureDateTime.Value.Month == 9);
            Assert.IsTrue(f.DepartureDateTime.Value.Day == 13);
            var direction = result.JourneyDetail.Directions.Direction.FirstOrDefault();
            Assert.IsTrue(direction != null);
            Assert.IsTrue(direction.Text == "Solna station");
            Assert.IsTrue(direction.RouteIdxTo == 8);

            var line = result.JourneyDetail.Lines.Line.FirstOrDefault();
            Assert.IsTrue(line != null);
            Assert.IsTrue(line.Text == "22");
            Assert.IsTrue(line.RouteIdxTo == 8);


            var type = result.JourneyDetail.Types.Type.FirstOrDefault();
            Assert.IsTrue(type != null);
            Assert.IsTrue(type.Text == "TRAM");
            Assert.IsTrue(type.RouteIdxTo == 8);

            var message = result.JourneyDetail.RtuMessages.RtuMessage.FirstOrDefault();
            Assert.IsTrue(message != null);
            Assert.IsTrue(message.Text == "Buss mellan Alvik och Solna station");
        }



        public Stream GetTestResponse()
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(GetSampleResponse("TestData\\JourneyDetailClient\\success.json"));
            sw.AutoFlush = true;
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

    }
}

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SlApi.Core;
using SlApi.Models.TravelPlanner.Request;
using SlApi.Models.TravelPlanner.Response;

namespace SlApi.Tests
{
    [TestClass]
    public class JourneyDetailClientTest
    {


        
        [TestMethod]
        public void JourneyDetailTest()
        {

            var fakekey = "fakekey";
            var journeref = "773439%2F263400%2F652690%2F68534%2F74%3Fdate%3D2015-09-13%26station_evaId%3D400104547%26station_type%3Ddep%26lang%3Dsv%26format%3Djson%26";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/TravelplannerV2/journeydetail.json/?ref=" + journeref + "&key=" +
                            fakekey)))
                .Returns(GetTestResponse);
            var t = new TravelPlannerClient(new HttpClient(mockedHttpRequest.Object)
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
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/TravelplannerV2/journeydetail.json/?ref=" + journeref + "&key=" +
                            fakekey)))
                .ReturnsAsync(GetTestResponse());
            var t = new TravelPlannerClient(new HttpClient(mockedHttpRequest.Object)
            {
                ApiToken = fakekey
            });


            var resultAwait = t.JourneyDetailAsync(new JourneyRequest { Ref = journeref });
            resultAwait.WaitUntilDoneWithTimeoutAsync(1000);
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



        public string GetTestResponse()
        {
            return "{" +
                   "\"JourneyDetail\":{" +
                   "  \"noNamespaceSchemaLocation\":\"hafasRestJourneyDetail.xsd\"," +
                   "  \"Stops\":{" +
                   "    \"Stop\":[{" +
                   "      \"name\":\"Alvik\"," +
                   "      \"id\":\"400104526\"," +
                   "      \"lon\":\"17.980151\"," +
                   "      \"lat\":\"59.333479\"," +
                   "      \"routeIdx\":\"0\"," +
                   "      \"depTime\":\"22:16\"," +
                   "      \"depDate\":\"2015-09-13\"" +
                   "      },{" +
                   "      \"name\":\"Johannesfred\"," +
                   "      \"id\":\"400104535\"," +
                   "      \"lon\":\"17.969769\"," +
                   "      \"lat\":\"59.342738\"," +
                   "      \"routeIdx\":\"1\"," +
                   "      \"arrTime\":\"22:18\"," +
                   "      \"arrDate\":\"2015-09-13\"," +
                   "      \"depTime\":\"22:18\"," +
                   "      \"depDate\":\"2015-09-13\"" +
                   "      },{" +
                   "      \"name\":\"Norra Ulvsunda\"," +
                   "      \"id\":\"400104537\"," +
                   "      \"lon\":\"17.961876\"," +
                   "      \"lat\":\"59.350730\"," +
                   "      \"routeIdx\":\"2\"," +
                   "      \"arrTime\":\"22:20\"," +
                   "      \"arrDate\":\"2015-09-13\"," +
                   "      \"depTime\":\"22:20\"," +
                   "      \"depDate\":\"2015-09-13\"" +
                   "      },{" +
                   "      \"name\":\"Karlsbodavägen\"," +
                   "      \"id\":\"400104539\"," +
                   "      \"lon\":\"17.961418\"," +
                   "      \"lat\":\"59.356402\"," +
                   "      \"routeIdx\":\"3\"," +
                   "      \"arrTime\":\"22:22\"," +
                   "      \"arrDate\":\"2015-09-13\"," +
                   "      \"depTime\":\"22:22\"," +
                   "      \"depDate\":\"2015-09-13\"" +
                   "      },{" +
                   "      \"name\":\"Bällsta bro\"," +
                   "      \"id\":\"400104541\"," +
                   "      \"lon\":\"17.961472\"," +
                   "      \"lat\":\"59.360240\"," +
                   "      \"routeIdx\":\"4\"," +
                   "      \"arrTime\":\"22:23\"," +
                   "      \"arrDate\":\"2015-09-13\"," +
                   "      \"depTime\":\"22:23\"," +
                   "      \"depDate\":\"2015-09-13\"" +
                   "      },{" +
                   "      \"name\":\"Sundbybergs centrum\"," +
                   "      \"id\":\"400104543\"," +
                   "      \"lon\":\"17.970524\"," +
                   "      \"lat\":\"59.360914\"," +
                   "      \"routeIdx\":\"5\"," +
                   "      \"arrTime\":\"22:24\"," +
                   "      \"arrDate\":\"2015-09-13\"," +
                   "      \"depTime\":\"22:24\"," +
                   "      \"depDate\":\"2015-09-13\"" +
                   "      },{" +
                   "      \"name\":\"Solna Business Park\"," +
                   "      \"id\":\"400104545\"," +
                   "      \"lon\":\"17.978785\"," +
                   "      \"lat\":\"59.359755\"," +
                   "      \"routeIdx\":\"6\"," +
                   "      \"arrTime\":\"22:26\"," +
                   "      \"arrDate\":\"2015-09-13\"," +
                   "      \"depTime\":\"22:26\"," +
                   "      \"depDate\":\"2015-09-13\"" +
                   "      },{" +
                   "      \"name\":\"Solna centrum\"," +
                   "      \"id\":\"400104547\"," +
                   "      \"lon\":\"17.996278\"," +
                   "      \"lat\":\"59.361337\"," +
                   "      \"routeIdx\":\"7\"," +
                   "      \"arrTime\":\"22:28\"," +
                   "      \"arrDate\":\"2015-09-13\"," +
                   "      \"depTime\":\"22:28\"," +
                   "      \"depDate\":\"2015-09-13\"" +
                   "      },{" +
                   "      \"name\":\"Solna station\"," +
                   "      \"id\":\"400104550\"," +
                   "      \"lon\":\"18.008198\"," +
                   "      \"lat\":\"59.363746\"," +
                   "      \"routeIdx\":\"8\"," +
                   "      \"arrTime\":\"22:32\"," +
                   "      \"arrDate\":\"2015-09-13\"" +
                   "      }]" +
                   "    }," +
                   "  \"GeometryRef\":{" +
                   "    \"ref\":\"ref%3D774192%2F263651%2F241060%2F137536%2F74%26lang%3Dsv%26format%3Djson%26\"" +
                   "    }," +
                   "  \"Names\":{" +
                   "    \"Name\":{" +
                   "      \"routeIdxFrom\":\"0\"," +
                   "      \"routeIdxTo\":\"8\"," +
                   "      \"$\":\"Tvärbanan 22\"" +
                   "      }" +
                   "    }," +
                   "  \"Types\":{" +
                   "    \"Type\":{" +
                   "      \"routeIdxFrom\":\"0\"," +
                   "      \"routeIdxTo\":\"8\"," +
                   "      \"$\":\"TRAM\"" +
                   "      }" +
                   "    }," +
                   "  \"Lines\":{" +
                   "    \"Line\":{" +
                   "      \"routeIdxFrom\":\"0\"," +
                   "      \"routeIdxTo\":\"8\"," +
                   "      \"$\":\"22\"" +
                   "      }" +
                   "    }," +
                   "  \"Directions\":{" +
                   "    \"Direction\":{" +
                   "      \"routeIdxFrom\":\"0\"," +
                   "      \"routeIdxTo\":\"8\"," +
                   "      \"$\":\"Solna station\"" +
                   "      }" +
                   "    }," +
                   "  \"RTUMessages\":{" +
                   "    \"RTUMessage\":{" +
                   "      \"$\":\"Buss mellan Alvik och Solna station\"" +
                   "      }" +
                   "    }" +
                   "  }" +
                   "}";

        }

    }
}

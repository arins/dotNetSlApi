using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SlApi.Core;
using SlApi.Models.TravelPlanner.Request;

namespace SlApi.Tests
{
    [TestClass]
    public class JourneydetailTest
    {


        [Ignore]
        [TestMethod]
        public void JourneydetailTestTest()
        {

            var fakekey = "fakekey";
            var journeref = "";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/TravelplannerV2/journeydetail.json/?&ref=" + journeref + "&key=" +
                            fakekey)))
                .Returns(GetTestResponse);
            var t = new TravelPlannerClient(new HttpClient(mockedHttpRequest.Object)
            {
                ApiToken = fakekey
            });


            var result = t.JourneyDetail(new JourneyRequest {Ref = journeref});



        }



        public string GetTestResponse()
        {
            return "";

        }

    }
}

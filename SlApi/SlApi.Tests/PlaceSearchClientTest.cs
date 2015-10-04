using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SlApi.General.Core;
using SlApi.General.Models;
using SlApi.General.Models.PlaceSearch.Request;

namespace SlApi.Tests
{
    [TestClass]
    public class PlaceSearchClientTest
    {

        public string GetTestResponse()
        {
            return
                "{\"StatusCode\":0,\"Message\":null,\"ExecutionTime\":0,\"ResponseData\":" +
                "[{\"Name\":\"Solna (Solna)\",\"SiteId\":\"9509\",\"Type\":\"Station\",\"X\":" +
                "\"18011865\",\"Y\":\"59364312\"},{\"Name\":\"Solna station (Solna)\",\"SiteId\":" +
                "\"9509\",\"Type\":\"Station\",\"X\":\"18011865\",\"Y\":\"59364312\"},{\"Name\":" +
                "\"Solna centrum (Solna)\",\"SiteId\":\"9305\",\"Type\":\"Station\",\"X\":" +
                "\"17997554\",\"Y\":\"59358676\"},{\"Name\":\"Solna centrum norra (Solna)\"," +
                "\"SiteId\":\"3472\",\"Type\":\"Station\",\"X\":\"17999775\",\"Y\":\"59361696\"}," +
                "{\"Name\":\"Solna strand (Solna)\",\"SiteId\":\"9326\",\"Type\":\"Station\",\"X\":" +
                "\"17974380\",\"Y\":\"59353498\"},{\"Name\":\"Solna Business Park (Solna)\",\"SiteId\":" +
                "\"5119\",\"Type\":\"Station\",\"X\":\"17979720\",\"Y\":\"59359476\"},{\"Name\":\"Solna " +
                "centrum (CentralvÃ¤gen)  (Solna)\",\"SiteId\":\"9954\",\"Type\":\"Station\",\"X\":\"18002283\"," +
                "\"Y\":\"59358658\"},{\"Name\":\"Solna kyrka (Solna)\",\"SiteId\":\"3409\",\"Type\":\"Station\"," +
                "\"X\":\"18024288\",\"Y\":\"59353822\"},{\"Name\":\"Solna stadshus (Solna)\",\"SiteId\":\"3463\"," +
                "\"Type\":\"Station\",\"X\":\"18004602\",\"Y\":\"59359162\"},{\"Name\":\"Solna tenniscenter (Solna)\"," +
                "\"SiteId\":\"3402\",\"Type\":\"Station\",\"X\":\"17986731\",\"Y\":\"09375783\"}]}";
        }

        [TestMethod]
        public void Search()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/typeahead.json/?SearchString=Solna&StationsOnly=false&key=" + fakekey)))
                .Returns(GetTestResponse);
            var search = new PlaceSearchClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };


            var result = search.Search(new PlaceSearchRequest
            {
                SearchString = "Solna",
                StationsOnly = false
            });
            Assert.IsTrue(result.ResponseData.Count() == 10);
            Assert.IsTrue(result.StatusCode == StatusCode.Ok);
            var first = result.ResponseData.FirstOrDefault();
            var last = result.ResponseData.LastOrDefault();
            Assert.IsTrue(first != null);
            Assert.IsTrue(last != null);
            Assert.IsTrue(last != first);

            Assert.IsTrue(first.Name.Equals("Solna (Solna)"));
            Assert.IsTrue(first.X == "18011865");
            Assert.IsTrue(first.Y == "59364312");
            Assert.IsTrue(first.Latitude == 18.011865);
            Assert.IsTrue(first.Longitude == 59.364312);
            Assert.IsTrue(first.SiteId.Equals(9509));

            Assert.IsTrue(last.Latitude == 17.986731);
            Assert.IsTrue(last.Longitude == 9.375783);
        }

        [TestMethod]
        public void SearchAsync()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/typeahead.json/?SearchString=Solna&StationsOnly=false&key=" + fakekey)))
                .ReturnsAsync(GetTestResponse());
            var search = new PlaceSearchClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };


            var resultAsync = search.SearchAsync(new PlaceSearchRequest
            {
                SearchString = "Solna",
                StationsOnly = false
            });

            resultAsync.Wait();
            var result = resultAsync.Result;
            Assert.IsTrue(result.ResponseData.Count() == 10);
            Assert.IsTrue(result.StatusCode == StatusCode.Ok);
            var first = result.ResponseData.FirstOrDefault();
            var last = result.ResponseData.LastOrDefault();
            Assert.IsTrue(first != null);
            Assert.IsTrue(last != null);
            Assert.IsTrue(last != first);

            Assert.IsTrue(first.Name.Equals("Solna (Solna)"));
            Assert.IsTrue(first.X == "18011865");
            Assert.IsTrue(first.Y == "59364312");
            Assert.IsTrue(first.Latitude == 18.011865);
            Assert.IsTrue(first.Longitude == 59.364312);
            Assert.IsTrue(first.SiteId.Equals(9509));

            Assert.IsTrue(last.Latitude == 17.986731);
            Assert.IsTrue(last.Longitude == 9.375783);

        }
    }
}

using System;
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
    public class StopsAndRoutesClientTest
    {

        public string GetTestResponse()
        {
            return
                "{\"StatusCode\":0,\"Message\":null,\"ExecutionTime\":686,\"ResponseData\":{\"Version\":\"2015-08-20 00:07\",\"Typ" +
                "e\":\"Site\",\"Result\":[{\"SiteId\":\"4432\",\"SiteName\":\"Abborrkroksvägen\",\"StopAreaNumber\":\"41483\",\"LastM" +
                "odifiedUtcDateTime\":\"2015-02-13 10:34:20.643\",\"ExistsFromDate\":\"2015-02-14 00:00:00.000\"},{\"SiteId\":\"4314" +
                "\",\"SiteName\":\"Abborrsjön\",\"StopAreaNumber\":\"41187\",\"LastModifiedUtcDateTime\":\"2012-03-26 23:55:32.900\"" +
                ",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"},{\"SiteId\":\"7588\",\"SiteName\":\"Abborrstigen\",\"StopAreaNumber" +
                "\":\"75179\",\"LastModifiedUtcDateTime\":\"2012-03-26 23:55:32.900\",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"" +
                "},{\"SiteId\":\"6056\",\"SiteName\":\"Abborrvägen\",\"StopAreaNumber\":\"64480\",\"LastModifiedUtcDateTime\":\"2012-" +
                "03-26 23:55:32.900\",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"},{\"SiteId\":\"9110\",\"SiteName\":\"Abrahamsb" +
                "erg\",\"StopAreaNumber\":\"1221\",\"LastModifiedUtcDateTime\":\"2012-03-26 23:55:32.900\",\"ExistsFromDate\":\"201" +
                "2-06-23 00:00:00.000\"},{\"SiteId\":\"9110\",\"SiteName\":\"Abrahamsberg\",\"StopAreaNumber\":\"12001\",\"LastMo" +
                "difiedUtcDateTime\":\"2012-03-26 23:55:32.900\",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"},{\"SiteId\":\"364" +
                "0\",\"SiteName\":\"Abrahamsbergsskolan\",\"StopAreaNumber\":\"12003\",\"LastModifiedUtcDateTime\":\"2012-03-26 23" +
                ":55:32.900\",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"},{\"SiteId\":\"3643\",\"SiteName\":\"Abrahamsbergsväge" +
                "n\",\"StopAreaNumber\":\"12009\",\"LastModifiedUtcDateTime\":\"2012-03-26 23:55:32.900\",\"ExistsFromDate\":\"2012" +
                "-06-23 00:00:00.000\"},{\"SiteId\":\"6517\",\"SiteName\":\"Abrahamsby\",\"StopAreaNumber\":\"64661\",\"LastModified" +
                "UtcDateTime\":\"2012-03-26 23:55:32.900\",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"},{\"SiteId\":\"6582\",\"Si" +
                "teName\":\"Abrahamsby vägskäl\",\"StopAreaNumber\":\"64872\",\"LastModifiedUtcDateTime\":\"2012-03-26 23:55:32.900\"" +
                ",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"},{\"SiteId\":\"6389\",\"SiteName\":\"Addarsnäs fritidsområde\",\"Sto" +
                "pAreaNumber\":\"65123\",\"LastModifiedUtcDateTime\":\"2012-03-26 23:55:32.900\",\"ExistsFromDate\":\"2012-06-23 00:0" +
                "0:00.000\"},{\"SiteId\":\"6388\",\"SiteName\":\"Addarsnäs vägskäl\",\"StopAreaNumber\":\"65121\",\"LastModifiedUtcDa" +
                "teTime\":\"2012-03-26 23:55:32.900\",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"},{\"SiteId\":\"6387\",\"SiteName\"" +
                ":\"Addeboda\",\"StopAreaNumber\":\"65119\",\"LastModifiedUtcDateTime\":\"2012-03-26 23:55:32.900\",\"ExistsFromDate\"" +
                ":\"2012-06-23 00:00:00.000\"},{\"SiteId\":\"3166\",\"SiteName\":\"Adelsö färjeläge\",\"StopAreaNumber\":\"15695\",\"L" +
                "astModifiedUtcDateTime\":\"2012-08-13 15:32:46.770\",\"ExistsFromDate\":\"2012-08-14 00:00:00.000\"},{\"SiteId\":\"31" +
                "66\",\"SiteName\":\"Adelsö färjeläge\",\"StopAreaNumber\":\"15832\",\"LastModifiedUtcDateTime\":\"2012-08-13 15:32:4" +
                "6.770\",\"ExistsFromDate\":\"2012-08-14 00:00:00.000\"},{\"SiteId\":\"3164\",\"SiteName\":\"Adelsö gård\",\"StopArea" +
                "Number\":\"15580\",\"LastModifiedUtcDateTime\":\"2012-03-26 23:55:32.900\",\"ExistsFromDate\":\"2012-06-23 00:00:00.0" +
                "00\"},{\"SiteId\":\"3160\",\"SiteName\":\"Adelsö kyrka\",\"StopAreaNumber\":\"15652\",\"LastModifiedUtcDateTime\":\"2" +
                "012-03-26 23:55:32.900\",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"},{\"SiteId\":\"7206\",\"SiteName\":\"Adler Sa" +
                "lvius väg\",\"StopAreaNumber\":\"70811\",\"LastModifiedUtcDateTime\":\"2012-03-26 23:55:32.900\",\"ExistsFromDate\":\"" +
                "2012-06-23 00:00:00.000\"},{\"SiteId\":\"1033\",\"SiteName\":\"Adolf Fredriks kyrka\",\"StopAreaNumber\":\"10541\",\"" +
                "LastModifiedUtcDateTime\":\"2012-03-26 23:55:32.900\",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"},{\"SiteId\":\"73" +
                "66\",\"SiteName\":\"Advokatbacken\",\"StopAreaNumber\":\"70456\",\"LastModifiedUtcDateTime\":\"2012-03-26 23:55:32.90" +
                "0\",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"},{\"SiteId\":\"5831\",\"SiteName\":\"Aftonvägen\",\"StopAreaNumbe" +
                "r\":\"51783\",\"LastModifiedUtcDateTime\":\"2012-03-26 23:55:32.900\",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"}" +
                ",{\"SiteId\":\"7226\",\"SiteName\":\"Aftonvägen\",\"StopAreaNumber\":\"70775\",\"LastModifiedUtcDateTime\":\"2012-03-" +
                "26 23:55:32.900\",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"},{\"SiteId\":\"9248\",\"SiteName\":\"Aga\",\"StopAre" +
                "aNumber\":\"21111\",\"LastModifiedUtcDateTime\":\"2012-03-26 23:55:32.900\",\"ExistsFromDate\":\"2012-06-23 00:00:00" +
                ".000\"},{\"SiteId\":\"9248\",\"SiteName\":\"Aga\",\"StopAreaNumber\":\"21321\",\"LastModifiedUtcDateTime\":\"2012-03-" +
                "26 23:55:32.900\",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"},{\"SiteId\":\"9248\",\"SiteName\":\"Aga\",\"StopAre" +
                "aNumber\":\"22061\",\"LastModifiedUtcDateTime\":\"2012-03-26 23:55:32.900\",\"ExistsFromDate\":\"2012-06-23 00:00:00." +
                "000\"}]}}";
        }

        [TestMethod]
        public void RealtimeDeparturesTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/LineData.json/?model=site&key=" + fakekey)))
                .Returns(GetTestResponse);
            var t = new StopsAndRoutesClient(new HttpClient(mockedHttpRequest.Object))
            {
                ApiToken = fakekey
            };

          
            var result = t.SiteData();
            Assert.IsTrue(result.ExecutionTime == 686);
            Assert.IsTrue(result.ResponseData.Result.Length == 25);
            Assert.IsTrue(result.ResponseData.Result[0].SiteId == 4432);
            Assert.IsTrue(result.ResponseData.Result[24].SiteId == 9248);
            

        }

        [TestMethod]
        public void RealtimeDeparturesAsyncTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/LineData.json/?model=site&key=" + fakekey)))
                .ReturnsAsync(GetTestResponse());
            var t = new StopsAndRoutesClient(new HttpClient(mockedHttpRequest.Object))
            {
                ApiToken = fakekey
            };


            var responseAsync = t.SiteDataAsync();
            responseAsync.Wait();
            var result = responseAsync.Result;
            Assert.IsTrue(result.ExecutionTime == 686);
            Assert.IsTrue(result.ResponseData.Result.Length == 25);
            Assert.IsTrue(result.ResponseData.Result[0].SiteId == 4432);
            Assert.IsTrue(result.ResponseData.Result[24].SiteId == 9248);

        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SlApi.Core;
using SlApi.Models.StopsAndRoutes.Response;

namespace SlApi.Tests
{
    [TestClass]
    public class StopsAndRoutesClientTest
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
            var t = new StopsAndRoutesClient(new HttpClient(mockedHttpRequest.Object))
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
            var t = new StopsAndRoutesClient(new HttpClient(mockedHttpRequest.Object))
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
            var t = new StopsAndRoutesClient(new HttpClient(mockedHttpRequest.Object))
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
            var t = new StopsAndRoutesClient(new HttpClient(mockedHttpRequest.Object))
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
            var t = new StopsAndRoutesClient(new HttpClient(mockedHttpRequest.Object))
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
            var t = new StopsAndRoutesClient(new HttpClient(mockedHttpRequest.Object))
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
            var t = new StopsAndRoutesClient(new HttpClient(mockedHttpRequest.Object))
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
            var t = new StopsAndRoutesClient(new HttpClient(mockedHttpRequest.Object))
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
            var t = new StopsAndRoutesClient(new HttpClient(mockedHttpRequest.Object))
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
            var t = new StopsAndRoutesClient(new HttpClient(mockedHttpRequest.Object))
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
            return
                "{\"StatusCode\":0,\"Message\":null,\"ExecutionTime\":717,\"ResponseData\":{\"Version\":\"2015-08-20 00:07\",\"Type\":\"Line\",\"Resu" +
                "lt\":[{\"LineNumber\":\"1\",\"LineDesignation\":\"1\",\"DefaultTransportMode\":\"blåbuss\",\"DefaultTransportModeCode\":\"METRO\",\"" +
                "LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"},{\"LineNumber\":\"1\",\"LineD" +
                "esignation\":\"1\",\"DefaultTransportMode\":\"Waxholmsbolagets\",\"DefaultTransportModeCode\":\"SHIP\",\"LastModifiedUtcDateTime\":\"2" +
                "009-09-02 00:00:00.000\",\"ExistsFromDate\":\"2009-09-02 00:00:00.000\"},{\"LineNumber\":\"10\",\"LineDesignation\":\"10\",\"Default" +
                "TransportMode\":\"tunnelbanans blå linje\",\"DefaultTransportModeCode\":\"METRO\",\"LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.00" +
                "0\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"},{\"LineNumber\":\"101\",\"LineDesignation\":\"101\",\"DefaultTransportMode\":\"\"" +
                ",\"DefaultTransportModeCode\":\"BUS\",\"LastModifiedUtcDateTime\":\"2012-08-24 00:00:00.000\",\"ExistsFromDate\":\"2012-08-24 00:00:00" +
                ".000\"},{\"LineNumber\":\"102\",\"LineDesignation\":\"102\",\"DefaultTransportMode\":\"\",\"DefaultTransportModeCode\":\"BUS\",\"LastMo" +
                "difiedUtcDateTime\":\"2012-08-24 00:00:00.000\",\"ExistsFromDate\":\"2012-08-24 00:00:00.000\"},{\"LineNumber\":\"11\",\"LineDesignatio" +
                "n\":\"11\",\"DefaultTransportMode\":\"tunnelbanans blå linje\",\"DefaultTransportModeCode\":\"METRO\",\"LastModifiedUtcDateTime\":\"200" +
                "7-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"},{\"LineNumber\":\"11\",\"LineDesignation\":\"11\",\"DefaultTransp" +
                "ortMode\":\"Waxholmsbolagets\",\"DefaultTransportModeCode\":\"SHIP\",\"LastModifiedUtcDateTime\":\"2009-09-02 00:00:00.000\",\"ExistsFro" +
                "mDate\":\"2009-09-02 00:00:00.000\"},{\"LineNumber\":\"110\",\"LineDesignation\":\"110\",\"DefaultTransportMode\":\"\",\"DefaultTranspor" +
                "tModeCode\":\"BUS\",\"LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"},{\"LineNumbe" +
                "r\":\"112\",\"LineDesignation\":\"112\",\"DefaultTransportMode\":\"\",\"DefaultTransportModeCode\":\"BUS\",\"LastModifiedUtcDateTime\":\"" +
                "2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"},{\"LineNumber\":\"113\",\"LineDesignation\":\"113\",\"DefaultTr" +
                "ansportMode\":\"\",\"DefaultTransportModeCode\":\"BUS\",\"LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"200" +
                "7-08-24 00:00:00.000\"},{\"LineNumber\":\"114\",\"LineDesignation\":\"114\",\"DefaultTransportMode\":\"\",\"DefaultTransportModeCode\":\"" +
                "BUS\",\"LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"},{\"LineNumber\":\"115\",\"" +
                "LineDesignation\":\"115\",\"DefaultTransportMode\":\"\",\"DefaultTransportModeCode\":\"BUS\",\"LastModifiedUtcDateTime\":\"2007-08-24 0" +
                "0:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"},{\"LineNumber\":\"116\",\"LineDesignation\":\"116\",\"DefaultTransportMode" +
                "\":\"\",\"DefaultTransportModeCode\":\"BUS\",\"LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:" +
                "00:00.000\"},{\"LineNumber\":\"117\",\"LineDesignation\":\"117\",\"DefaultTransportMode\":\"\",\"DefaultTransportModeCode\":\"BUS\",\"La" +
                "stModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"},{\"LineNumber\":\"118\",\"LineDesign" +
                "ation\":\"118\",\"DefaultTransportMode\":\"\",\"DefaultTransportModeCode\":\"BUS\",\"LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.000" +
                "\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"},{\"LineNumber\":\"119\",\"LineDesignation\":\"119\",\"DefaultTransportMode\":\"\",\"D" +
                "efaultTransportModeCode\":\"BUS\",\"LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"" +
                "},{\"LineNumber\":\"12\",\"LineDesignation\":\"12\",\"DefaultTransportMode\":\"Nockebybanan\",\"DefaultTransportModeCode\":\"TRAM\",\"La" +
                "stModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"},{\"LineNumber\":\"12\",\"LineDesigna" +
                "tion\":\"12\",\"DefaultTransportMode\":\"Waxholmsbolagets\",\"DefaultTransportModeCode\":\"SHIP\",\"LastModifiedUtcDateTime\":\"2009-09-0" +
                "2 00:00:00.000\",\"ExistsFromDate\":\"2009-09-02 00:00:00.000\"},{\"LineNumber\":\"124\",\"LineDesignation\":\"124\",\"DefaultTransportMo" +
                "de\":\"\",\"DefaultTransportModeCode\":\"BUS\",\"LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00" +
                ":00:00.000\"},{\"LineNumber\":\"127\",\"LineDesignation\":\"127\",\"DefaultTransportMode\":\"\",\"DefaultTransportModeCode\":\"BUS\",\"Las" +
                "tModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"},{\"LineNumber\":\"13\",\"LineDesignati" +
                "on\":\"13\",\"DefaultTransportMode\":\"tunnelbanans röda linje\",\"DefaultTransportModeCode\":\"METRO\",\"LastModifiedUtcDateTime\":\"2007" +
                "-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"},{\"LineNumber\":\"13\",\"LineDesignation\":\"13\",\"DefaultTranspor" +
                "tMode\":\"Waxholmsbolagets\",\"DefaultTransportModeCode\":\"SHIP\",\"LastModifiedUtcDateTime\":\"2009-09-02 00:00:00.000\",\"ExistsFromDa" +
                "te\":\"2009-09-02 00:00:00.000\"},{\"LineNumber\":\"133\",\"LineDesignation\":\"133\",\"DefaultTransportMode\":\"\",\"DefaultTransportMo" +
                "deCode\":\"BUS\",\"LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"},{\"LineNumber\"" +
                ":\"134\",\"LineDesignation\":\"134\",\"DefaultTransportMode\":\"\",\"DefaultTransportModeCode\":\"BUS\",\"LastModifiedUtcDateTime\":\"2007" +
                "-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"},{\"LineNumber\":\"135\",\"LineDesignation\":\"135\",\"DefaultTransp" +
                "ortMode\":\"\",\"DefaultTransportModeCode\":\"BUS\",\"LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-2" +
                "4 00:00:00.000\"},{\"LineNumber\":\"14\",\"LineDesignation\":\"14\",\"DefaultTransportMode\":\"tunnelbanans röda linje\",\"DefaultTranspor" +
                "tModeCode\":\"METRO\",\"LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"},{\"LineNumbe" +
                "r\":\"14\",\"LineDesignation\":\"14\",\"DefaultTransportMode\":\"Waxholmsbolagets\",\"DefaultTransportModeCode\":\"SHIP\",\"LastModifiedUt" +
                "cDateTime\":\"2009-09-02 00:00:00.000\",\"ExistsFromDate\":\"2009-09-02 00:00:00.000\"},{\"LineNumber\":\"141\",\"LineDesignation\":\"141\"" +
                ",\"DefaultTransportMode\":\"\",\"DefaultTransportModeCode\":\"BUS\",\"LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDa" +
                "te\":\"2007-08-24 00:00:00.000\"},{\"LineNumber\":\"142\",\"LineDesignation\":\"142\",\"DefaultTransportMode\":\"\",\"DefaultTransportMod" +
                "eCode\":\"BUS\",\"LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"}]}}";
        }

        public string GetTestResponseForStopPoints()
        {
            return
                "{\"StatusCode\":0,\"Message\":null,\"ExecutionTime\":792,\"ResponseData\":{\"Version\":\"2015-08-20 00:07\",\"Type\":\"StopPo" +
                "int\",\"Result\":[{\"StopPointNumber\":\"10001\",\"StopPointName\":\"Stadshagsplan\",\"StopAreaNumber\":\"10001\",\"Location" +
                "NorthingCoordinate\":\"59.3374104106887\",\"LocationEastingCoordinate\":\"18.0216535880432\",\"ZoneShortName\":\"A\",\"StopA" +
                "reaTypeCode\":\"BUSTERM\",\"LastModifiedUtcDateTime\":\"2014-06-03 00:00:00.000\",\"ExistsFromDate\":\"2014-06-03 00:00:00.00" +
                "0\"},{\"StopPointNumber\":\"10002\",\"StopPointName\":\"John Bergs plan\",\"StopAreaNumber\":\"10002\",\"LocationNorthingCoord" +
                "inate\":\"59.3361450073188\",\"LocationEastingCoordinate\":\"18.0222866342593\",\"ZoneShortName\":\"A\",\"StopAreaTypeCode\":\"" +
                "BUSTERM\",\"LastModifiedUtcDateTime\":\"2014-06-03 00:00:00.000\",\"ExistsFromDate\":\"2014-06-03 00:00:00.000\"},{\"StopPointN" +
                "umber\":\"10003\",\"StopPointName\":\"John Bergs plan\",\"StopAreaNumber\":\"10002\",\"LocationNorthingCoordinate\":\"59.336254" +
                "9983713\",\"LocationEastingCoordinate\":\"18.0220232520707\",\"ZoneShortName\":\"A\",\"StopAreaTypeCode\":\"BUSTERM\",\"LastModi" +
                "fiedUtcDateTime\":\"2014-06-03 00:00:00.000\",\"ExistsFromDate\":\"2014-06-03 00:00:00.000\"},{\"StopPointNumber\":\"10006\",\"S" +
                "topPointName\":\"Arbetargatan\",\"StopAreaNumber\":\"10006\",\"LocationNorthingCoordinate\":\"59.3352361789930\",\"LocationEasti" +
                "ngCoordinate\":\"18.0269957169377\",\"ZoneShortName\":\"A\",\"StopAreaTypeCode\":\"BUSTERM\",\"LastModifiedUtcDateTime\":\"2014-" +
                "06-03 00:00:00.000\",\"ExistsFromDate\":\"2014-06-03 00:00:00.000\"},{\"StopPointNumber\":\"10007\",\"StopPointName\":\"Arbetarg" +
                "atan\",\"StopAreaNumber\":\"10006\",\"LocationNorthingCoordinate\":\"59.3351886295410\",\"LocationEastingCoordinate\":\"18.02767" +
                "80794936\",\"ZoneShortName\":\"A\",\"StopAreaTypeCode\":\"BUSTERM\",\"LastModifiedUtcDateTime\":\"2014-06-03 00:00:00.000\",\"Ex" +
                "istsFromDate\":\"2014-06-03 00:00:00.000\"},{\"StopPointNumber\":\"10008\",\"StopPointName\":\"S:t Eriksgatan\",\"StopAreaNumber" +
                "\":\"10008\",\"LocationNorthingCoordinate\":\"59.3344783742441\",\"LocationEastingCoordinate\":\"18.0315965889341\",\"ZoneShortN" +
                "ame\":\"A\",\"StopAreaTypeCode\":\"BUSTERM\",\"LastModifiedUtcDateTime\":\"2014-06-03 00:00:00.000\",\"ExistsFromDate\":\"2014-0" +
                "6-03 00:00:00.000\"},{\"StopPointNumber\":\"10009\",\"StopPointName\":\"S:t Eriksgatan\",\"StopAreaNumber\":\"10008\",\"Location" +
                "NorthingCoordinate\":\"59.3344800039436\",\"LocationEastingCoordinate\":\"18.0334950425846\",\"ZoneShortName\":\"A\",\"StopAreaTy" +
                "peCode\":\"BUSTERM\",\"LastModifiedUtcDateTime\":\"2014-06-03 00:00:00.000\",\"ExistsFromDate\":\"2014-06-03 00:00:00.000\"},{\"" +
                "StopPointNumber\":\"10010\",\"StopPointName\":\"Frihamnens färjeterminal\",\"StopAreaNumber\":\"10010\",\"LocationNorthingCoordin" +
                "ate\":\"59.3425635205332\",\"LocationEastingCoordinate\":\"18.1189085925683\",\"ZoneShortName\":\"A\",\"StopAreaTypeCode\":\"BUST" +
                "ERM\",\"LastModifiedUtcDateTime\":\"2014-12-14 00:00:00.000\",\"ExistsFromDate\":\"2014-12-14 00:00:00.000\"},{\"StopPointNumber\"" +
                ":\"10011\",\"StopPointName\":\"Frihamnsporten\",\"StopAreaNumber\":\"10052\",\"LocationNorthingCoordinate\":\"59.3399094088355\",\"" +
                "LocationEastingCoordinate\":\"18.1146321830924\",\"ZoneShortName\":\"A\",\"StopAreaTypeCode\":\"BUSTERM\",\"LastModifiedUtcDateTim" +
                "e\":\"2014-06-03 00:00:00.000\",\"ExistsFromDate\":\"2014-06-03 00:00:00.000\"},{\"StopPointNumber\":\"10012\",\"StopPointName\":\"" +
                "S:t Eriks ögonsjukhus\",\"StopAreaNumber\":\"10012\",\"LocationNorthingCoordinate\":\"59.3337783076748\",\"LocationEastingCoordinate" +
                "\":\"18.0374650139904\",\"ZoneShortName\":\"A\",\"StopAreaTypeCode\":\"BUSTERM\",\"LastModifiedUtcDateTime\":\"2014-06-03 00:00:00.0" +
                "00\",\"ExistsFromDate\":\"2014-06-03 00:00:00.000\"},{\"StopPointNumber\":\"10013\",\"StopPointName\":\"S:t Eriksgatan\",\"StopAreaNu" +
                "mber\":\"10008\",\"LocationNorthingCoordinate\":\"59.3347173254206\",\"LocationEastingCoordinate\":\"18.0314340953105\",\"ZoneShortNa" +
                "me\":\"A\",\"StopAreaTypeCode\":\"BUSTERM\",\"LastModifiedUtcDateTime\":\"2014-06-03 00:00:00.000\",\"ExistsFromDate\":\"2014-06-03 0" +
                "0:00:00.000\"},{\"StopPointNumber\":\"10014\",\"StopPointName\":\"Scheelegatan\",\"StopAreaNumber\":\"10014\",\"LocationNorthingCoord" +
                "inate\":\"59.3328650108015\",\"LocationEastingCoordinate\":\"18.0446133231273\",\"ZoneShortName\":\"A\",\"StopAreaTypeCode\":\"BUSTERM" +
                "\",\"LastModifiedUtcDateTime\":\"2014-06-03 00:00:00.000\",\"ExistsFromDate\":\"2014-06-03 00:00:00.000\"},{\"StopPointNumber\":\"10015" +
                "\",\"StopPointName\":\"Scheelegatan\",\"StopAreaNumber\":\"10014\",\"LocationNorthingCoordinate\":\"59.3332016567806\",\"LocationEast" +
                "ingCoordinate\":\"18.0441933960080\",\"ZoneShortName\":\"A\",\"StopAreaTypeCode\":\"BUSTERM\",\"LastModifiedUtcDateTime\":\"2014-06-0" +
                "3 00:00:00.000\",\"ExistsFromDate\":\"2014-06-03 00:00:00.000\"}]}}";
        }

        public string GetTestResponseForSites()
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

        public string GetTestTransportMode()
        {
            return
                "{\"StatusCode\":0,\"Message\":null,\"ExecutionTime\":613,\"ResponseData\":{\"Version\":\"2015-09-04 00:12\",\"Type\":" +
                "\"TransportMode\",\"Result\":[{\"DefaultTransportModeCode\":\"BUS\",\"DefaultTransportMode\":\"buss\",\"StopAreaTypeC" +
                "ode\":\"BUSTERM\",\"LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000" +
                "\"},{\"DefaultTransportModeCode\":\"FERRY\",\"DefaultTransportMode\":\"färja\",\"StopAreaTypeCode\":\"FERRYBER\",\"Last" +
                "ModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"},{\"DefaultTransportMod" +
                "eCode\":\"METRO\",\"DefaultTransportMode\":\"tunnelbana\",\"StopAreaTypeCode\":\"METROSTN\",\"LastModifiedUtcDateTime\":\"" +
                "2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"},{\"DefaultTransportModeCode\":\"SHIP\",\"Defaul" +
                "tTransportMode\":\"båt\",\"StopAreaTypeCode\":\"FERRYBER\",\"LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"Exis" +
                "tsFromDate\":\"2007-08-24 00:00:00.000\"},{\"DefaultTransportModeCode\":\"TRAIN\",\"DefaultTransportMode\":\"pendeltåg\"," +
                "\"StopAreaTypeCode\":\"RAILWSTN\",\"LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24" +
                " 00:00:00.000\"},{\"DefaultTransportModeCode\":\"TRAM\",\"DefaultTransportMode\":\"spårvagn/lokalbana\",\"StopAreaTypeCode" +
                "\":\"TRAMSTN\",\"LastModifiedUtcDateTime\":\"2007-08-24 00:00:00.000\",\"ExistsFromDate\":\"2007-08-24 00:00:00.000\"}]}}";
        }

        public string GetJourTest()
        {
            return
                "{\"StatusCode\":0,\"Message\":null,\"ExecutionTime\":872,\"ResponseData\":{\"Version\":\"2015-09-04 00:12\",\"Type\":\"JourneyPat" +
                "ternPointOnLine\",\"Result\":[{\"LineNumber\":\"1\",\"DirectionCode\":\"1\",\"JourneyPatternPointNumber\":\"10008\",\"LastModifie" +
                "dUtcDateTime\":\"2012-06-23 00:00:00.000\",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"},{\"LineNumber\":\"1\",\"DirectionCode\"" +
                ":\"1\",\"JourneyPatternPointNumber\":\"10012\",\"LastModifiedUtcDateTime\":\"2012-06-23 00:00:00.000\",\"ExistsFromDate\":\"2012-0" +
                "6-23 00:00:00.000\"},{\"LineNumber\":\"1\",\"DirectionCode\":\"1\",\"JourneyPatternPointNumber\":\"10014\",\"LastModifiedUtcDateTim" +
                "e\":\"2012-06-23 00:00:00.000\",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"},{\"LineNumber\":\"1\",\"DirectionCode\":\"1\",\"Jour" +
                "neyPatternPointNumber\":\"10016\",\"LastModifiedUtcDateTime\":\"2013-12-19 00:00:00.000\",\"ExistsFromDate\":\"2013-12-19 00:00:00." +
                "000\"},{\"LineNumber\":\"1\",\"DirectionCode\":\"1\",\"JourneyPatternPointNumber\":\"10024\",\"LastModifiedUtcDateTime\":\"2013-12-" +
                "19 00:00:00.000\",\"ExistsFromDate\":\"2013-12-19 00:00:00.000\"},{\"LineNumber\":\"1\",\"DirectionCode\":\"1\",\"JourneyPatternPoi" +
                "ntNumber\":\"10026\",\"LastModifiedUtcDateTime\":\"2012-06-23 00:00:00.000\",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"},{\"Lin" +
                "eNumber\":\"1\",\"DirectionCode\":\"1\",\"JourneyPatternPointNumber\":\"10030\",\"LastModifiedUtcDateTime\":\"2013-12-19 00:00:00." +
                "000\",\"ExistsFromDate\":\"2013-12-19 00:00:00.000\"},{\"LineNumber\":\"1\",\"DirectionCode\":\"1\",\"JourneyPatternPointNumber\":" +
                "\"10034\",\"LastModifiedUtcDateTime\":\"2012-06-23 00:00:00.000\",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"},{\"LineNumber\":" +
                "\"1\",\"DirectionCode\":\"1\",\"JourneyPatternPointNumber\":\"10038\",\"LastModifiedUtcDateTime\":\"2014-05-06 00:00:00.000\",\"Ex" +
                "istsFromDate\":\"2014-05-06 00:00:00.000\"},{\"LineNumber\":\"1\",\"DirectionCode\":\"1\",\"JourneyPatternPointNumber\":\"10042\"," +
                "\"LastModifiedUtcDateTime\":\"2012-06-23 00:00:00.000\",\"ExistsFromDate\":\"2012-06-23 00:00:00.000\"},{\"LineNumber\":\"1\",\"Di" +
                "rectionCode\":\"1\",\"JourneyPatternPointNumber\":\"10044\",\"LastModifiedUtcDateTime\":\"2012-06-23 00:00:00.000\",\"ExistsFromDa" +
                "te\":\"2012-06-23 00:00:00.000\"}]}}";
        }
    }
}

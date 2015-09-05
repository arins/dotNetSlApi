using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SlApi.Core;
using SlApi.Models;
using SlApi.Models.RealtimeInformation.Request;
using SlApi.Models.RealtimeInformation.Response;
using SlApi.Models.TrafficInformation.Response;

namespace SlApi.Tests
{
    [TestClass]
    public class TrafficInformationClientTest
    {

        public string GetTestResponse()
        {
            return
                "{\"StatusCode\":0,\"Message\":\"\",\"ExecutionTime\":39,\"ResponseData\":{\"TrafficTypes\":[{\"Id\":2,\"N" +
                "ame\":\"Tunnelbana\",\"Type\":\"metro\",\"TrafficStatus\":null,\"StatusIcon\":\"EventGood\",\"Events\":[{\"" +
                "EventId\":3489,\"Message\":\"Hissen vid Alby mellan biljetthallen och plattformen för tågen mot Ropsten, ä" +
                "r avstängd tills vidare för underhållsarbeten.\",\"LineNumbers\":{\"InputDataIsOptional\":true,\"Text\":nul" +
                "l},\"Expanded\":true,\"Planned\":true,\"SortIndex\":100,\"TrafficLine\":\"Röda linjen\",\"EventInfoUrl\"" +
                ":null,\"Status\":null,\"StatusIcon\":\"EventPlanned\"},{\"EventId\":3520,\"Message\":\"Hissarna mellan " +
                "Eriksbergåsen och Hallunda/Norsborg, är avstängda till och med 31 december för renovering.\",\"LineNumbe" +
                "rs\":{\"InputDataIsOptional\":true,\"Text\":null},\"Expanded\":true,\"Planned\":true,\"SortIndex\":100," +
                "\"TrafficLine\":\"Röda linjen\",\"EventInfoUrl\":null,\"Status\":null,\"StatusIcon\":\"EventPlanned\"}" +
                ",{\"EventId\":3521,\"Message\":\"Hissen vid Hallunda mellan biljetthallen och plattformen, är avstängd" +
                " till och med 23 oktober för underhållsarbeten.\",\"LineNumbers\":{\"InputDataIsOptional\":true,\"Tex" +
                "t\":null},\"Expanded\":true,\"Planned\":true,\"SortIndex\":100,\"TrafficLine\":\"Röda linjen\",\"Even" +
                "tInfoUrl\":null,\"Status\":null,\"StatusIcon\":\"EventPlanned\"},{\"EventId\":3488,\"Message\":\"Hiss" +
                "en vid Gullmarsplan till/från plattformen för tågen mot Hässelby strand är avstängd p.g.a. renovering" +
                ". Resenärer i behov av hissen hänvisas till byte vid Skanstull. På Gullmarsplans andra plattform fi" +
                "nns en fungerande hiss. Arbetet beräknas vara klart under vecka 38.\",\"LineNumbers\":{\"InputData" +
                "IsOptional\":true,\"Text\":null},\"Expanded\":true,\"Planned\":true,\"SortIndex\":100,\"TrafficLin" +
                "e\":\"Gröna linjen\",\"EventInfoUrl\":null,\"Status\":null,\"StatusIcon\":\"EventPlanned\"},{\"Eve" +
                "ntId\":0,\"Message\":\"Övriga linjer: inga större störningar\",\"LineNumbers\":null,\"Expanded\":fa" +
                "lse,\"Planned\":false,\"SortIndex\":10000,\"TrafficLine\":null,\"EventInfoUrl\":null,\"Status\":nul" +
                "l,\"StatusIcon\":\"EventGood\"}],\"Expanded\":true,\"HasPlannedEvent\":true},{\"Id\":6,\"Name\":\"" +
                "Pendeltåg\",\"Type\":\"train\",\"TrafficStatus\":null,\"StatusIcon\":\"EventGood\",\"Events\":[{\"" +
                "EventId\":3579,\"Message\":\"Kommande händelse för linje 36 och 38, norrgående tåg: Pendeltåg mo" +
                "t Märsta och Uppsala C stannar inte i Häggvik, Norrviken och Rotebro från 12/9 kl. 21:30 till 13/" +
                "9 kl. 09:25 pga banarbete. Buss ersätter.\",\"LineNumbers\":{\"InputDataIsOptional\":true,\"Text" +
                "\":null},\"Expanded\":true,\"Planned\":true,\"SortIndex\":160,\"TrafficLine\":\"Pendeltåg\",\"Eve" +
                "ntInfoUrl\":null,\"Status\":null,\"StatusIcon\":\"EventPlanned\"},{\"EventId\":0,\"Message\":\"Öv" +
                "riga linjer: inga större störningar\",\"LineNumbers\":null,\"Expanded\":false,\"Planned\":false,\"Sort" +
                "Index\":10000,\"TrafficLine\":null,\"EventInfoUrl\":null,\"Status\":null,\"StatusIcon\":\"EventGood\"}" +
                "],\"Expanded\":true,\"HasPlannedEvent\":true},{\"Id\":14,\"Name\":\"Lokalbana\",\"Type\":\"local\",\"T" +
                "rafficStatus\":null,\"StatusIcon\":\"EventGood\",\"Events\":[{\"EventId\":2832,\"Message\":\"Näsbypar" +
                "kslinjen 29: \r\n\r\nFr.o.m. 19 juni t.o.m.7 november 2015 är tågtrafiken avstängd på grund av banar" +
                "bete.\r\n\r\nLinje 29 Stockholms östra - Näsbypark ersätts av tunnelbana sträckan Tekniska högskolan" +
                " - Danderyds sjukhus och ersättningsbussar trafikerar sträckan Danderyds sjukhus - Näsbypark.\r\n\r" +
                "\n\r\nResenärer till/från Stocksunds station hänvisas till ordinarie busshållplats intill statione" +
                "n för vidare färd till tunnelbana Danderyds sjukhus eller Bergshamra.\r\nKlicka här för mer informat" +
                "ion.\",\"LineNumbers\":{\"InputDataIsOptional\":true,\"Text\":\"29\"},\"Expanded\":false,\"Planned\"" +
                ":true,\"SortIndex\":100,\"TrafficLine\":\"Roslagsbanan\",\"EventInfoUrl\":\"http://sl.se/sv/info/r" +
                "esa/forandringar/roslagsbanan/\",\"Status\":null,\"StatusIcon\":\"EventPlanned\"},{\"EventId\":28" +
                "33,\"Message\":\"Kårstalinjen 27 och Österskärslinjen 28:  \r\n\r\nFr.o.m.19 juni t.o.m.7 november " +
                "2015 är tågtrafiken avstängd sträckan Stockholms östra - Universitetet på grund av ombyggnad av Stoc" +
                "kholms östra station. \r\n\r\nResande hänvisas till tunnelbana sträckan Tekniska högskolan - Univers" +
                "itetet.\r\n\r\nSöndagen den 20 september ersätts även tågtrafiken mellan Mörby station och Universit" +
                "etet med buss. Ersättningsbussarna trafikerar sträckan Mörby station - Danderyds sjukhus.\r\n\r\nKl" +
                "icka här för mer information.\",\"LineNumbers\":{\"InputDataIsOptional\":true,\"Text\":\"27,28\"},\"" +
                "Expanded\":false,\"Planned\":true,\"SortIndex\":100,\"TrafficLine\":\"Roslagsbanan\",\"EventInfoUrl\"" +
                ":\"http://sl.se/sv/info/resa/forandringar/roslagsbanan/\",\"Status\":null,\"StatusIcon\":\"EventPlanne" +
                "d\"},{\"EventId\":3361,\"Message\":\"Österskärslinjen 28: Fr.o.m 17 augusti t.o.m.7 november kompletter" +
                "ar buss 28M tågen på linje 28.\r\nBuss 28M trafikerar under högtrafik i rusningsriktningen måndag - fred" +
                "ag sträckan Danderyds sjukhus - motorväg E18 - Åkersberga station. \r\n\",\"LineNumbers\":{\"InputData" +
                "IsOptional\":true,\"Text\":\"27,28,29\"},\"Expanded\":true,\"Planned\":true,\"SortIndex\":100,\"Traffi" +
                "cLine\":\"Roslagsbanan\",\"EventInfoUrl\":null,\"Status\":null,\"StatusIcon\":\"EventPlanned\"},{\"EventId" +
                "\":0,\"Message\":\"Övriga linjer: inga större störningar\",\"LineNumbers\":null,\"Expanded\":false,\"Plann" +
                "ed\":false,\"SortIndex\":10000,\"TrafficLine\":null,\"EventInfoUrl\":null,\"Status\":null,\"StatusIcon\":" +
                "\"EventGood\"}],\"Expanded\":true,\"HasPlannedEvent\":true},{\"Id\":20,\"Name\":\"Spårvagn\",\"Type\":\"t" +
                "ram\",\"TrafficStatus\":null,\"StatusIcon\":\"EventGood\",\"Events\":[{\"EventId\":0,\"Message\":\"Inga s" +
                "törre störningar\",\"LineNumbers\":null,\"Expanded\":false,\"Planned\":false,\"SortIndex\":10000,\"Traffi" +
                "cLine\":null,\"EventInfoUrl\":null,\"Status\":null,\"StatusIcon\":\"EventGood\"}],\"Expanded\":true,\"Ha" +
                "sPlannedEvent\":false},{\"Id\":22,\"Name\":\"Buss\",\"Type\":\"bus\",\"TrafficStatus\":null,\"StatusIcon" +
                "\":\"EventMinor\",\"Events\":[{\"EventId\":3408,\"Message\":\"ändrade hållplatslägen vid Tullinge statio" +
                "n för linje 713, 721, 721X, 722, 723, 726 och 791 på grund av ombyggnationen av bussterminalen.\",\"Line" +
                "Numbers\":{\"InputDataIsOptional\":true,\"Text\":\"721,722,723\"},\"Expanded\":true,\"Planned\":false,\"So" +
                "rtIndex\":100,\"TrafficLine\":\"Huddinge/Botkyrka\",\"EventInfoUrl\":\"http://sl.se/ficktid/karta/vinter/" +
                "Tullinge_term.pdf\",\"Status\":null,\"StatusIcon\":\"EventMinor\"},{\"EventId\":3566,\"Message\":\"föränd" +
                "ringar i busstrafiken för linje 1, 2, 53, 54, 55, 57, 65, 69, 72 och 76 på grund av Tjejmilen samt evenem" +
                "anget Hemvärnet 75 år.\",\"LineNumbers\":{\"InputDataIsOptional\":true,\"Text\":null},\"Expanded\":true,\"" +
                "Planned\":false,\"SortIndex\":100,\"TrafficLine\":\"Innerstan\",\"EventInfoUrl\":null,\"Status\":null,\"S" +
                "tatusIcon\":\"EventMinor\"},{\"EventId\":3590,\"Message\":\"söndag 6 september förändringar i busstrafike" +
                "n för linje 1, 2, 53, 54, 55, 57, 59, 61, 65, 69 och 72 på grund av Stockholm Bike.\",\"LineNumbers\":{\"" +
                "InputDataIsOptional\":true,\"Text\":null},\"Expanded\":true,\"Planned\":true,\"SortIndex\":100,\"TrafficL" +
                "ine\":\"Innerstan\",\"EventInfoUrl\":null,\"Status\":null,\"StatusIcon\":\"EventPlanned\"},{\"EventId\":0" +
                ",\"Message\":\"Övriga linjer: inga större störningar\",\"LineNumbers\":null,\"Expanded\":false,\"Planned\":f" +
                "alse,\"SortIndex\":10000,\"TrafficLine\":null,\"EventInfoUrl\":null,\"Status\":null,\"StatusIcon\":\"Event" +
                "Good\"}],\"Expanded\":true,\"HasPlannedEvent\":true},{\"Id\":45,\"Name\":\"Båt\",\"Type\":\"fer\",\"Traffi" +
                "cStatus\":null,\"StatusIcon\":\"EventGood\",\"Events\":[{\"EventId\":0,\"Message\":\"Inga större störning" +
                "ar\",\"LineNumbers\":null,\"Expanded\":false,\"Planned\":false,\"SortIndex\":10000,\"TrafficLine\":null,\"" +
                "EventInfoUrl\":null,\"Status\":null,\"StatusIcon\":\"EventGood\"}],\"Expanded\":true,\"HasPlannedEvent\":false}]}}";
        }

        [TestMethod]
        public void TrafficInformationTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/trafficsituation.json/?key=" + fakekey)))
                .Returns(GetTestResponse);
            var t = new TrafficInformationClient(new HttpClient(mockedHttpRequest.Object)
            {
                ApiToken = fakekey
            });

          
            var result = t.GetTrafficInformation();

            var f = result.ResponseData.TrafficTypes.FirstOrDefault();
            Assert.IsTrue(f!=null);
            Assert.IsTrue(f.Id == 2);
            Assert.IsTrue(f.Name == "Tunnelbana");
            Assert.IsTrue(f.Type== TraficTypeEnum.Metro);
            Assert.IsTrue(f.StatusIcon == "EventGood");
            var firstEvent = f.Events.FirstOrDefault();
            Assert.IsTrue(firstEvent != null);
            Assert.IsTrue(firstEvent.EventId == 3489);
            Assert.IsTrue(firstEvent.Message == "Hissen vid Alby mellan biljetthallen och plattformen för tågen mot Ropsten, är avstängd tills vidare för underhållsarbeten.");
            Assert.IsTrue(firstEvent.SortIndex == 100);



        }

        [TestMethod]
        public void TrafficInformationAsyncTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/trafficsituation.json/?key=" + fakekey)))
                .ReturnsAsync(GetTestResponse());
            var t = new TrafficInformationClient(new HttpClient(mockedHttpRequest.Object))
            {
                ApiToken = fakekey
            };


            var responseAsync = t.GetTrafficInformationAsync();

            responseAsync.Wait();
            var result = responseAsync.Result;
            var f = result.ResponseData.TrafficTypes.FirstOrDefault();
            Assert.IsTrue(f != null);
            Assert.IsTrue(f.Id == 2);
            Assert.IsTrue(f.Name == "Tunnelbana");
            Assert.IsTrue(f.Type == TraficTypeEnum.Metro);
            Assert.IsTrue(f.StatusIcon == "EventGood");
            var firstEvent = f.Events.FirstOrDefault();
            Assert.IsTrue(firstEvent != null);
            Assert.IsTrue(firstEvent.EventId == 3489);
            Assert.IsTrue(firstEvent.Message == "Hissen vid Alby mellan biljetthallen och plattformen för tågen mot Ropsten, är avstängd tills vidare för underhållsarbeten.");
            Assert.IsTrue(firstEvent.SortIndex == 100);

        }
    }
}

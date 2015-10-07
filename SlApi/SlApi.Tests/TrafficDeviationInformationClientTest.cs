using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SlApi.Core;
using SlApi.Models.TrafficDeviationInformation.Request;

namespace SlApi.Tests
{
    [TestClass]
    public class TrafficDeviationInformationClientTest
    {

        public string GetTestResponse()
        {
            return
                "{\"StatusCode\":0,\"Message\":null,\"ExecutionTime\":53,\"ResponseData\":[{\"Created\":\"2015-09-04T" +
                "16:14:13.297+02:00\",\"MainNews\":false,\"SortOrder\":1,\"Header\":\"Sammanfattning av berörda tide" +
                "r och sträckor\",\"Details\":\"Förändringar i busstrafiken den 5 september på grund av Tjejmilen oc" +
                "h evenemanget Hemvärnet 75 år.\nFör att se hur din resa påverkas, läs nedan:\n\nLinje 1 mot Frihamne" +
                "n kl. 10.55-18.00 indragna hållplatser mellan Värtavägen och Gärdet.\nLinje 1 mot Stora Essingen kl. " +
                "10.55-18.05 indragna hållplatser mellan Gärdet och Värtavägen.\n\nLinje 2 mot Sofia kl. 11.10-13.00 i" +
                "ndragna hållplatser mellan Norrtull och Räntmästartrappan.\nLinje 2 mot Norrtull kl. 10.40-12.30 indr" +
                "agna hållplatser mellan Räntmästartrappan och Norrtull.\n\nLinje 53 mot Henriksdal kl. 11.45-12.35 in" +
                "dragna hållplatser mellan Gustav Adolfs torg och Räntmästartrappan.\nLinje 53 mot Fridhemsplan kl. 11." +
                "35-12.35 indragna hållplatser mellan Räntmästartrappan och Gustav Adolfs torg.\n\nLinje 54 mot Reimers" +
                "holme kl. 11.35-12.45 indragna hållplatser mellan Karlavägen och Kronobergsgatan.\nLinje 54 mot Storän" +
                "gsbotten kl. 11.25-12.35 indragna hållplatser mellan Kronobergsgatan och Karlavägen.\n\nLinje 55 mot Hj" +
                "orthagen kl. 11.40-12.25 indragna hållplatser mellan Räntmästartrappan och Stureplan.\nLinje 55 mot Tan" +
                "to kl. 11.15-12.35 indragna hållplatser mellan Stureplan och Räntmästartrappan.\n\nLinje 57 mot Sofie " +
                "kl. 11.25-12.35 indragna hållplatser mellan Norrtullsgatan och Räntmästartrappan.\nLinje 57 mot Karolins" +
                "ka sjukhuset kl. 11.45-12.25 indragna hållplatser mellan Räntmästartrappan och Norrtullsgatan.\n\nLinje" +
                " 65 mot Centralen kl. 11.50-12.35 indragna hållplatser mellan Kastellholmsbron och Gustav Adolfs torg.\n" +
                "Linje 65 mot Skeppsholmen kl. 11.35-12.25 indragna hållplatser mellan Gustav Adolfs torg och Kastellholm" +
                "sbron\n\nLinje 69 mot Blockhusudden kl. 10.30-11.30 indragna hållplatser mellan Cityterminalen och Bloc" +
                "khusudden.\nLinje 69 mot Karolisnka sjukhusetkl. 11.10-12.00 indragna hållplatser mellan Blockhusudden o" +
                "ch Cityterminalen.\nLinje 69 mot Karolinska institutet kl. 11.40-17.10 indragna hållplatser mellan Block" +
                "husudden och Berwaldhallen.\nLinje 69 mot Blockhusudden kl. 12.10-17.30 indragna hållplatser mellan Berw" +
                "aldhallen och Blockhusudden.\n\nLinje 72 mot Karlbergs station kl. 09.05-17.05 indragna hållplatser mell" +
                "an Frihamnsporten och Värtavägen.\nLinje 72 mot Frihamnen kl. 09.10-17.10 indragna hållplatser mellan Värt" +
                "avägen och Frihamnsporten.\n\nLinje 76 mot Ropsten 09.15-17.00 indragna hållplatser mellan Berwaldhallen " +
                "och Frihamnsporten.\nLinje 76 mot Norra Hammarbyhamnen kl. 09.00-16.50 indragna hållplatser mellan Friham" +
                "nsporten och Djurgårdsbron.\nLinje 76 mot Ropsten kl. 10.45-12.00 indragna hållplatser mellan Räntmästar" +
                "trappan och Ropsten.\nLinje 76 mot Norra Hammarbyhamnen kl. 11.00-13.00 indragna hållplatser mellan Rop" +
                "sten och Räntmästartrappan.\",\"Scope\":\"Tjejmilen Och Hemvärnet 75 År 5 September\",\"DevCaseGid\":90" +
                "76001008532277.0,\"DevMessageVersionNumber\":4,\"ScopeElements\":\"Blåbuss 1, 2; Buss 53, 54, 55, 57, 6" +
                "5, 69, 72, 76\",\"FromDateTime\":\"2015-09-05T09:00:00\",\"UpToDateTime\":\"2015-09-05T18:05:00\",\"Upd" +
                "ated\":\"2015-09-04T16:14:13.297+02:00\"},{\"Created\":\"2015-09-01T20:03:19.247+02:00\",\"MainNews\":fa" +
                "lse,\"SortOrder\":1,\"Header\":\"Förändringar i trafiken\",\"Details\":\"Söndag 6 september från ca 06.30" +
                "-11.30 förändringar i busstrafiken för linje 1, 2, 53, 54, 55, 57, 59, 61, 65, 67 och 72 på grund av Stoc" +
                "kholm Bike.\nFör att se hur din resa påverkas, läs nedan:\n\nLinje 1 mot Frihamnen kl. 07.00-08.20 indrag" +
                "en hållplats Frihamnen.\n\nLinje 2 mot Norrtull kl. 06.50-11.25 indragna hållplatser mellan Räntmästartrap" +
                "pan och Karl XII:s torg.\nLinje 2 mot Sofia kl. 06.55-11.35 indragna hållplatser mellan Kungsträdgården oc" +
                "h Räntmästartrppan.\n\nLinje 53 mot Henriksdalsberget kl. 06.45-10.50 indragna hållplatser mellan Gustav A" +
                "dolfs torg och Räntmästartrappan.\nLinje 53 mot Fridhemsplan kl. 06.35-10.45 indragna hållplatser mellan Rä" +
                "ntmästartrappan och Gustav Adolfs torg.\n\nLinje 54 mot Reimersholme kl. 07.50-10.35 indragna hållplatser " +
                "mellan Bolinders plan och Rådhuset.\nLinje 54 mot Storängsbotten kl. 07.55-10.35 indragna hållplatser mella" +
                "n Kungsholmstorg och Bolinders plan.\n\nLinje 55 mot Hjorthagen kl. 06.50-11.10 indragna hållplatser mellan" +
                " Räntmästartrappan och Karl XII:s torg.\nLinje 55 mot Tanto kl. 07.10-11.10 indragna hållplatser mellan Kun" +
                "gsträdgården och Räntmästartrappan.\n\nLinje 57 mot Sofia kl. 06.50-11.10 indragna hållplatser mellan Räntm" +
                "ästartrappan och Norrtullsgatan.\nLinje 57 mot Karolinska sjukhuset kl. 06.45-11.45 indragna hållplatser mell" +
                "an Räntmästartrappan och Norrtullsgatan.\n\nLinje 59 mot Fredhäll kl. 07.55-11.05 indragna hållplatser mella" +
                "n Inedalsgatan och Mariedal.\nLinje 59 mot Norra Hammarbyhamnen kl. 07.45-11.00 indragna hållplatser mellan" +
                "  Mariedalsvägen och Inedalsgatan.\n\nLinje 61 mot Ruddammen kl. 07.35-11.00 indragna hållplatser mellan Ku" +
                "ngsholmstorg och Rådhuset.\n\nLinje 65 mot Centralen kl. 10.00-11.25 indragna hållplatser mellan Karl XII:s " +
                "torg och Centralen.\nLinje 65 mot Skeppsholmen kl. 09.40-11.00 indragna hållplatser mellan Centralen och Gus" +
                "tav Adolfs torg.\n\nLinje 69 mot Karolinska sjukhuset kl. 06.55-08.20 indragna hållplatser mellan Blockhusu" +
                "dden och Kungsträdgården.\nLinje 69 mot Blockhusudden kl. 07.00-08.15 indragna hållplatser mellan Kungsträd" +
                "gården och Blockhusudden.\n\nLinje 72 mot Frihamnen kl 07.15-07.55 indragna hållplatser mellan Rigagatan o" +
                "ch Frihamnsporten.\nLinje72 Karlbergs station kl. 07.30-08.05 indragna hållplatser mellan Frihamnsporten o" +
                "ch Hakberget.\n\",\"Scope\":\"Stockholm Bike 6 September\",\"DevCaseGid\":9076001008541235.0,\"DevMessageVe" +
                "rsionNumber\":3,\"ScopeElements\":\"Blåbuss 1, 2; Buss 53, 54, 55, 57, 59, 61, 65, 69, 72\",\"FromDateTim" +
                "e\":\"2015-09-06T06:30:00\",\"UpToDateTime\":\"2015-09-06T11:30:00\",\"Updated\":\"2015-09-01T20:03:19.24" +
                "7+02:00\"},{\"Created\":\"2015-08-21T16:03:01.93+02:00\",\"MainNews\":false,\"SortOrder\":1,\"Header\":\"" +
                "Bussar ersätter mellan Spånga och Bålsta på söndagsmorgnar och ett flertal lördagskvällar\",\"Details\":" +
                "\"På grund av arbeten med Mälarbanan ersätts pendeltågstrafiken med buss mellan Spånga och Bålsta på sön" +
                "dag morgon från kl 04:30 fram till kl 08:50 under perioden 11 januari - 6 december.\n\nObservera: ett fl" +
                "ertal helger ersätts pendeltågstrafiken med buss redan från lördag kväll kl 22:30. Detta gäller helgern" +
                "a 29-30 augusti, 17-18 oktober och 24-25 oktober.\n\nBuss 35A går sträckan Spånga-Kungsängen-Bro-Bålsta" +
                " och omvänt.\n\nBuss 35D går sträckan Spånga-Barkarby-Jakobsberg-Kallhäll-Kungsängen och omvänt. \n\nAn" +
                "vänd sökverktyget på sl.se för att hitta det bästa alternativet för just din resa.\n\nVar ute i god tid" +
                " då din resa kan ta längre tid än normalt.\n\",\"Scope\":\"Pendeltåg Nynäshamn-Bålsta-linje 35\",\"DevCas" +
                "eGid\":9076001008518020.0,\"DevMessageVersionNumber\":1,\"ScopeElements\":\"Pendeltåg 35\",\"FromDateTim" +
                "e\":\"2015-08-21T16:01:00\",\"UpToDateTime\":\"2015-12-06T08:30:00\",\"Updated\":\"2015-08-21T16:03:01.93" +
                "+02:00\"},{\"Created\":\"2015-09-05T14:52:23.233+02:00\",\"MainNews\":false,\"SortOrder\":1,\"Header\":" +
                "\"Inställd avgång\",\"Details\":\"Alvik - Odenplan kl 14:47 är inställd på grund av trafikhändelse.\n\"," +
                "\"Scope\":\"Tunnelbanans Gröna Linje 18\",\"DevCaseGid\":9076001008552976.0,\"DevMessageVersionNumber\"" +
                ":2,\"ScopeElements\":\"Tunnelbanans Gröna Linje 18\",\"FromDateTime\":\"2015-09-05T14:42:00\",\"UpToDat" +
                "eTime\":\"2015-09-05T15:53:00\",\"Updated\":\"2015-09-05T14:52:23.233+02:00\"},{\"Created\":\"2015-08-3" +
                "1T14:19:35.453+02:00\",\"MainNews\":false,\"SortOrder\":1,\"Header\":\"Indragen hållplats\",\"Details\"" +
                ":\"Stannar inte vid Karl XII:s torg, Gustav Adolfs torg, Tegelbacken och Centralen i riktning Citytermi" +
                "nalen pga sportevenemang. Detta gäller från och med 2015-09-06 kl 10:00 och till och med kl 11:25.\",\"S" +
                "cope\":\"Buss 65\",\"DevCaseGid\":9076001008540130.0,\"DevMessageVersionNumber\":1,\"ScopeElements\":\"" +
                "Buss 65\",\"FromDateTime\":\"2015-09-06T10:00:00\",\"UpToDateTime\":\"2015-09-06T11:25:00\",\"Updated\"" +
                ":\"2015-08-31T14:19:35.453+02:00\"}]}";
        }

        [TestMethod]
        public void TrafficDeviationInformationTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/deviations.json/?key=" + fakekey)))
                .Returns(GetTestResponse);
            var t = new TrafficDeviationInformationClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper())
            {
                ApiToken = fakekey
            });

          
            var result = t.GetTrafficDeviationInformation(new TrafficDeviationInformationRequest());

            var f = result.ResponseData.FirstOrDefault();
            Assert.IsTrue(f!=null);
            var date = new DateTime(2015, 9, 4, 16, 14, 13);
            DateTime.SpecifyKind(date, DateTimeKind.Local);
            
            Assert.IsTrue(!f.MainNews);
            Assert.IsTrue(f.Details.StartsWith("Förändringar i busstrafiken"));




        }

        [TestMethod]
        public void TrafficDeviationInformationAsyncTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/deviations.json/?key=" + fakekey)))
                .ReturnsAsync(GetTestResponse());
            var t = new TrafficDeviationInformationClient(new HttpClient("https://api.sl.se/", mockedHttpRequest.Object, new UrlHelper()))
            {
                ApiToken = fakekey
            };


            var responseAsync = t.GetTrafficDeviationInformationAsync(new TrafficDeviationInformationRequest());

            responseAsync.Wait();
            var result = responseAsync.Result;
            var f = result.ResponseData.FirstOrDefault();
            Assert.IsTrue(f != null);
            var date = new DateTime(2015, 9, 4, 16, 14, 13);
            DateTime.SpecifyKind(date, DateTimeKind.Local);

            Assert.IsTrue(!f.MainNews);
            Assert.IsTrue(f.Details.StartsWith("Förändringar i busstrafiken"));

        }
    }
}

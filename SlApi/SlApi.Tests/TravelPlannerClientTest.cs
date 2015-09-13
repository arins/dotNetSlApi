﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SlApi.Core;
using SlApi.Models;
using SlApi.Models.RealtimeInformation.Request;
using SlApi.Models.RealtimeInformation.Response;
using SlApi.Models.TrafficInformation.Response;
using SlApi.Models.TravelPlanner.Request;

namespace SlApi.Tests
{
    [TestClass]
    public class TravelPlannerClientTest
    {

        

        [TestMethod]
        public void TripTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponse(
                        new Uri(
                            "https://api.sl.se/api2/TravelplannerV2/trip.json/?date=2015-09-07&time=22:00&originId=9305&destId=9001&key=" + fakekey)))
                .Returns(GetTestResponse);
            var t = new TravelPlannerClient(new HttpClient(mockedHttpRequest.Object)
            {
                ApiToken = fakekey
            });

          
            var result = t.Trip(new TripRequest {DateTime = new DateTime(2015,9, 7,22,0,0,DateTimeKind.Local),OriginId = "9305", DestId = "9001" });

            var f = result.TripList.Trip.FirstOrDefault();
            
            Assert.IsTrue(f != null);
            Assert.IsTrue(f.LegList.Leg.Direction == "Kungsträdgården");




        }

        [TestMethod]
        public void TripAsyncTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/TravelplannerV2/trip.json/?date=2015-09-07&time=22:00&originId=9305&destId=9001&key=" +
                            fakekey)))
                .ReturnsAsync(GetTestResponse());
            var t = new TravelPlannerClient(new HttpClient(mockedHttpRequest.Object)
            {
                ApiToken = fakekey
            });


            var resultAsync =
                t.TripAsync(new TripRequest
                {
                    DateTime = new DateTime(2015, 9, 7, 22, 0, 0, DateTimeKind.Local),
                    OriginId = "9305",
                    DestId = "9001"
                });
            resultAsync.Wait();
            var result = resultAsync.Result;
            var f = result.TripList.Trip.FirstOrDefault();

            Assert.IsTrue(f != null);
            Assert.IsTrue(f.LegList.Leg.Direction == "Kungsträdgården");
        }


        [TestMethod]
        public void TripMultiZoneAsyncTest()
        {

            var fakekey = "fakekey";
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseAsync(
                        new Uri(
                            "https://api.sl.se/api2/TravelplannerV2/trip.json/?date=2015-09-09&time=22:00&originId=9305&destId=9001&key=" +
                            fakekey)))
                .ReturnsAsync(GetMultiZoneTest());
            var t = new TravelPlannerClient(new HttpClient(mockedHttpRequest.Object)
            {
                ApiToken = fakekey
            });


            var resultAsync =
                t.TripAsync(new TripRequest
                {
                    DateTime = new DateTime(2015, 9, 9, 22, 0, 0, DateTimeKind.Local),
                    OriginId = "9305",
                    DestId = "9001"
                });
            resultAsync.Wait();
            var result = resultAsync.Result;
            var f = result.TripList.Trip.FirstOrDefault();

            Assert.IsTrue(f != null);
            Assert.IsTrue(f.LegList.Leg.Direction == "Kungsträdgården");
        }

        public string GetTestResponse()
        {
            return
                "{\"TripList\":{  \"noNamespaceSchemaLocation\":\"hafasRestTrip.xsd\",  \"Trip\":[{   " +
                " \"dur\":\"8\",    \"chg\":\"0\",    \"co2\":\"0.00\",    \"LegList\":{      \"Leg\":{    " +
                "    \"idx\":\"0\",        \"name\":\"tunnelbanans blå linje 11\",        \"type\":\"METRO\"," +
                "        \"dir\":\"Kungsträdgården\",        \"line\":\"11\",        \"Origin\":{      " +
                "    \"name\":\"Solna centrum\",          \"type\":\"ST\",          \"id\":\"400103212\"," +
                "          \"lon\":\"17.998408\",          \"lat\":\"59.359584\",          \"routeIdx\":\"6\"," +
                "          \"time\":\"22:08\",          \"date\":\"2015-09-07\"          },    " +
                "    \"Destination\":{          \"name\":\"T-Centralen\",          \"type\":\"ST\"," +
                "          \"id\":\"400103052\",          \"lon\":\"18.062007\",          \"lat\":\"59" +
                ".332347\",          \"routeIdx\":\"11\",          \"time\":\"22:16\",          \"date\"" +
                ":\"2015-09-07\"          },        \"JourneyDetailRef\":{          \"ref\":\"ref%3D17391" +
                "3%2F61055%2F701942%2F293000%2F74%3Fdate%3D2015-09-07%26station_evaId%3D400103212%26stati" +
                "on_type%3Ddep%26lang%3Dsv%26format%3Djson%26\"          },        \"GeometryRef\":{       " +
                "   \"ref\":\"ref%3D173913%2F61055%2F701942%2F293000%2F74%26startIdx%3D6%26endIdx%3D11%26la" +
                "ng%3Dsv%26format%3Djson%26\"          }        }      },    \"PriceInfo\":{      \"Tariff" +
                "Zones\":{        \"$\":\"A\"        },      \"TariffRemark\":{        \"$\":\"2 biljett\"  " +
                "      }      }    },{    \"dur\":\"8\",    \"chg\":\"0\",    \"co2\":\"0.00\",    \"LegLis" +
                "t\":{      \"Leg\":{        \"idx\":\"0\",        \"name\":\"tunnelbanans blå linje 11\", " +
                "       \"type\":\"METRO\",        \"dir\":\"Kungsträdgården\",        \"line\":\"11\",    " +
                "    \"Origin\":{          \"name\":\"Solna centrum\",          \"type\":\"ST\",         " +
                " \"id\":\"400103212\",          \"lon\":\"17.998408\",          \"lat\":\"59.359584\",  " +
                "        \"routeIdx\":\"6\",          \"time\":\"22:23\",          \"date\":\"2015-09-07\"" +
                "          },        \"Destination\":{          \"name\":\"T-Centralen\",          \"type\":" +
                "\"ST\",          \"id\":\"400103052\",          \"lon\":\"18.062007\",          \"lat\":\"59" +
                ".332347\",          \"routeIdx\":\"11\",          \"time\":\"22:31\",          \"date\":\"20" +
                "15-09-07\"          },        \"JourneyDetailRef\":{          \"ref\":\"ref%3D257796%2F8901" +
                "6%2F639578%2F233858%2F74%3Fdate%3D2015-09-07%26station_evaId%3D400103212%26station_type%3Dd" +
                "ep%26lang%3Dsv%26format%3Djson%26\"          },        \"GeometryRef\":{          \"ref\":\"" +
                "ref%3D257796%2F89016%2F639578%2F233858%2F74%26startIdx%3D6%26endIdx%3D11%26lang%3Dsv%26format%" +
                "3Djson%26\"          }        }      },    \"PriceInfo\":{      \"TariffZones\":{        \"$\"" +
                ":\"A\"        },      \"TariffRemark\":{        \"$\":\"2 biljett\"        }      }    },{   " +
                " \"dur\":\"8\",    \"chg\":\"0\",    \"co2\":\"0.00\",    \"LegList\":{      \"Leg\":{        \"" +
                "idx\":\"0\",        \"name\":\"tunnelbanans blå linje 11\",        \"type\":\"METRO\",        \"" +
                "dir\":\"Kungsträdgården\",        \"line\":\"11\",        \"Origin\":{          \"name\":\"Solna " +
                "centrum\",          \"type\":\"ST\",          \"id\":\"400103212\",          \"lon\":\"17.998408\", " +
                "         \"lat\":\"59.359584\",          \"routeIdx\":\"6\",          \"time\":\"22:38\",         " +
                " \"date\":\"2015-09-07\"          },        \"Destination\":{          \"name\":\"T-Centralen\", " +
                "         \"type\":\"ST\",          \"id\":\"400103052\",          \"lon\":\"18.062007\",       " +
                "   \"lat\":\"59.332347\",          \"routeIdx\":\"11\",          \"time\":\"22:46\",          " +
                "\"date\":\"2015-09-07\"          },        \"JourneyDetailRef\":{          \"ref\":\"ref%3D680" +
                "106%2F229786%2F149800%2F151804%2F74%3Fdate%3D2015-09-07%26station_evaId%3D400103212%26station_" +
                "type%3Ddep%26lang%3Dsv%26format%3Djson%26\"          },        \"GeometryRef\":{          \"re" +
                "f\":\"ref%3D680106%2F229786%2F149800%2F151804%2F74%26startIdx%3D6%26endIdx%3D11%26lang%3Dsv%26" +
                "format%3Djson%26\"          }        }      },    \"PriceInfo\":{      \"TariffZones\":{      " +
                "  \"$\":\"A\"        },      \"TariffRemark\":{        \"$\":\"2 biljett\"        }      }    " +
                "},{    \"dur\":\"8\",    \"chg\":\"0\",    \"co2\":\"0.00\",    \"LegList\":{      \"Leg\":{   " +
                "     \"idx\":\"0\",        \"name\":\"tunnelbanans blå linje 11\",        \"type\":\"METRO\",   " +
                "     \"dir\":\"Kungsträdgården\",        \"line\":\"11\",        \"Origin\":{          \"name\"" +
                ":\"Solna centrum\",          \"type\":\"ST\",          \"id\":\"400103212\",          \"lon\":\"" +
                "17.998408\",          \"lat\":\"59.359584\",          \"routeIdx\":\"6\",          \"time\":\"22" +
                ":53\",          \"date\":\"2015-09-07\"          },        \"Destination\":{          \"name\":\"" +
                "T-Centralen\",          \"type\":\"ST\",          \"id\":\"400103052\",          \"lon\":\"18.06" +
                "2007\",          \"lat\":\"59.332347\",          \"routeIdx\":\"11\",          \"time\":\"23:01\", " +
                "         \"date\":\"2015-09-07\"          },        \"JourneyDetailRef\":{          \"ref\":\"ref%" +
                "3D784944%2F264732%2F490838%2F16232%2F74%3Fdate%3D2015-09-07%26station_evaId%3D400103212%26station" +
                "_type%3Ddep%26lang%3Dsv%26format%3Djson%26\"          },        \"GeometryRef\":{          \"re" +
                "f\":\"ref%3D784944%2F264732%2F490838%2F16232%2F74%26startIdx%3D6%26endIdx%3D11%26lang%3Dsv%26forma" +
                "t%3Djson%26\"          }        }      },    \"PriceInfo\":{      \"TariffZones\":{        \"$\":\"" +
                "A\"        },      \"TariffRemark\":{        \"$\":\"2 biljett\"        }      }    },{    \"dur\":" +
                "\"8\",    \"chg\":\"0\",    \"co2\":\"0.00\",    \"LegList\":{      \"Leg\":{        \"idx\":\"0\"," +
                "        \"name\":\"tunnelbanans blå linje 11\",        \"type\":\"METRO\",        \"dir\":\"Kungstr" +
                "ädgården\",        \"line\":\"11\",        \"Origin\":{          \"name\":\"Solna centrum\",        " +
                "  \"type\":\"ST\",          \"id\":\"400103212\",          \"lon\":\"17.998408\",          \"lat\":" +
                "\"59.359584\",          \"routeIdx\":\"6\",          \"time\":\"23:08\",          \"date\":\"2015-09" +
                "-07\"          },        \"Destination\":{          \"name\":\"T-Centralen\",          \"type\":\"ST\"" +
                ",          \"id\":\"400103052\",          \"lon\":\"18.062007\",          \"lat\":\"59.332347\",      " +
                "    \"routeIdx\":\"11\",          \"time\":\"23:16\",          \"date\":\"2015-09-07\"          },    " +
                "    \"JourneyDetailRef\":{          \"ref\":\"ref%3D253890%2F87714%2F49734%2F59767%2F74%3Fdate%3D2015-0" +
                "9-07%26station_evaId%3D400103212%26station_type%3Ddep%26lang%3Dsv%26format%3Djson%26\"          },    " +
                "    \"GeometryRef\":{          \"ref\":\"ref%3D253890%2F87714%2F49734%2F59767%2F74%26startIdx%3D6%26en" +
                "dIdx%3D11%26lang%3Dsv%26format%3Djson%26\"          }        }      },    \"PriceInfo\":{      \"Tarif" +
                "fZones\":{        \"$\":\"A\"        },      \"TariffRemark\":{        \"$\":\"2 biljett\"        }    " +
                "  }    }]  }}";
        }

        private string GetMultiZoneTest()
            {
                return "{\"TripList\":{" +
                       "  \"noNamespaceSchemaLocation\":\"hafasRestTrip.xsd\"," +
                       "  \"Trip\":[{" +
                       "    \"dur\":\"48\"," +
                       "    \"chg\":\"1\"," +
                       "    \"co2\":\"0.00\"," +
                       "    \"LegList\":{" +
                       "      \"Leg\":[{" +
                       "        \"idx\":\"0\"," +
                       "        \"name\":\"Tvärbanan 22\"," +
                       "        \"type\":\"TRAM\"," +
                       "        \"dir\":\"Solna station\"," +
                       "        \"line\":\"22\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Solna centrum\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400104547\"," +
                       "          \"lon\":\"17.996278\"," +
                       "          \"lat\":\"59.361337\"," +
                       "          \"routeIdx\":\"7\"," +
                       "          \"time\":\"22:28\"," +
                       "          \"date\":\"2015-09-09\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Solna station\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400104550\"," +
                       "          \"lon\":\"18.008198\"," +
                       "          \"lat\":\"59.363746\"," +
                       "          \"routeIdx\":\"8\"," +
                       "          \"time\":\"22:32\"," +
                       "          \"date\":\"2015-09-09\"" +
                       "          }," +
                       "        \"JourneyDetailRef\":{" +
                       "          \"ref\":\"ref%3D231288%2F82648%2F484596%2F165204%2F74%3Fdate%3D2015-09-09%26station_evaId%3D400104547%26station_type%3Ddep%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"ref%3D231288%2F82648%2F484596%2F165204%2F74%26startIdx%3D7%26endIdx%3D8%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        },{" +
                       "        \"idx\":\"1\"," +
                       "        \"name\":\"Gå\"," +
                       "        \"type\":\"WALK\"," +
                       "        \"hide\":\"true\"," +
                       "        \"dist\":\"316\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Solna station\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400104550\"," +
                       "          \"lon\":\"18.008198\"," +
                       "          \"lat\":\"59.363746\"," +
                       "          \"time\":\"22:33\"," +
                       "          \"date\":\"2015-09-09\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Solna\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400105032\"," +
                       "          \"lon\":\"18.009609\"," +
                       "          \"lat\":\"59.366497\"," +
                       "          \"time\":\"22:38\"," +
                       "          \"date\":\"2015-09-09\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"type%3DWALKLINK%26startx%3D18008198%26starty%3D59363746%26endx%3D18009609%26endy%3D59366497%26dt%3D2015-09-09T22%3A33%26h%3Dcdbacba3133e77940b6413eb328043f6%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        },{" +
                       "        \"idx\":\"2\"," +
                       "        \"name\":\"pendeltåg 38\"," +
                       "        \"type\":\"TRAIN\"," +
                       "        \"dir\":\"Uppsala C\"," +
                       "        \"line\":\"38\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Solna\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400105032\"," +
                       "          \"lon\":\"18.009609\"," +
                       "          \"lat\":\"59.366497\"," +
                       "          \"routeIdx\":\"5\"," +
                       "          \"time\":\"22:46\"," +
                       "          \"date\":\"2015-09-09\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Arlanda C\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400105001\"," +
                       "          \"lon\":\"17.928517\"," +
                       "          \"lat\":\"59.649387\"," +
                       "          \"routeIdx\":\"13\"," +
                       "          \"time\":\"23:16\"," +
                       "          \"date\":\"2015-09-09\"" +
                       "          }," +
                       "        \"JourneyDetailRef\":{" +
                       "          \"ref\":\"ref%3D439554%2F153048%2F330002%2F18483%2F74%3Fdate%3D2015-09-09%26station_evaId%3D400105032%26station_type%3Ddep%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"ref%3D439554%2F153048%2F330002%2F18483%2F74%26startIdx%3D5%26endIdx%3D13%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        }]" +
                       "      }," +
                       "    \"PriceInfo\":{" +
                       "      \"TariffMessages\":{" +
                       "        \"TariffMessage\":{" +
                       "          \"$\":\"Börjar eller slutar resan vid pendeltågsstationen Arlanda C, behövs en passagebiljett för att passera spärren. Biljetten kan du köpa när du påbörjar resan eller när du kommer till Arlanda.\"" +
                       "          }" +
                       "        }" +
                       "      }" +
                       "    },{" +
                       "    \"dur\":\"48\"," +
                       "    \"chg\":\"1\"," +
                       "    \"co2\":\"0.00\"," +
                       "    \"LegList\":{" +
                       "      \"Leg\":[{" +
                       "        \"idx\":\"0\"," +
                       "        \"name\":\"Tvärbanan 22\"," +
                       "        \"type\":\"TRAM\"," +
                       "        \"dir\":\"Solna station\"," +
                       "        \"line\":\"22\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Solna centrum\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400104547\"," +
                       "          \"lon\":\"17.996278\"," +
                       "          \"lat\":\"59.361337\"," +
                       "          \"routeIdx\":\"7\"," +
                       "          \"time\":\"22:58\"," +
                       "          \"date\":\"2015-09-09\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Solna station\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400104550\"," +
                       "          \"lon\":\"18.008198\"," +
                       "          \"lat\":\"59.363746\"," +
                       "          \"routeIdx\":\"8\"," +
                       "          \"time\":\"23:02\"," +
                       "          \"date\":\"2015-09-09\"" +
                       "          }," +
                       "        \"JourneyDetailRef\":{" +
                       "          \"ref\":\"ref%3D27249%2F14635%2F687172%2F334507%2F74%3Fdate%3D2015-09-09%26station_evaId%3D400104547%26station_type%3Ddep%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"ref%3D27249%2F14635%2F687172%2F334507%2F74%26startIdx%3D7%26endIdx%3D8%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        },{" +
                       "        \"idx\":\"1\"," +
                       "        \"name\":\"Gå\"," +
                       "        \"type\":\"WALK\"," +
                       "        \"hide\":\"true\"," +
                       "        \"dist\":\"316\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Solna station\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400104550\"," +
                       "          \"lon\":\"18.008198\"," +
                       "          \"lat\":\"59.363746\"," +
                       "          \"time\":\"23:03\"," +
                       "          \"date\":\"2015-09-09\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Solna\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400105032\"," +
                       "          \"lon\":\"18.009609\"," +
                       "          \"lat\":\"59.366497\"," +
                       "          \"time\":\"23:08\"," +
                       "          \"date\":\"2015-09-09\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"type%3DWALKLINK%26startx%3D18008198%26starty%3D59363746%26endx%3D18009609%26endy%3D59366497%26dt%3D2015-09-09T23%3A03%26h%3Dcdbacba3133e77940b6413eb328043f6%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        },{" +
                       "        \"idx\":\"2\"," +
                       "        \"name\":\"pendeltåg 38\"," +
                       "        \"type\":\"TRAIN\"," +
                       "        \"dir\":\"Uppsala C\"," +
                       "        \"line\":\"38\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Solna\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400105032\"," +
                       "          \"lon\":\"18.009609\"," +
                       "          \"lat\":\"59.366497\"," +
                       "          \"routeIdx\":\"5\"," +
                       "          \"time\":\"23:16\"," +
                       "          \"date\":\"2015-09-09\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Arlanda C\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400105001\"," +
                       "          \"lon\":\"17.928517\"," +
                       "          \"lat\":\"59.649387\"," +
                       "          \"routeIdx\":\"13\"," +
                       "          \"time\":\"23:46\"," +
                       "          \"date\":\"2015-09-09\"" +
                       "          }," +
                       "        \"JourneyDetailRef\":{" +
                       "          \"ref\":\"ref%3D224088%2F81171%2F340336%2F95472%2F74%3Fdate%3D2015-09-09%26station_evaId%3D400105032%26station_type%3Ddep%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"ref%3D224088%2F81171%2F340336%2F95472%2F74%26startIdx%3D5%26endIdx%3D13%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        }]" +
                       "      }," +
                       "    \"PriceInfo\":{" +
                       "      \"TariffMessages\":{" +
                       "        \"TariffMessage\":{" +
                       "          \"$\":\"Börjar eller slutar resan vid pendeltågsstationen Arlanda C, behövs en passagebiljett för att passera spärren. Biljetten kan du köpa när du påbörjar resan eller när du kommer till Arlanda.\"" +
                       "          }" +
                       "        }" +
                       "      }" +
                       "    },{" +
                       "    \"dur\":\"48\"," +
                       "    \"chg\":\"1\"," +
                       "    \"co2\":\"0.00\"," +
                       "    \"LegList\":{" +
                       "      \"Leg\":[{" +
                       "        \"idx\":\"0\"," +
                       "        \"name\":\"Tvärbanan 22\"," +
                       "        \"type\":\"TRAM\"," +
                       "        \"dir\":\"Solna station\"," +
                       "        \"line\":\"22\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Solna centrum\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400104547\"," +
                       "          \"lon\":\"17.996278\"," +
                       "          \"lat\":\"59.361337\"," +
                       "          \"routeIdx\":\"7\"," +
                       "          \"time\":\"23:58\"," +
                       "          \"date\":\"2015-09-09\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Solna station\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400104550\"," +
                       "          \"lon\":\"18.008198\"," +
                       "          \"lat\":\"59.363746\"," +
                       "          \"routeIdx\":\"8\"," +
                       "          \"time\":\"00:02\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"JourneyDetailRef\":{" +
                       "          \"ref\":\"ref%3D408033%2F141563%2F444558%2F86276%2F74%3Fdate%3D2015-09-09%26station_evaId%3D400104547%26station_type%3Ddep%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"ref%3D408033%2F141563%2F444558%2F86276%2F74%26startIdx%3D7%26endIdx%3D8%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        },{" +
                       "        \"idx\":\"1\"," +
                       "        \"name\":\"Gå\"," +
                       "        \"type\":\"WALK\"," +
                       "        \"hide\":\"true\"," +
                       "        \"dist\":\"316\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Solna station\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400104550\"," +
                       "          \"lon\":\"18.008198\"," +
                       "          \"lat\":\"59.363746\"," +
                       "          \"time\":\"00:03\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Solna\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400105032\"," +
                       "          \"lon\":\"18.009609\"," +
                       "          \"lat\":\"59.366497\"," +
                       "          \"time\":\"00:08\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"type%3DWALKLINK%26startx%3D18008198%26starty%3D59363746%26endx%3D18009609%26endy%3D59366497%26dt%3D2015-09-10T00%3A03%26h%3Dcdbacba3133e77940b6413eb328043f6%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        },{" +
                       "        \"idx\":\"2\"," +
                       "        \"name\":\"pendeltåg 38\"," +
                       "        \"type\":\"TRAIN\"," +
                       "        \"dir\":\"Uppsala C\"," +
                       "        \"line\":\"38\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Solna\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400105032\"," +
                       "          \"lon\":\"18.009609\"," +
                       "          \"lat\":\"59.366497\"," +
                       "          \"routeIdx\":\"5\"," +
                       "          \"time\":\"00:16\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Arlanda C\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400105001\"," +
                       "          \"lon\":\"17.928517\"," +
                       "          \"lat\":\"59.649387\"," +
                       "          \"routeIdx\":\"13\"," +
                       "          \"time\":\"00:46\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"JourneyDetailRef\":{" +
                       "          \"ref\":\"ref%3D91005%2F36812%2F540338%2F239834%2F74%3Fdate%3D2015-09-10%26station_evaId%3D400105032%26station_type%3Ddep%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"ref%3D91005%2F36812%2F540338%2F239834%2F74%26startIdx%3D5%26endIdx%3D13%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        }]" +
                       "      }," +
                       "    \"PriceInfo\":{" +
                       "      \"TariffMessages\":{" +
                       "        \"TariffMessage\":{" +
                       "          \"$\":\"Börjar eller slutar resan vid pendeltågsstationen Arlanda C, behövs en passagebiljett för att passera spärren. Biljetten kan du köpa när du påbörjar resan eller när du kommer till Arlanda.\"" +
                       "          }" +
                       "        }" +
                       "      }" +
                       "    },{" +
                       "    \"dur\":\"147\"," +
                       "    \"chg\":\"2\"," +
                       "    \"co2\":\"4.30\"," +
                       "    \"LegList\":{" +
                       "      \"Leg\":[{" +
                       "        \"idx\":\"0\"," +
                       "        \"name\":\"buss 197\"," +
                       "        \"type\":\"BUS\"," +
                       "        \"dir\":\"Stockholm C\"," +
                       "        \"line\":\"197\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Solna centrum (på Huvudstagatan)\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400112506\"," +
                       "          \"lon\":\"17.996305\"," +
                       "          \"lat\":\"59.359018\"," +
                       "          \"routeIdx\":\"27\"," +
                       "          \"time\":\"02:16\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Centralen (Vasagatan)\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400110843\"," +
                       "          \"lon\":\"18.059661\"," +
                       "          \"lat\":\"59.330036\"," +
                       "          \"routeIdx\":\"35\"," +
                       "          \"time\":\"02:31\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"JourneyDetailRef\":{" +
                       "          \"ref\":\"ref%3D322743%2F125065%2F781234%2F283037%2F74%3Fdate%3D2015-09-10%26station_evaId%3D400112506%26station_type%3Ddep%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"ref%3D322743%2F125065%2F781234%2F283037%2F74%26startIdx%3D27%26endIdx%3D35%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        },{" +
                       "        \"idx\":\"1\"," +
                       "        \"name\":\"Gå\"," +
                       "        \"type\":\"WALK\"," +
                       "        \"hide\":\"true\"," +
                       "        \"dist\":\"21\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Centralen (Vasagatan)\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400110843\"," +
                       "          \"lon\":\"18.059661\"," +
                       "          \"lat\":\"59.330036\"," +
                       "          \"time\":\"02:32\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Centralen (Vasagatan)\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400152323\"," +
                       "          \"lon\":\"18.059742\"," +
                       "          \"lat\":\"59.329857\"," +
                       "          \"time\":\"02:34\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"type%3DWALKLINK%26startx%3D18059661%26starty%3D59330036%26endx%3D18059742%26endy%3D59329857%26dt%3D2015-09-10T02%3A32%26h%3D1746b9b7d326a2f2eeb5fd3f61ad14de%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        },{" +
                       "        \"idx\":\"2\"," +
                       "        \"name\":\"Gå\"," +
                       "        \"type\":\"WALK\"," +
                       "        \"hide\":\"true\"," +
                       "        \"dist\":\"34\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Centralen (Vasagatan)\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400152323\"," +
                       "          \"lon\":\"18.059742\"," +
                       "          \"lat\":\"59.329857\"," +
                       "          \"time\":\"02:34\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Centralen (Vasagatan)\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400152307\"," +
                       "          \"lon\":\"18.060020\"," +
                       "          \"lat\":\"59.330126\"," +
                       "          \"time\":\"02:36\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"type%3DWALKLINK%26startx%3D18059742%26starty%3D59329857%26endx%3D18060020%26endy%3D59330126%26dt%3D2015-09-10T02%3A34%26h%3Df114450f62f1d54230d494032009ed51%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        },{" +
                       "        \"idx\":\"3\"," +
                       "        \"name\":\"buss 593\"," +
                       "        \"type\":\"BUS\"," +
                       "        \"dir\":\"Uppsala via Arlanda\"," +
                       "        \"line\":\"593\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Centralen (Vasagatan)\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400152307\"," +
                       "          \"lon\":\"18.060020\"," +
                       "          \"lat\":\"59.330126\"," +
                       "          \"routeIdx\":\"0\"," +
                       "          \"time\":\"02:50\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Knivsta station\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400168634\"," +
                       "          \"lon\":\"17.786443\"," +
                       "          \"lat\":\"59.727342\"," +
                       "          \"routeIdx\":\"16\"," +
                       "          \"time\":\"03:55\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"JourneyDetailRef\":{" +
                       "          \"ref\":\"ref%3D8691%2F30420%2F675568%2F334889%2F74%3Fdate%3D2015-09-10%26station_evaId%3D400152307%26station_type%3Ddep%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"ref%3D8691%2F30420%2F675568%2F334889%2F74%26startIdx%3D0%26endIdx%3D16%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        },{" +
                       "        \"idx\":\"4\"," +
                       "        \"name\":\"Gå\"," +
                       "        \"type\":\"WALK\"," +
                       "        \"hide\":\"true\"," +
                       "        \"dist\":\"4\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Knivsta station\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400168634\"," +
                       "          \"lon\":\"17.786443\"," +
                       "          \"lat\":\"59.727342\"," +
                       "          \"time\":\"03:56\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Knivsta station\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400168635\"," +
                       "          \"lon\":\"17.786443\"," +
                       "          \"lat\":\"59.727306\"," +
                       "          \"time\":\"03:57\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"type%3DWALKLINK%26startx%3D17786443%26starty%3D59727342%26endx%3D17786443%26endy%3D59727306%26dt%3D2015-09-10T03%3A56%26h%3D381febc88c4ff4eecdb5802d47c86c14%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        },{" +
                       "        \"idx\":\"5\"," +
                       "        \"name\":\"Gå\"," +
                       "        \"type\":\"WALK\"," +
                       "        \"hide\":\"true\"," +
                       "        \"dist\":\"88\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Knivsta station\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400168635\"," +
                       "          \"lon\":\"17.786443\"," +
                       "          \"lat\":\"59.727306\"," +
                       "          \"time\":\"03:57\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Knivsta\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400105006\"," +
                       "          \"lon\":\"17.786937\"," +
                       "          \"lat\":\"59.726551\"," +
                       "          \"time\":\"03:58\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"type%3DWALKLINK%26startx%3D17786443%26starty%3D59727306%26endx%3D17786937%26endy%3D59726551%26dt%3D2015-09-10T03%3A57%26h%3Dd36db52c9138090a3eb674f9ddd0df8d%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        },{" +
                       "        \"idx\":\"6\"," +
                       "        \"name\":\"pendeltåg 38\"," +
                       "        \"type\":\"TRAIN\"," +
                       "        \"dir\":\"Tumba\"," +
                       "        \"line\":\"38\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Knivsta\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400105006\"," +
                       "          \"lon\":\"17.786937\"," +
                       "          \"lat\":\"59.726551\"," +
                       "          \"routeIdx\":\"1\"," +
                       "          \"time\":\"04:35\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Arlanda C\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400105001\"," +
                       "          \"lon\":\"17.928517\"," +
                       "          \"lat\":\"59.649387\"," +
                       "          \"routeIdx\":\"2\"," +
                       "          \"time\":\"04:43\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"JourneyDetailRef\":{" +
                       "          \"ref\":\"ref%3D128640%2F49287%2F763076%2F338658%2F74%3Fdate%3D2015-09-10%26station_evaId%3D400105006%26station_type%3Ddep%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"ref%3D128640%2F49287%2F763076%2F338658%2F74%26startIdx%3D1%26endIdx%3D2%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        }]" +
                       "      }," +
                       "    \"PriceInfo\":{" +
                       "      \"TariffMessages\":{" +
                       "        \"TariffMessage\":[{" +
                       "          \"$\":\"Vid lokala resor i Upplands län gäller UL-biljetter. För resa över länsgränsen behövs biljett för både SL och UL. Se sl.se eller ul.se för mer information.\"" +
                       "          },{" +
                       "          \"$\":\"Börjar eller slutar resan vid pendeltågsstationen Arlanda C, behövs en passagebiljett för att passera spärren. Biljetten kan du köpa när du påbörjar resan eller när du kommer till Arlanda.\"" +
                       "          }]" +
                       "        }" +
                       "      }" +
                       "    },{" +
                       "    \"dur\":\"90\"," +
                       "    \"chg\":\"1\"," +
                       "    \"co2\":\"0.39\"," +
                       "    \"LegList\":{" +
                       "      \"Leg\":[{" +
                       "        \"idx\":\"0\"," +
                       "        \"name\":\"buss 197\"," +
                       "        \"type\":\"BUS\"," +
                       "        \"dir\":\"Stockholm C\"," +
                       "        \"line\":\"197\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Solna centrum (på Huvudstagatan)\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400112506\"," +
                       "          \"lon\":\"17.996305\"," +
                       "          \"lat\":\"59.359018\"," +
                       "          \"routeIdx\":\"27\"," +
                       "          \"time\":\"03:16\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Centralen (Vasagatan)\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400110843\"," +
                       "          \"lon\":\"18.059661\"," +
                       "          \"lat\":\"59.330036\"," +
                       "          \"routeIdx\":\"35\"," +
                       "          \"time\":\"03:31\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"JourneyDetailRef\":{" +
                       "          \"ref\":\"ref%3D910458%2F320975%2F743602%2F68315%2F74%3Fdate%3D2015-09-10%26station_evaId%3D400112506%26station_type%3Ddep%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"ref%3D910458%2F320975%2F743602%2F68315%2F74%26startIdx%3D27%26endIdx%3D35%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        },{" +
                       "        \"idx\":\"1\"," +
                       "        \"name\":\"Gå\"," +
                       "        \"type\":\"WALK\"," +
                       "        \"hide\":\"true\"," +
                       "        \"dist\":\"132\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Centralen (Vasagatan)\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400110843\"," +
                       "          \"lon\":\"18.059661\"," +
                       "          \"lat\":\"59.330036\"," +
                       "          \"time\":\"03:32\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Stockholms central\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400105014\"," +
                       "          \"lon\":\"18.057755\"," +
                       "          \"lat\":\"59.329362\"," +
                       "          \"time\":\"03:36\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"type%3DWALKLINK%26startx%3D18059661%26starty%3D59330036%26endx%3D18057755%26endy%3D59329362%26dt%3D2015-09-10T03%3A32%26h%3Da22f33d59407331910e7173860a3d53a%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        },{" +
                       "        \"idx\":\"2\"," +
                       "        \"name\":\"pendeltåg 38\"," +
                       "        \"type\":\"TRAIN\"," +
                       "        \"dir\":\"Uppsala C\"," +
                       "        \"line\":\"38\"," +
                       "        \"Origin\":{" +
                       "          \"name\":\"Stockholms central\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400105014\"," +
                       "          \"lon\":\"18.057755\"," +
                       "          \"lat\":\"59.329362\"," +
                       "          \"routeIdx\":\"0\"," +
                       "          \"time\":\"04:09\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"Destination\":{" +
                       "          \"name\":\"Arlanda C\"," +
                       "          \"type\":\"ST\"," +
                       "          \"id\":\"400105001\"," +
                       "          \"lon\":\"17.928517\"," +
                       "          \"lat\":\"59.649387\"," +
                       "          \"routeIdx\":\"10\"," +
                       "          \"time\":\"04:46\"," +
                       "          \"date\":\"2015-09-10\"" +
                       "          }," +
                       "        \"JourneyDetailRef\":{" +
                       "          \"ref\":\"ref%3D905430%2F308345%2F119940%2F241840%2F74%3Fdate%3D2015-09-10%26station_evaId%3D400105014%26station_type%3Ddep%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }," +
                       "        \"GeometryRef\":{" +
                       "          \"ref\":\"ref%3D905430%2F308345%2F119940%2F241840%2F74%26startIdx%3D0%26endIdx%3D10%26lang%3Dsv%26format%3Djson%26\"" +
                       "          }" +
                       "        }]" +
                       "      }," +
                       "    \"PriceInfo\":{" +
                       "      \"TariffMessages\":{" +
                       "        \"TariffMessage\":{" +
                       "          \"$\":\"Börjar eller slutar resan vid pendeltågsstationen Arlanda C, behövs en passagebiljett för att passera spärren. Biljetten kan du köpa när du påbörjar resan eller när du kommer till Arlanda.\"" +
                       "          }" +
                       "        }" +
                       "      }" +
                       "    }]" +
                       "  }" +
                       "}";
            }
    }
}

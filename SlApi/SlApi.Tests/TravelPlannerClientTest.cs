using System;
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
                            "https://api.sl.se/api2/TravelplannerV2/trip.json/?date=2015-09-07&time=22:00&originId=9305&destId=9001&key=" + fakekey)))
                .ReturnsAsync(GetTestResponse());
            var t = new TravelPlannerClient(new HttpClient(mockedHttpRequest.Object)
            {
                ApiToken = fakekey
            });


            var resultAsync = t.TripAsync(new TripRequest { DateTime = new DateTime(2015, 9, 7, 22, 0, 0, DateTimeKind.Local), OriginId = "9305", DestId = "9001" });
            resultAsync.Wait();
            var result = resultAsync.Result;
            var f = result.TripList.Trip.FirstOrDefault();

            Assert.IsTrue(f != null);
            Assert.IsTrue(f.LegList.Leg.Direction == "Kungsträdgården");

        }
    }
}

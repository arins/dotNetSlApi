using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlApi.Models.TravelPlanner.Response;

namespace SlApi.Tests.Models.TravelPlanner.Response
{
    [TestClass]
    public class LegPlaceTest
    {
        [TestMethod]
        public void LegPlaceDateTimeTest()
        {
            var legPlace1 = new LegPlace {DateTime = new DateTime(2010, 1, 1, 10, 10, 20, DateTimeKind.Local)};
            Assert.IsTrue(legPlace1.Date == "2010-01-01");
            Assert.IsTrue(legPlace1.Time == "10:10");

            var legPlace2 = new LegPlace { DateTime = new DateTime(2010, 1, 1, 22, 10, 20, DateTimeKind.Local) };
            Assert.IsTrue(legPlace2.Date == "2010-01-01");
            Assert.IsTrue(legPlace2.Time == "22:10");

            legPlace2.Date = "2020-03-05";
            legPlace2.Time = "22:13";

            Assert.IsTrue(legPlace2.DateTime.Year == 2020);
            Assert.IsTrue(legPlace2.DateTime.Month == 3);
            Assert.IsTrue(legPlace2.DateTime.Day == 5);

            Assert.IsTrue(legPlace2.DateTime.Hour == 22);
            Assert.IsTrue(legPlace2.DateTime.Minute == 13);

        }
    }
}

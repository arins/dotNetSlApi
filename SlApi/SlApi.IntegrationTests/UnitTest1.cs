using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SlApi.IntegrationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Trace.WriteLine(Environment.UserDomainName);
            var test = EnvironmentHelper.GetEnvironmentVariable("PlaceSearchClientApiToken");
           
            if (test != null)
            {
                Assert.IsTrue("43c8b38e98414ef8bce521e939ee9643".Equals(test));
            }
            else
            {
                Trace.WriteLine("PlaceSearchClientApiToken missing");
                Assert.Fail("PlaceSearchClientApiToken missing");
            }
        }
    }
}

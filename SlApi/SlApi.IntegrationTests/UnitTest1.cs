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
            var test = Environment.GetEnvironmentVariable("PlaceSearchClientApiToken",EnvironmentVariableTarget.Machine);
            if (test != null)
            {
                Trace.WriteLine(" EnvironmentVariableTarget.Machine");
            }
            if (test == null)
            {
                test = Environment.GetEnvironmentVariable("PlaceSearchClientApiToken", EnvironmentVariableTarget.User);
                if (test != null)
                {
                    Trace.WriteLine(" EnvironmentVariableTarget.User");
                }
            }
            if (test == null)
            {
                test = Environment.GetEnvironmentVariable("PlaceSearchClientApiToken", EnvironmentVariableTarget.Process);
                if (test != null)
                {
                    Trace.WriteLine(" EnvironmentVariableTarget.Process");
                }
            }
            if (test == null)
            {
                test = Environment.GetEnvironmentVariable("PlaceSearchClientApiToken");
                if (test != null)
                {
                    Trace.WriteLine(" EnvironmentVariableTarget.User");
                }
            }
            if (test != null)
            {
                Trace.WriteLine("PlaceSearchClientApiToken: " + test);
            }
            else
            {
                Trace.WriteLine("PlaceSearchClientApiToken missing");
                Assert.Fail("PlaceSearchClientApiToken missing");
            }
        }
    }
}

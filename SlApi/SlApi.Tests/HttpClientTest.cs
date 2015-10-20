using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlApi.Core;

namespace SlApi.Tests
{
    [TestClass]
    public class HttpClientTest : SlApiTest
    {
        [TestMethod]
        [DeploymentItem("TestData\\HttpClientTest\\invalidJson.json", "TestData\\HttpClientTest")]
        public void HttpRequestFailShouldReturnResponseString()
        {
            var t = new HttpClient("https://raw.githubusercontent.com", new HttpRequester(), new UrlHelper());
            t.EnableDebugInformationInException = true;
            try
            {
                t.DoRequest<SlApi.Models.TravelPlanner.JourneyDirections>("/arins/dotNetSlApi/master/SlApi/SlApi.Tests/TestData/HttpClientTest/invalidJson.json");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is HttpRequestException);
                var hex = (HttpRequestException) ex;
                Assert.IsTrue(hex.Response?.Equals(GetSampleResponse("TestData\\HttpClientTest\\invalidJson.json")) ?? false);
            }
        }

        public Stream InvalidJson()
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(GetSampleResponse("TestData\\HttpClientTest\\invalidJson.json"));
            sw.AutoFlush = true;
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
    }
}

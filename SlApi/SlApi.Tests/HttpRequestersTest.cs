using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SlApi.Tests
{
    [TestClass]
    public class HttpRequestersTest
    {
        [TestMethod]
        public void RequestToSlTest()
        {
            var req = new HttpRequester
            {
                Timeout = 10000,
                GzipEnabled = false
            };
            var result = req.GetResponse(new Uri("https://api.sl.se/api2/typeahead.json?key=asd&searchstring=solna"));
            Assert.IsTrue(result.Equals("{\"StatusCode\":1002,\"Message\":\"problem with request: Key is invalid\"}"));
        }

        [TestMethod]
        public void RequestToSlWithGZipTest()
        {
            var req = new HttpRequester
            {
                Timeout = 10000,
                GzipEnabled = false
            };
            var result = req.GetResponse(new Uri("https://api.sl.se/api2/typeahead.json?key=asd&searchstring=solna"));
            Assert.IsTrue(result.Equals("{\"StatusCode\":1002,\"Message\":\"problem with request: Key is invalid\"}"));
        }


        [TestMethod]
        public void RequestToSlAsyncTest()
        {
            var req = new HttpRequester
            {
                Timeout = 10000,
                GzipEnabled = false
            };
            var resultTask = req.GetResponseAsync(new Uri("https://api.sl.se/api2/typeahead.json?key=asd&searchstring=solna"));
            resultTask.Wait();
            var result = resultTask.Result;
            Assert.IsTrue(result.Equals("{\"StatusCode\":1002,\"Message\":\"problem with request: Key is invalid\"}"));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlApi.Core;
using SlApi.Models.Request;

namespace SlApi.Tests
{
    [TestClass]
    public class PlaceSearchServiceTest
    {
        [TestMethod]
        public void Search()
        {
            var search = new PlaceSearchService(new Client(new HttpRequester()))
            {
                ApiToken = ""
            };
            var result = search.Search(new SearchRequest
            {
                MaxResults = 10,
                SearchString = "Solna",
                StationsOnly = false
            });
            Assert.IsFalse(false);
        }
    }
}

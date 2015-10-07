using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using SlApi.Core;

namespace SlApi.Tests
{
    public class HttpRequestMocker
    {
        public IHttpRequester GetMockedRequesterFor(Uri url, string dataResponse)
        {
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
               x =>
                   x.GetResponse(
                      url))
               .Returns(dataResponse);
            return mockedHttpRequest.Object;
        }

        public IHttpRequester GetMockedAsyncRequesterFor(Uri url, string dataResponse)
        {
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
               x =>
                   x.GetResponseAsync(
                      url))
               .ReturnsAsync(dataResponse);
            return mockedHttpRequest.Object;
        }



    }
}

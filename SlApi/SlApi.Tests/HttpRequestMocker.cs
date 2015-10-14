using System;
using System.IO;
using Moq;
using SlApi.Core;

namespace SlApi.Tests
{
    public class HttpRequestMocker
    {
        public IHttpRequester GetMockedRequesterFor(Uri url, Stream dataResponse)
        {
            var mockedHttpRequest = new Mock<IHttpRequester>();
            mockedHttpRequest.Setup(
               x =>
                   x.GetResponseStream(
                      url))
               .Returns(dataResponse);
            mockedHttpRequest.Setup(
               x =>
                   x.GetResponseStreamAsync(
                      url))
               .ReturnsAsync(dataResponse);
            return mockedHttpRequest.Object;
        }
    }
}

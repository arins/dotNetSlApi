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
                .Returns(new StreamAndHeaders
                {
                    Stream = dataResponse
                });
            mockedHttpRequest.Setup(
                x =>
                    x.GetResponseStreamAsync(
                        url))
                .ReturnsAsync(new StreamAndHeaders
                {
                    Stream = dataResponse
                });
            return mockedHttpRequest.Object;
        }
    }

}

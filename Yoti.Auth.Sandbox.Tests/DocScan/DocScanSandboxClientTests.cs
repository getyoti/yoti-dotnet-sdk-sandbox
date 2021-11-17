using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Moq;
using Xunit;
using Yoti.Auth.Sandbox.DocScan.Request;
using Yoti.Auth.Tests.Common;

namespace Yoti.Auth.Sandbox.Tests.DocScan
{
    public class DocScanSandboxClientTests
    {
        private const string _someSdkId = "someSdkId";
        private const string _someSessionId = "someSessionId";
        private readonly SandboxClient _yotiDocScanSandboxClient;
        private static readonly Uri _someUri = new Uri("https://www.test.com");
        private readonly ResponseConfig _sandboxResponseConfig;

        public DocScanSandboxClientTests()
        {
            _yotiDocScanSandboxClient = SandboxClient.Builder()
                .WithApiUri(_someUri)
                .WithClientSdkId(_someSdkId)
                .WithKeyPair(KeyPair.Get())
                .Build();

            _sandboxResponseConfig = new ResponseConfigBuilder().Build();
        }

        [Fact]
        public void ConfigureSessionResponseShouldWrapIOException()
        {
            var mockJsonConvert = new Mock<Encoding>();
            mockJsonConvert.Setup(
                x => x.GetBytes(It.IsAny<string>()))
                    .Throws(new IOException());

            Assert.Throws<SandboxException>(() =>
            {
                _yotiDocScanSandboxClient.ConfigureSessionResponse(
                    _someSessionId,
                    _sandboxResponseConfig);
            });
        }

        [Fact]
        public void ConfigureSessionResponseShouldNotThrowException()
        {
            using (var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            })
            {
                SandboxClient docScanSandboxClient;
                Mock<HttpMessageHandler> handlerMock = HttpMock.SetupMockMessageHandler(httpResponseMessage);

                using var httpClient = new HttpClient(handlerMock.Object);
                docScanSandboxClient = SandboxClient.Builder(httpClient)
                    .WithClientSdkId(_someSdkId)
                    .WithKeyPair(KeyPair.Get())
                    .Build();

                var ex = Record.Exception(() => docScanSandboxClient.ConfigureSessionResponse(
                    _someSessionId,
                    _sandboxResponseConfig));

                Assert.Null(ex);
            };
        }

        [Fact]
        public void ConfigureSessionResponseShouldThrowForNonSuccessCode()
        {
            using (var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent("{}")
            })
            {
                SandboxClient docScanSandboxClient;
                Mock<HttpMessageHandler> handlerMock = HttpMock.SetupMockMessageHandler(httpResponseMessage);

                using var httpClient = new HttpClient(handlerMock.Object);
                docScanSandboxClient = SandboxClient.Builder(httpClient)
                    .WithClientSdkId(_someSdkId)
                    .WithKeyPair(KeyPair.Get())
                    .Build();

                var exception = Assert.Throws<SandboxException>(() =>
                {
                    docScanSandboxClient.ConfigureSessionResponse(
                          _someSessionId,
                    _sandboxResponseConfig);
                });

                Assert.Contains("Failed validation - Status Code: '400' (BadRequest). Content: '{}'", exception.Message, StringComparison.Ordinal);
            };
        }

        [Fact]
        public void ConfigureApplicationResponseShouldWrapIOException()
        {
            var mockJsonConvert = new Mock<Encoding>();
            mockJsonConvert.Setup(
                x => x.GetBytes(It.IsAny<string>()))
                    .Throws(new IOException());

            Assert.Throws<SandboxException>(() =>
            {
                _yotiDocScanSandboxClient.ConfigureApplicationResponse(
                    _sandboxResponseConfig);
            });
        }

        [Fact]
        public void ConfigureApplicationResponseShouldNotError()
        {
            string tokenValue = "kyHPjq2+Y48cx+9yS/XzmW09jVUylSdhbP+3Q9Tc9p6bCEnyfa8vj38";

            using (var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"token\": \"" + tokenValue + "\"}")
            })
            {
                SandboxClient docScanSandboxClient;
                Mock<HttpMessageHandler> handlerMock = HttpMock.SetupMockMessageHandler(httpResponseMessage);

                using var httpClient = new HttpClient(handlerMock.Object);
                docScanSandboxClient = SandboxClient.Builder(httpClient)
                    .WithClientSdkId(_someSdkId)
                    .WithKeyPair(KeyPair.Get())
                    .Build();

                docScanSandboxClient.ConfigureApplicationResponse(
                    _sandboxResponseConfig);
            };
        }

        [Fact]
        public void ConfigureApplicationResponseShouldThrowForNonSuccessCode()
        {
            using (var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent("{}")
            })
            {
                SandboxClient docScanSandboxClient;
                Mock<HttpMessageHandler> handlerMock = HttpMock.SetupMockMessageHandler(httpResponseMessage);

                using var httpClient = new HttpClient(handlerMock.Object);
                docScanSandboxClient = SandboxClient.Builder(httpClient)
                    .WithClientSdkId(_someSdkId)
                    .WithKeyPair(KeyPair.Get())
                    .Build();

                var exception = Assert.Throws<SandboxException>(() =>
                {
                    docScanSandboxClient.ConfigureApplicationResponse(
                    _sandboxResponseConfig);
                });

                Assert.Contains("Failed validation - Status Code: '400' (BadRequest). Content: '{}'", exception.Message, StringComparison.Ordinal);
            };
        }
    }
}
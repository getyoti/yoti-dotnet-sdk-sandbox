using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Moq;
using Xunit;
using Yoti.Auth.Sandbox.Profile;
using Yoti.Auth.Sandbox.Profile.Request;
using Yoti.Auth.Tests.Common;

namespace Yoti.Auth.Sandbox.Tests.Profile
{
    public class DocScanSandboxClientTests
    {
        private const string _someSdkId = "someAppId";
        private readonly SandboxClient _yotiSandboxClient;
        private readonly YotiTokenRequest _yotiTokenRequest;
        private static readonly Uri _someUri = new Uri("https://www.test.com");

        public DocScanSandboxClientTests()
        {
            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback +=
                    (sender, cert, chain, sslPolicyErrors) => true;

                using var httpClient = new HttpClient(handler);
                _yotiSandboxClient = new SandboxClientBuilder(httpClient)
                    .WithApiUri(_someUri)
                    .WithClientSdkId(_someSdkId)
                    .WithKeyPair(KeyPair.Get())
                    .Build();
            }

            _yotiTokenRequest = new YotiTokenRequestBuilder().Build();
        }

        [Fact]
        public static void BuilderShouldThrowForMissingSdkId()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                SandboxClient.Builder()
                .WithApiUri(_someUri)
                .WithKeyPair(KeyPair.Get())
                .Build();
            });

            Assert.Contains("_sdkId", exception.Message, StringComparison.Ordinal);
        }

        [Fact]
        public static void BuilderShouldThrowForMissingKey()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                SandboxClient.Builder()
                .WithApiUri(_someUri)
                .WithClientSdkId(_someSdkId)
                .Build();
            });

            Assert.Contains("keyPair", exception.Message, StringComparison.Ordinal);
        }

        [Fact]
        public static void BuilderShouldCreateClient()
        {
            var sandboxClient = SandboxClient.Builder()
                .WithClientSdkId(_someSdkId)
                .WithKeyPair(KeyPair.Get())
                .WithApiUri(_someUri)
                .Build();

            Assert.NotNull(sandboxClient);
        }

        [Fact]
        public void SetupSharingProfileShouldWrapIOException()
        {
            var mockJsonConvert = new Mock<Encoding>();
            mockJsonConvert.Setup(
                x => x.GetBytes(It.IsAny<string>()))
                    .Throws(new IOException());

            Assert.Throws<SandboxException>(() =>
            {
                _yotiSandboxClient.SetupSharingProfile(
                    _yotiTokenRequest);
            });
        }

        [Fact]
        public void SetupSharingProfileShouldReturnToken()
        {
            string tokenValue = "kyHPjq2+Y48cx+9yS/XzmW09jVUylSdhbP+3Q9Tc9p6bCEnyfa8vj38";

            using (var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"token\": \"" + tokenValue + "\"}")
            })
            {
                SandboxClient yotiSandboxClient;
                Mock<HttpMessageHandler> handlerMock = HttpMock.SetupMockMessageHandler(httpResponseMessage);

                using var httpClient = new HttpClient(handlerMock.Object);
                yotiSandboxClient = new SandboxClientBuilder(httpClient)
                    .WithClientSdkId(_someSdkId)
                    .WithKeyPair(KeyPair.Get())
                    .Build();

                string result = yotiSandboxClient.SetupSharingProfile(
                        _yotiTokenRequest);

                Assert.Equal(tokenValue, result);
            };
        }

        [Fact]
        public void SetupSharingProfileShouldThrowForNonSuccessCode()
        {
            using (var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent("{}")
            })
            {
                SandboxClient yotiSandboxClient;
                Mock<HttpMessageHandler> handlerMock = HttpMock.SetupMockMessageHandler(httpResponseMessage);

                using var httpClient = new HttpClient(handlerMock.Object);
                yotiSandboxClient = new SandboxClientBuilder(httpClient)
                    .WithClientSdkId(_someSdkId)
                    .WithKeyPair(KeyPair.Get())
                    .Build();

                var exception = Assert.Throws<SandboxException>(() =>
                {
                    yotiSandboxClient.SetupSharingProfile(
                        _yotiTokenRequest);
                });

                Assert.Contains("Error when setting up sharing profile", exception.Message, StringComparison.Ordinal);
            };
        }

        [Fact]
        public static void BuilderShouldUseGivenApiUri()
        {
            var sandboxClient = SandboxClient.Builder()
                .WithClientSdkId(_someSdkId)
                .WithKeyPair(KeyPair.Get())
                .WithApiUri(_someUri)
                .Build();

            Assert.Equal(_someUri, sandboxClient.SandboxApiUri);
        }

        [Fact]
        public static void BuilderShouldUseDefaultApiUri()
        {
            var sandboxClient = SandboxClient.Builder()
                .WithClientSdkId(_someSdkId)
                .WithKeyPair(KeyPair.Get())
                .Build();

            Assert.Equal(new Uri("https://api.yoti.com/sandbox/v1"), sandboxClient.SandboxApiUri);
        }
    }
}
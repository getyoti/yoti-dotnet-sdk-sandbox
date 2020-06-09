using System;
using Xunit;
using Yoti.Auth.Sandbox.DocScan.Request;
using Yoti.Auth.Tests.Common;

namespace Yoti.Auth.Sandbox.Tests.DocScan
{
    public static class DocScanSandboxClientBuilderTests
    {
        private const string _someSdkId = "someSdkId";
        private static readonly Uri _someUri = new Uri("https://www.test.com");

        [Fact]
        public static void BuilderShouldThrowForMissingSdkId()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                new SandboxClientBuilder()
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
                new SandboxClientBuilder()
                .WithApiUri(_someUri)
                .WithClientSdkId(_someSdkId)
                .Build();
            });

            Assert.Contains("keyPair", exception.Message, StringComparison.Ordinal);
        }

        [Fact]
        public static void BuilderShouldCreateClient()
        {
            var sandboxClient = new SandboxClientBuilder()
                .WithClientSdkId(_someSdkId)
                .WithKeyPair(KeyPair.Get())
                .WithApiUri(_someUri)
                .Build();

            Assert.NotNull(sandboxClient);
        }

        [Fact]
        public static void BuilderShouldUseGivenApiUri()
        {
            var sandboxClient = SandboxClient.Builder()
                .WithClientSdkId(_someSdkId)
                .WithKeyPair(KeyPair.Get())
                .WithApiUri(_someUri)
                .Build();

            Assert.Equal(_someUri, sandboxClient.DocScanSandboxApiUrl);
        }

        [Fact]
        public static void BuilderShouldUseDefaultApiUri()
        {
            var sandboxClient = SandboxClient.Builder()
                .WithClientSdkId(_someSdkId)
                .WithKeyPair(KeyPair.Get())
                .Build();

            Assert.Equal(new Uri("https://api.yoti.com/sandbox/idverify/v1"), sandboxClient.DocScanSandboxApiUrl);
        }
    }
}
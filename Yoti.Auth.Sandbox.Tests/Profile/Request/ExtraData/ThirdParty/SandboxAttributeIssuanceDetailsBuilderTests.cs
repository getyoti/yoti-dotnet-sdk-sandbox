using System;
using Xunit;
using Yoti.Auth.Sandbox.Profile.Request.ExtraData.ThirdParty;

namespace Yoti.Auth.Sandbox.Tests.Profile.Request.ExtraData.ThirdParty
{
    public class SandboxAttributeIssuanceDetailsBuilderTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotBuildWithNullOrEmptyIssuanceToken(string issuanceToken)
        {
            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                new SandboxAttributeIssuanceDetailsBuilder()
                 .WithIssuanceToken(issuanceToken);
            });

            Assert.Contains("'issuanceToken' must not be empty or null", exception.Message, StringComparison.Ordinal);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotBuildWithNullOrEmptyDefinition(string definition)
        {
            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                new SandboxAttributeIssuanceDetailsBuilder()
                 .WithDefinition(definition);
            });

            Assert.Contains("'attributeName' must not be empty or null", exception.Message, StringComparison.Ordinal);
        }
    }
}
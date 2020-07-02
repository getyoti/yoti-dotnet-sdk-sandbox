using System;
using System.Linq;
using Xunit;
using Yoti.Auth.Sandbox.Profile.Request.ExtraData;

namespace Yoti.Auth.Sandbox.Tests.Profile.Request.ExtraData
{
    public static class SandboxExtraDataBuilderTests
    {
        [Fact]
        public static void ShouldBuildSandboxExtraData()
        {
            string type = "SOME_TYPE";

            var extraData = new SandboxExtraDataBuilder()
                .WithDataEntry(new SandboxBaseDataEntry(type))
                .Build();

            Assert.Equal(type, extraData.DataEntries.Single().Type);
        }

        [Fact]
        public static void ShouldNotBuildWithEmptyDataEntries()
        {
            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                var extraData = new SandboxExtraDataBuilder()
                .Build();
            });

            Assert.Contains("dataEntries", exception.Message, StringComparison.Ordinal);
        }
    }
}
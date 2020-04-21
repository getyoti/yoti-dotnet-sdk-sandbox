using System;
using Xunit;
using Yoti.Auth.Sandbox.DocScan.Request.Check;
using Yoti.Auth.Sandbox.DocScan.Request.Check.Report;

namespace Yoti.Auth.Sandbox.Tests.DocScan.Request.Check
{
    public class SandboxDocumentFaceMatchCheckBuilderTests
    {
        private readonly SandboxBreakdown _someBreakDown = new SandboxBreakdown("someSubCheck", "someResult", details: null);

        [Fact]
        public void ShouldNotBuildWithoutRecommendation()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                new SandboxDocumentFaceMatchCheckBuilder()
                .WithBreakdown(_someBreakDown)
                .Build();
            });

            Assert.Contains("Recommendation", exception.Message, StringComparison.Ordinal);
        }
    }
}
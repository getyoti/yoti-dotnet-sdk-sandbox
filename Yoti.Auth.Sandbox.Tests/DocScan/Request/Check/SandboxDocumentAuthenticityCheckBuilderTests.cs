using System;
using System.Linq;
using Xunit;
using Yoti.Auth.Sandbox.DocScan.Request.Check;
using Yoti.Auth.Sandbox.DocScan.Request.Check.Report;

namespace Yoti.Auth.Sandbox.Tests.DocScan.Request.Check
{
    public class SandboxDocumentAuthenticityCheckBuilderTests
    {
        private readonly SandboxBreakdown _someBreakDown = new SandboxBreakdown("someSubCheck", "someResult", details: null);
        private readonly SandboxRecommendation _someRecommendation = new SandboxRecommendation("someValue", "someReason", "someRecoverySuggestion");

        [Fact]
        public void ShouldNotBuildWithoutRecommendation()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                new SandboxDocumentAuthenticityCheckBuilder()
                .WithBreakdown(_someBreakDown)
                .Build();
            });

            Assert.Contains("Recommendation", exception.Message, StringComparison.Ordinal);
        }

        [Fact]
        public void ShouldBuildSandboxDocumentAuthenticityCheck()
        {
            var check = new SandboxDocumentAuthenticityCheckBuilder()
                .WithRecommendation(_someRecommendation)
                .WithBreakdown(_someBreakDown)
                .Build();

            Assert.Equal(_someBreakDown, check.Result.Report.Breakdown.Single());
            Assert.Equal(_someRecommendation, check.Result.Report.Recommendation);
        }
    }
}
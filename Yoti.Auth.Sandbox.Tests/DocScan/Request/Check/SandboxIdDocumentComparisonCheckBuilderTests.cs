using System.Linq;
using Xunit;
using Yoti.Auth.Sandbox.DocScan.Request.Check;
using Yoti.Auth.Sandbox.DocScan.Request.Check.Report;
using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.Tests.DocScan.Request.Check
{
    public class SandboxIdDocumentComparisonCheckBuilderTests
    {
        [Fact]
        public void ShouldBuildWithOnlyRecommendation()
        {
            var idDocComparisonCheck = new SandboxIdDocumentComparisonCheckBuilder()
                .WithRecommendation(
                    new SandboxRecommendationBuilder()
                    .WithValue("APPROVE")
                    .Build())
                .Build();

            Assert.Equal("APPROVE", idDocComparisonCheck.Result.Report.Recommendation.Value);
        }

        [Fact]
        public void ShouldBuildWithSecondaryDocumentFilter()
        {
            var idDocComparisonCheck = new SandboxIdDocumentComparisonCheckBuilder()
                 .WithRecommendation(
                     new SandboxRecommendationBuilder()
                     .WithValue("APPROVE")
                     .Build())
                 .WithSecondaryDocumentFilter(
                    new SandboxDocumentFilterBuilder()
                    .WithCountryCode("GBR")
                    .Build())
                 .Build();

            Assert.Equal("GBR", idDocComparisonCheck.SecondaryDocumentFilter.CountryCodes.Single());
        }
    }
}
using System.Linq;
using Xunit;
using Yoti.Auth.Sandbox.DocScan.Request;
using Yoti.Auth.Sandbox.DocScan.Request.Check;
using Yoti.Auth.Sandbox.DocScan.Request.Check.Report;

namespace Yoti.Auth.Sandbox.Tests.DocScan
{
    public static class SandboxCheckReportsBuilderTests
    {
        [Fact]
        public static void BuilderShouldBuildWithAllArguments()
        {
            var sandboxCheckReport = new SandboxCheckReportsBuilder()
                .WithAsyncReportDelay(10)
                .WithDocumentAuthenticityCheck(
                    new SandboxDocumentAuthenticityCheckBuilder()
                    .WithRecommendation(
                        new SandboxRecommendationBuilder()
                        .WithValue("NOT_AVAILABLE")
                        .WithReason("PICTURE_TOO_DARK")
                        .WithRecoverySuggestion("BETTER_LIGHTING")
                        .Build())
                    .Build())
                .WithDocumentFaceMatchCheck(
                    new SandboxDocumentFaceMatchCheckBuilder()
                    .WithRecommendation(
                        new SandboxRecommendationBuilder()
                        .WithValue("APPROVE")
                        .Build())
                    .Build())
                .WithDocumentTextDataCheck(
                    new SandboxDocumentTextDataCheckBuilder()
                    .WithRecommendation(
                        new SandboxRecommendationBuilder()
                        .WithValue("APPROVE")
                        .Build())
                    .Build())
                .WithLivenessCheck(
                     new SandboxZoomLivenessCheckBuilder()
                    .WithRecommendation(
                        new SandboxRecommendationBuilder()
                        .WithValue("APPROVE")
                        .Build())
                    .Build())
                .WithIdDocumentComparisonCheck(
                    new SandboxIdDocumentComparisonCheckBuilder()
                    .WithRecommendation(
                        new SandboxRecommendationBuilder()
                        .WithValue("APPROVE")
                        .Build())
                    .Build())
                .WithIdDocumentComparisonCheck(
                    new SandboxIdDocumentComparisonCheckBuilder()
                    .WithRecommendation(
                        new SandboxRecommendationBuilder()
                        .WithValue("APPROVE")
                        .Build())
                    .Build())
                 .WithSupplementaryDocTextDataCheck(
                    new SandboxSupplementaryDocTextDataCheckBuilder()
                    .WithRecommendation(
                        new SandboxRecommendationBuilder()
                        .WithValue("APPROVE")
                        .Build())
                    .Build())
                .Build();

            Assert.Equal(10, sandboxCheckReport.AsyncReportDelay);
            Assert.NotEmpty(sandboxCheckReport.DocumentAuthenticityCheck);
            Assert.NotEmpty(sandboxCheckReport.DocumentFaceMatchCheck);
            Assert.NotEmpty(sandboxCheckReport.TextDataCheck);
            Assert.Equal("ZOOM", sandboxCheckReport.LivenessChecks.Single().LivenessType);
            Assert.NotEmpty(sandboxCheckReport.IdDocumentComparisonChecks);
            Assert.NotEmpty(sandboxCheckReport.SupplementaryDocTextDataChecks);
        }
    }
}
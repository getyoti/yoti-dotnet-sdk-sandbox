using Xunit;
using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.Tests.DocScan.Request.Task
{
    public class SandboxDocumentTextDataExtractionRecommendationTests
    {
        [Fact]
        public void ShouldBuildWithRecommendationForProgress()
        {
            var task = new SandboxDocumentTextDataExtractionRecommendationBuilder()
                .ForProgress()
                .Build();

            Assert.Equal("PROGRESS", task.Value);
        }

        [Fact]
        public void ShouldBuildWithRecommendationShouldTryAgain()
        {
            var task = new SandboxDocumentTextDataExtractionRecommendationBuilder()
                .ForShouldTryAgain()
                .Build();

            Assert.Equal("SHOULD_TRY_AGAIN", task.Value);
        }

        [Fact]
        public void ShouldBuildWithRecommendationMustTryAgain()
        {
            var task = new SandboxDocumentTextDataExtractionRecommendationBuilder()
                .ForMustTryAgain()
                .Build();

            Assert.Equal("MUST_TRY_AGAIN", task.Value);
        }

        [Fact]
        public void ShouldBuildWithReason()
        {
            SandboxDocumentTextDataExtractionReason _someReason = new SandboxDocumentTextDataExtractionReason("value", "details");

            var task = new SandboxDocumentTextDataExtractionRecommendationBuilder()
                .WithReason(_someReason)
                .Build();

            Assert.Equal(_someReason, task.Reason);
        }
    }
}
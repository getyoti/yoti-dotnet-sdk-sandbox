using Xunit;
using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.Tests.DocScan.Request.Task
{
    public class SandboxDocumentTextDataExtractionReasonTests
    {
        private readonly string _someReasonDetail = "someReasonDetail";

        [Fact]
        public void ShouldBuildForQuality()
        {
            var task = new SandboxDocumentTextDataExtractionReasonBuilder()
                .ForQuality()
                .Build();

            Assert.Equal("QUALITY", task.Value);
        }

        [Fact]
        public void ShouldBuildForUserError()
        {
            var task = new SandboxDocumentTextDataExtractionReasonBuilder()
                .ForUserError()
                .Build();

            Assert.Equal("USER_ERROR", task.Value);
        }

        [Fact]
        public void ShouldBuildForAReasonDetail()
        {
            var task = new SandboxDocumentTextDataExtractionReasonBuilder()
                .WithDetail(_someReasonDetail)
                .Build();

            Assert.Equal(_someReasonDetail, task.Detail);
        }
    }
}
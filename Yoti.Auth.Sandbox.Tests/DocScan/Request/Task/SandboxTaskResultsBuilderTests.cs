using System.Collections.Generic;
using System.Linq;
using Xunit;
using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.Tests.DocScan.Request.Task
{
    public class SandboxTaskResultsBuilderTests
    {
        [Fact]
        public void ShouldBuildWithSupplementaryDocTextDataExtractionTask()
        {
            var task = new SandboxSupplementaryDocTextDataExtractionTaskBuilder().Build();
            var taskResults = new SandboxTaskResultsBuilder()
                .WithSupplementaryDocTextDataExtractionTask(task)
                .Build();

            Assert.Equal(task, taskResults.SupplementaryDocTextDataExtractionTasks.Single());
            Assert.Empty(taskResults.TextDataExtractionTasks);
        }

        [Fact]
        public void ShouldBuildWithDocumentTextDataExtractionTask()
        {
            var task = new SandboxDocumentTextDataExtractionTaskBuilder().Build();
            var taskResults = new SandboxTaskResultsBuilder()
                .WithDocumentTextDataExtractionTask(task)
                .Build();

            Assert.Equal(task, taskResults.TextDataExtractionTasks.Single());
            Assert.Empty(taskResults.SupplementaryDocTextDataExtractionTasks);
        }
    }
}
using Xunit;
using System.Collections.Generic;
using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.Tests.DocScan.Request.Task
{
    public class SandboxDocumentTextDataExtractionTaskBuilderTest
    {
        private readonly string _someKey = "someKey";
        private readonly string _someValue = "someValue";
        private readonly string _someOtherKey = "someOtherKey";
        private readonly string _someOtherValue = "someOtherValue";

        [Fact]
        public void ShouldBuildWithDocumentField()
        {
            var task = new SandboxDocumentTextDataExtractionTaskBuilder()
                .WithDocumentField(_someKey, _someValue)
                .Build();

            Assert.Equal(_someValue, task.Result.DocumentFields[_someKey]);
        }

        [Fact]
        public void ShouldBuildWithDocumentFieldMultiple()
        {
            var task = new SandboxDocumentTextDataExtractionTaskBuilder()
                .WithDocumentField(_someKey, _someValue)
                .WithDocumentField(_someOtherKey, _someOtherValue)
                .Build();

            Assert.Equal(_someValue, task.Result.DocumentFields[_someKey]);
            Assert.Equal(_someOtherValue, task.Result.DocumentFields[_someOtherKey]);
        }

        [Fact]
        public void ShouldBuildWithDocumentFields()
        {
            var documentFields = new Dictionary<string, object>
            {
                { _someKey, _someValue },
                { _someOtherKey, _someOtherValue }
            };

            var task = new SandboxDocumentTextDataExtractionTaskBuilder()
                .WithDocumentFields(documentFields)
                .Build();

            Assert.Equal(_someValue, task.Result.DocumentFields[_someKey]);
            Assert.Equal(_someOtherValue, task.Result.DocumentFields[_someOtherKey]);
        }

        [Fact]
        public void ShouldBuildWithoutDocumentFields()
        {
            var task = new SandboxDocumentTextDataExtractionTaskBuilder().Build();

            Assert.Null(task.Result.DocumentFields);
        }
    }
}
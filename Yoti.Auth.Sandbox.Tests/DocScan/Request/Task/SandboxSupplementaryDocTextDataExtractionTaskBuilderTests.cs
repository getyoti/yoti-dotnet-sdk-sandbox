using System;
using System.Collections.Generic;
using Xunit;
using Yoti.Auth.Sandbox.DocScan.Request.Task;
using System;
using System.Text;

namespace Yoti.Auth.Sandbox.Tests.DocScan.Request.Task
{
    public class SandboxSupplementaryDocTextDataExtractionTaskBuilderTests
    {
        private readonly string _someKey = "someKey";
        private readonly string _someValue = "someValue";
        private readonly string _someOtherKey = "someOtherKey";
        private readonly string _someOtherValue = "someOtherValue";

        [Fact]
        public void ShouldBuildWithDocumentField()
        {
            var task = new SandboxSupplementaryDocTextDataExtractionTaskBuilder()
                .WithDocumentField(_someKey, _someValue)
                .Build();

            Assert.Equal(_someValue, task.Result.DocumentFields[_someKey]);
        }

        [Fact]
        public void ShouldBuildWithDocumentFieldMultiple()
        {
            var task = new SandboxSupplementaryDocTextDataExtractionTaskBuilder()
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

            var task = new SandboxSupplementaryDocTextDataExtractionTaskBuilder()
                .WithDocumentFields(documentFields)
                .Build();

            Assert.Equal(_someValue, task.Result.DocumentFields[_someKey]);
            Assert.Equal(_someOtherValue, task.Result.DocumentFields[_someOtherKey]);
        }

        [Fact]
        public void ShouldBuildWithDocumentFilter()
        {
            var documentFilter = new SandboxDocumentFilterBuilder().Build();

            var task = new SandboxSupplementaryDocTextDataExtractionTaskBuilder()
                .WithDocumentFilter(documentFilter)
                .Build();

            Assert.Equal(documentFilter, task.DocumentFilter);
        }

        [Fact]
        public void ShouldBuildWithDetectedCountry()
        {
            var task = new SandboxSupplementaryDocTextDataExtractionTaskBuilder()
                .WithDetectedCountry("USA")
                .Build();

            Assert.Equal("USA", task.Result.DetectedCountry);
        }

        [Fact]
        public void ShouldBuildWithRecommendation()
        {
            var recommendation = new SandboxDocumentTextDataExtractionRecommendationBuilder().ForMustTryAgain().Build();

            var task = new SandboxSupplementaryDocTextDataExtractionTaskBuilder()
                .WithRecommendation(recommendation)
                .Build();

            Assert.Equal(recommendation, task.Result.Recommendation);
        }

        [Fact]
        public void ShouldBuildWithoutMethods()
        {
            var task = new SandboxSupplementaryDocTextDataExtractionTaskBuilder().Build();

            Assert.Null(task.Result.DocumentFields);
        }
    }
}
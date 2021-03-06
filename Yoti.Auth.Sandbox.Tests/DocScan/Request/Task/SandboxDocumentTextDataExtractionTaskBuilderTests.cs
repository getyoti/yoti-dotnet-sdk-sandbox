using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.Tests.DocScan.Request.Task
{
    public class SandboxDocumentTextDataExtractionTaskBuilderTests
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
        public void ShouldBuildWithDocumentFilter()
        {
            var documentFilter = new SandboxDocumentFilterBuilder().Build();

            var task = new SandboxDocumentTextDataExtractionTaskBuilder()
                .WithDocumentFilter(documentFilter)
                .Build();

            Assert.Equal(documentFilter, task.DocumentFilter);
        }

        [Fact]
        public void ShouldBuildWithRecommendation()
        {
            var recommendation = new SandboxDocumentTextDataExtractionRecommendationBuilder().Build();

            var task = new SandboxDocumentTextDataExtractionTaskBuilder()
                .WithRecommendation(recommendation)
                .Build();

            Assert.Equal(recommendation, task.Result.Recommendation);
        }

        [Fact]
        public void ShouldBuildWithoutMethods()
        {
            var task = new SandboxDocumentTextDataExtractionTaskBuilder().Build();

            Assert.Null(task.Result.DocumentFields);
            Assert.Null(task.Result.DocumentIdPhoto);
        }

        [Fact]
        public void ShouldBuildWithDocumentIdPhoto()
        {
            byte[] imageBytes = Encoding.UTF8.GetBytes("someImage");
            string contentType = "image/jpeg";

            var task = new SandboxDocumentTextDataExtractionTaskBuilder()
                .WithDocumentIdPhoto(contentType, imageBytes)
                .Build();

            Assert.Equal(contentType, task.Result.DocumentIdPhoto.ContentType);
            Assert.Equal(Convert.ToBase64String(imageBytes), task.Result.DocumentIdPhoto.Base64Data);
        }

        [Fact]
        public void ShouldBuildWithDetectedCountry()
        {
            var task = new SandboxDocumentTextDataExtractionTaskBuilder()
                .WithDetectedCountry("GBR")
                .Build();

            Assert.Equal("GBR", task.Result.DetectedCountry);
        }
    }
}
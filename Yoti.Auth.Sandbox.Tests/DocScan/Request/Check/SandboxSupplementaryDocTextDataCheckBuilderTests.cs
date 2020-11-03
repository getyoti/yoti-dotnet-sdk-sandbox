using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Yoti.Auth.Sandbox.DocScan.Request.Check;
using Yoti.Auth.Sandbox.DocScan.Request.Check.Report;

namespace Yoti.Auth.Sandbox.Tests.DocScan.Request.Check
{
    public class SandboxSupplementaryDocTextDataCheckBuilderTests
    {
        private readonly SandboxBreakdown _someBreakDown = new SandboxBreakdown("someSubCheck", "someResult", details: null);
        private readonly SandboxRecommendation _someRecommendation = new SandboxRecommendation("someValue", "someReason", "someRecoverySuggestion");
        private readonly string _someKey = "someName";
        private readonly string _someValue = "someValue";

        [Fact]
        public void ShouldNotBuildWithoutRecommendation()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                new SandboxSupplementaryDocTextDataCheckBuilder()
                .WithDocumentField("key", "value")
                .WithBreakdown(_someBreakDown)
                .Build();
            });

            Assert.Contains("Recommendation", exception.Message, StringComparison.Ordinal);
        }

        [Fact]
        public void ShouldBuildWithDocumentField()
        {
            var check = new SandboxSupplementaryDocTextDataCheckBuilder()
                .WithDocumentField(_someKey, _someValue)
                .WithBreakdown(_someBreakDown)
                .WithRecommendation(_someRecommendation)
                .Build();

            var sandboxTextDataCheckResult = (SandboxSupplementaryDocTextDataCheckResult)check.Result;

            var result = sandboxTextDataCheckResult.DocumentFields.Single();

            Assert.Equal(_someKey, result.Key);
            Assert.Equal(_someValue, result.Value);
        }

        [Fact]
        public void ShouldBuildWithoutDocumentFields()
        {
            var check = new SandboxSupplementaryDocTextDataCheckBuilder()
                .WithBreakdown(_someBreakDown)
                .WithRecommendation(_someRecommendation)
                .Build();

            var sandboxTextDataCheckResult = (SandboxSupplementaryDocTextDataCheckResult)check.Result;

            Assert.Null(sandboxTextDataCheckResult.DocumentFields);
        }

        [Fact]
        public void ShouldBuildWithDocumentFields()
        {
            var documentFields = new Dictionary<string, object>
            {
                { _someKey, _someValue },
                { "key2", "value2" }
            };

            var check = new SandboxSupplementaryDocTextDataCheckBuilder()
                .WithDocumentFields(documentFields)
                .WithRecommendation(_someRecommendation)
                .WithBreakdown(_someBreakDown)
                .Build();

            var sandboxTextDataCheckResult = (SandboxSupplementaryDocTextDataCheckResult)check.Result;

            var result = sandboxTextDataCheckResult.DocumentFields;

            Assert.Equal(2, result.Count);
            Assert.Equal(_someKey, result.ElementAt(0).Key);
            Assert.Equal(_someValue, result.ElementAt(0).Value);
            Assert.Equal("key2", result.ElementAt(1).Key);
            Assert.Equal("value2", result.ElementAt(1).Value);
        }

        [Fact]
        public void WithDocumentFieldsShouldOverrideWithDocumentField()
        {
            var documentFields = new Dictionary<string, object>
            {
                { _someKey, _someValue },
                { "key2", _someValue }
            };

            var check = new SandboxSupplementaryDocTextDataCheckBuilder()
                .WithDocumentField(_someKey, _someValue)
                .WithDocumentFields(documentFields)
                .WithRecommendation(_someRecommendation)
                .WithBreakdown(_someBreakDown)
                .Build();

            var sandboxTextDataCheckResult = (SandboxSupplementaryDocTextDataCheckResult)check.Result;

            Assert.Equal(2, sandboxTextDataCheckResult.DocumentFields.Count);
        }

        [Fact]
        public void WithDocumentFieldShouldAddToDocumentFields()
        {
            var documentFields = new Dictionary<string, object>
            {
                { "key1", _someValue },
                { "key2", _someValue }
            };

            var check = new SandboxSupplementaryDocTextDataCheckBuilder()
                .WithDocumentFields(documentFields)
                .WithDocumentField(_someKey, _someValue)
                .WithBreakdown(_someBreakDown)
                .WithRecommendation(_someRecommendation)
                .Build();

            var sandboxTextDataCheckResult = (SandboxSupplementaryDocTextDataCheckResult)check.Result;

            Assert.Equal(3, sandboxTextDataCheckResult.DocumentFields.Count);
        }
    }
}
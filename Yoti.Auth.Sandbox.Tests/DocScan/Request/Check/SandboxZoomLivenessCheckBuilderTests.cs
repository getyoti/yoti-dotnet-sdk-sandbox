using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Yoti.Auth.Sandbox.DocScan.Request.Check;
using Yoti.Auth.Sandbox.DocScan.Request.Check.Report;

namespace Yoti.Auth.Sandbox.Tests.DocScan.Request.Check
{
    public class SandboxZoomLivenessCheckBuilderTests
    {
        private readonly SandboxBreakdown _someBreakdown = new SandboxBreakdown("someSubCheck", "someResult", details: null);
        private readonly SandboxRecommendation _someRecommendation = new SandboxRecommendation("someValue", "someReason", "someRecoverySuggestion");

        [Fact]
        public void ShouldNotBuildWithoutRecommendation()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                new SandboxZoomLivenessCheckBuilder()
                .WithBreakdown(_someBreakdown)
                .Build();
            });

            Assert.Contains("Recommendation", exception.Message, StringComparison.Ordinal);
        }

        [Fact]
        public void ShouldBuildWithRecommendation()
        {
            string someValue = "someValue";
            string someReason = "someReason";
            string someRecoverySuggestion = "someRecoverySuggestion";

            var recommendation = new SandboxRecommendation(someValue, someReason, someRecoverySuggestion);

            var check = new SandboxZoomLivenessCheckBuilder()
                .WithBreakdown(_someBreakdown)
                .WithRecommendation(recommendation)
                .Build();

            var result = check.Result.Report.Recommendation;

            Assert.Equal(someValue, result.Value);
            Assert.Equal(someReason, result.Reason);
            Assert.Equal(someRecoverySuggestion, result.RecoverySuggestion);
        }

        [Fact]
        public void ShouldBuildWithBreakdown()
        {
            string someSubCheck = "someSubCheck";
            string someResult = "someResult";
            string someName = "someName";
            string someValue = "someValue";

            List<SandboxDetail> someSandboxDetails = new List<SandboxDetail> { new SandboxDetail(someName, someValue) };

            var breakdown = new SandboxBreakdown(someSubCheck, someResult, someSandboxDetails);

            var check = new SandboxZoomLivenessCheckBuilder()
                .WithBreakdown(breakdown)
                .WithRecommendation(_someRecommendation)
                .Build();

            var result = check.Result.Report.Breakdown.Single();

            Assert.Equal(someName, result.Details.Single().Name);
            Assert.Equal(someValue, result.Details.Single().Value);
            Assert.Equal(someSubCheck, result.SubCheck);
            Assert.Equal(someResult, result.Result);
        }

        [Fact]
        public void ShouldBuildWithBreakdowns()
        {
            string someSubCheck = "someSubCheck";
            string someResult = "someResult";
            string someName = "someName";
            string someValue = "someValue";

            List<SandboxDetail> someSandboxDetails = new List<SandboxDetail> { new SandboxDetail(someName, someValue) };

            var breakdown = new SandboxBreakdown(someSubCheck, someResult, someSandboxDetails);
            var breakdownList = new List<SandboxBreakdown> { breakdown, breakdown };

            var check = new SandboxZoomLivenessCheckBuilder()
                .WithBreakdowns(breakdownList)
                .WithRecommendation(_someRecommendation)
                .Build();

            Assert.Equal(2, check.Result.Report.Breakdown.Count);
        }

        [Fact]
        public void WithBreakdownsShouldOverrideWithBreakdown()
        {
            var breakdownList = new List<SandboxBreakdown> { _someBreakdown, _someBreakdown };

            var check = new SandboxZoomLivenessCheckBuilder()
                .WithBreakdown(_someBreakdown)
                .WithBreakdowns(breakdownList)
                .WithRecommendation(_someRecommendation)
                .Build();

            Assert.Equal(2, check.Result.Report.Breakdown.Count);
        }

        [Fact]
        public void WithBreakdownShouldAddToBreakdowns()
        {
            var breakdownList = new List<SandboxBreakdown> { _someBreakdown, _someBreakdown };

            var check = new SandboxZoomLivenessCheckBuilder()
                .WithBreakdowns(breakdownList)
                .WithBreakdown(_someBreakdown)
                .WithRecommendation(_someRecommendation)
                .Build();

            Assert.Equal(3, check.Result.Report.Breakdown.Count);
        }
    }
}
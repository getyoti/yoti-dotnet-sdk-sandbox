using System.Collections.Generic;
using Xunit;
using Yoti.Auth.Sandbox.DocScan.Request;
using Yoti.Auth.Sandbox.DocScan.Request.Check;

namespace Yoti.Auth.Sandbox.Tests.DocScan
{
    public static class SandboxCheckReportTests
    {
        [Fact]
        public static void ShouldCreateWithAllArgs()
        {
            var sandboxCheckReport = new SandboxCheckReports(
                new List<SandboxDocumentTextDataCheck>(),
                new List<SandboxDocumentAuthenticityCheck>(),
                new List<SandboxLivenessCheck>(),
                new List<SandboxDocumentFaceMatchCheck>(),
                10,
                new List<SandboxIdDocumentComparisonCheck>(),
                new List<SandboxSupplementaryDocTextDataCheck>());

            Assert.NotNull(sandboxCheckReport.TextDataCheck);
            Assert.NotNull(sandboxCheckReport.DocumentAuthenticityCheck);
            Assert.NotNull(sandboxCheckReport.LivenessChecks);
            Assert.NotNull(sandboxCheckReport.DocumentFaceMatchCheck);
            Assert.Equal(10, sandboxCheckReport.AsyncReportDelay);
            Assert.NotNull(sandboxCheckReport.IdDocumentComparisonChecks);
            Assert.NotNull(sandboxCheckReport.SupplementaryDocTextDataChecks);
        }

        [Fact]
        public static void ShouldCreateWithoutOptionals()
        {
            var sandboxCheckReport = new SandboxCheckReports(
                new List<SandboxDocumentTextDataCheck>(),
                new List<SandboxDocumentAuthenticityCheck>(),
                new List<SandboxLivenessCheck>(),
                new List<SandboxDocumentFaceMatchCheck>(),
                10);

            Assert.NotNull(sandboxCheckReport.TextDataCheck);
            Assert.NotNull(sandboxCheckReport.DocumentAuthenticityCheck);
            Assert.NotNull(sandboxCheckReport.LivenessChecks);
            Assert.NotNull(sandboxCheckReport.DocumentFaceMatchCheck);
            Assert.Equal(10, sandboxCheckReport.AsyncReportDelay);
            Assert.Empty(sandboxCheckReport.IdDocumentComparisonChecks);
            Assert.Empty(sandboxCheckReport.SupplementaryDocTextDataChecks);
        }
    }
}
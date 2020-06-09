using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yoti.Auth.Sandbox.DocScan.Request;
using Yoti.Auth.Sandbox.DocScan.Request.Check;
using Yoti.Auth.Sandbox.DocScan.Request.Check.Report;
using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.Examples
{
    [TestClass]
    public class DocScanSandboxExample
    {
        public void TestDocScan()
        {
            Org.BouncyCastle.Crypto.AsymmetricCipherKeyPair sandboxKeyPair;

            using (StreamReader stream = File.OpenText("path/to/hub-private-key.pem"))
            {
                sandboxKeyPair = Yoti.Auth.CryptoEngine.LoadRsaKey(stream);
            }

            const string sandboxClientSdkid = "your SDK ID";

            var responseConfig = new ResponseConfigBuilder()
                .WithCheckReports(
                    (new SandboxCheckReportsBuilder())
                        .WithAsyncReportDelay(10)
                        .WithDocumentAuthenticityCheck(
                            new SandboxDocumentAuthenticityCheckBuilder()
                                .WithBreakdown(
                                    (new SandboxBreakdownBuilder())
                                        .WithSubCheck("security_features")
                                        .WithResult("NOT_AVAILABLE")
                                        .WithDetail(new SandboxDetail("some_detail", "some_detail_value"))
                                        .Build()
                                )
                                .WithRecommendation(
                                    (new SandboxRecommendationBuilder())
                                        .WithValue("NOT_AVAILABLE")
                                        .WithReason("PICTURE_TOO_DARK")
                                        .WithRecoverySuggestion("BETTER_LIGHTING")
                                        .Build()
                                )
                                .Build()
                        )
                        .WithDocumentFaceMatchCheck(
                            new SandboxDocumentFaceMatchCheckBuilder()
                                .WithBreakdown(
                                    (new SandboxBreakdownBuilder())
                                        .WithSubCheck("security_features")
                                        .WithResult("PASS")
                                        .Build()
                                )
                                .WithRecommendation(
                                    (new SandboxRecommendationBuilder())
                                        .WithValue("APPROVE")
                                        .Build()
                                )
                                .Build()
                        )
                        .WithDocumentTextDataCheck(
                            new SandboxDocumentTextDataCheckBuilder()
                                .WithDocumentFields(
                                new Dictionary<string, object>
                                {
                                    { "full_name", "John Doe" },
                                    { "full_name", "John Doe"},
                                    { "nationality", "GBR"},
                                    { "date_of_birth", "1986-06-01"},
                                    { "document_number", "123456789"}
                                })
                                .WithBreakdown(
                                    new SandboxBreakdownBuilder()
                                        .WithSubCheck("document_in_date")
                                        .WithResult("PASS")
                                        .Build()
                                )
                                .WithRecommendation(
                                    (new SandboxRecommendationBuilder())
                                        .WithValue("APPROVE")
                                        .Build()
                                )
                                .Build()
                        )
                        .WithLivenessCheck(
                            (new SandboxZoomLivenessCheckBuilder())
                                .WithBreakdown(
                                    (new SandboxBreakdownBuilder())
                                        .WithSubCheck("security_features")
                                        .WithResult("PASS")
                                        .Build()
                                )
                                .WithRecommendation(
                                    (new SandboxRecommendationBuilder())
                                        .WithValue("APPROVE")
                                        .Build()
                                )
                                .Build()
                        )
                        .Build()
    )
    .WithTaskResults(
        (new SandboxTaskResultsBuilder())
            .WithDocumentTextDataExtractionTask(
                new SandboxDocumentTextDataExtractionTaskBuilder()
                    .WithDocumentFields(
                        new Dictionary<string, object>
                        {
                            { "full_name", "John Doe" },
                            { "full_name", "John Doe"},
                            { "nationality", "GBR"},
                            { "date_of_birth", "1986-06-01"},
                            { "document_number", "123456789"}
                        })
                    .Build()
            )
            .Build()
    )
    .Build();

            var client = new SandboxClientBuilder()
                .WithClientSdkId(sandboxClientSdkid)
                .WithKeyPair(sandboxKeyPair)
                .Build();
            client.ConfigureSessionResponse("SESSION_ID", responseConfig);
        }
    }
}
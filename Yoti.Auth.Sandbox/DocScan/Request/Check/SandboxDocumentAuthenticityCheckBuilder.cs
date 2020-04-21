namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxDocumentAuthenticityCheckBuilder
        : SandboxDocumentCheckBuilder<SandboxDocumentAuthenticityCheckBuilder, SandboxDocumentAuthenticityCheck>
    {
        public override SandboxDocumentAuthenticityCheck Build()
        {
            Validation.NotNull(Recommendation, nameof(Recommendation));

            SandboxCheckReport report = new SandboxCheckReport(Recommendation, Breakdown);
            SandboxCheckResult result = new SandboxCheckResult(report);

            return new SandboxDocumentAuthenticityCheck(result, DocumentFilter);
        }
    }
}
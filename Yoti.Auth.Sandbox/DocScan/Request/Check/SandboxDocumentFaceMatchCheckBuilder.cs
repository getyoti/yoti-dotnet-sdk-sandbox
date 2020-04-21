namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxDocumentFaceMatchCheckBuilder
        : SandboxDocumentCheckBuilder<SandboxDocumentFaceMatchCheckBuilder, SandboxDocumentFaceMatchCheck>
    {
        public override SandboxDocumentFaceMatchCheck Build()
        {
            Validation.NotNull(Recommendation, nameof(Recommendation));

            SandboxCheckReport report = new SandboxCheckReport(Recommendation, Breakdown);
            SandboxCheckResult result = new SandboxCheckResult(report);

            return new SandboxDocumentFaceMatchCheck(result, DocumentFilter);
        }
    }
}
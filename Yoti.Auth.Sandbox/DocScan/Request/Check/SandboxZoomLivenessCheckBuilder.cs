namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxZoomLivenessCheckBuilder
        : SandboxCheckBuilder<SandboxZoomLivenessCheckBuilder, SandboxLivenessCheck>
    {
        public override SandboxLivenessCheck Build()
        {
            Validation.NotNull(Recommendation, nameof(Recommendation));

            SandboxCheckReport report = new SandboxCheckReport(Recommendation, Breakdown);
            SandboxCheckResult result = new SandboxCheckResult(report);

            return new SandboxLivenessCheck(result, Yoti.Auth.Constants.DocScanConstants.Zoom);
        }
    }
}
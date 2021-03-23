namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxThirdPartyIdentityCheckBuilder
        : SandboxCheckBuilder<SandboxThirdPartyIdentityCheckBuilder, SandboxThirdPartyIdentityCheck>
    {
        public override SandboxThirdPartyIdentityCheck Build()
        {
            Validation.NotNull(Recommendation, nameof(Recommendation));

            SandboxCheckReport report = new SandboxCheckReport(Recommendation, Breakdown);
            SandboxCheckResult result = new SandboxCheckResult(report);

            return new SandboxThirdPartyIdentityCheck(result);
        }
    }
}
using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxIdDocumentComparisonCheckBuilder
        : SandboxCheckBuilder<SandboxIdDocumentComparisonCheckBuilder, SandboxIdDocumentComparisonCheck>
    {
        private SandboxDocumentFilter _secondaryDocumentFilter;

        public SandboxIdDocumentComparisonCheckBuilder WithSecondaryDocumentFilter(SandboxDocumentFilter documentFilter)
        {
            _secondaryDocumentFilter = documentFilter;
            return this;
        }

        public override SandboxIdDocumentComparisonCheck Build()
        {
            Validation.NotNull(Recommendation, nameof(Recommendation));

            SandboxCheckReport report = new SandboxCheckReport(Recommendation, Breakdown);
            SandboxCheckResult result = new SandboxCheckResult(report);

            return new SandboxIdDocumentComparisonCheck(result, _secondaryDocumentFilter);
        }
    }
}
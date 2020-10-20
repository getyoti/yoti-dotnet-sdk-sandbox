namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxDocumentTextDataExtractionReasonBuilder : SandboxTaskResult
    {
        private string _value;
        private string _detail;

        public SandboxDocumentTextDataExtractionReasonBuilder ForQuality()
        {
            _value = Constants.DocScanSandbox.Quality;
            return this;
        }

        public SandboxDocumentTextDataExtractionReasonBuilder ForUserError()
        {
            _value = Constants.DocScanSandbox.UserError;
            return this;
        }

        public SandboxDocumentTextDataExtractionReasonBuilder WithDetail(string detail)
        {
            _detail = detail;
            return this;
        }

        public SandboxDocumentTextDataExtractionReason Build()
        {
            return new SandboxDocumentTextDataExtractionReason(_value, _detail);
        }
    }
}
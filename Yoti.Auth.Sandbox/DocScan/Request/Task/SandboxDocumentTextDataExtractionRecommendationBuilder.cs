namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxDocumentTextDataExtractionRecommendationBuilder : SandboxTaskResult
    {
        private string _recommendationvalue;
        private SandboxDocumentTextDataExtractionReason _reason;

        public SandboxDocumentTextDataExtractionRecommendationBuilder ForProgress()
        {
            _recommendationvalue = Constants.DocScanSandbox.Progress;
            return this;
        }

        public SandboxDocumentTextDataExtractionRecommendationBuilder ForShouldTryAgain()
        {
            _recommendationvalue = Constants.DocScanSandbox.ShouldTryAgain;
            return this;
        }

        public SandboxDocumentTextDataExtractionRecommendationBuilder ForMustTryAgain()
        {
            _recommendationvalue = Constants.DocScanSandbox.MustTryAgain;
            return this;
        }

        public SandboxDocumentTextDataExtractionRecommendationBuilder WithReason(SandboxDocumentTextDataExtractionReason reason)
        {
            _reason = reason;
            return this;
        }

        public SandboxDocumentTextDataExtractionRecommendation Build()
        {
            return new SandboxDocumentTextDataExtractionRecommendation(_recommendationvalue, _reason);
        }
    }
}
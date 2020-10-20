namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxDocumentTextDataExtractionRecommendationBuilder : SandboxTaskResult
    {
        private string _recommendationvalue;
        private SandboxDocumentTextDataExtractionReason _reason;

        public SandboxDocumentTextDataExtractionRecommendationBuilder ForProgress()
        {
            _recommendationvalue = Constants.DocScan.Progress;
            return this;
        }

        public SandboxDocumentTextDataExtractionRecommendationBuilder ForShouldTryAgain()
        {
            _recommendationvalue = Constants.DocScan.ShouldTryAgain;
            return this;
        }

        public SandboxDocumentTextDataExtractionRecommendationBuilder ForMustTryAgain()
        {
            _recommendationvalue = Constants.DocScan.MustTryAgain;
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
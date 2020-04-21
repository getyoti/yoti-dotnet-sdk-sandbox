namespace Yoti.Auth.Sandbox.DocScan.Request.Check.Report
{
    public class SandboxRecommendationBuilder
    {
        private string _value;
        private string _reason;
        private string _recoverySuggestion;

        public SandboxRecommendationBuilder WithValue(string value)
        {
            _value = value;
            return this;
        }

        public SandboxRecommendationBuilder WithReason(string reason)
        {
            _reason = reason;
            return this;
        }

        public SandboxRecommendationBuilder WithRecoverySuggestion(string recoverySuggestion)
        {
            _recoverySuggestion = recoverySuggestion;
            return this;
        }

        public SandboxRecommendation Build()
        {
            Validation.NotNull(_value, nameof(_value));

            return new SandboxRecommendation(_value, _reason, _recoverySuggestion);
        }
    }
}
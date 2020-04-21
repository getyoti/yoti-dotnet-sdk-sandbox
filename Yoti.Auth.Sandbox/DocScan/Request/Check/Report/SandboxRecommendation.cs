using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check.Report
{
    public class SandboxRecommendation
    {
        public SandboxRecommendation(string value, string reason, string recoverySuggestion)
        {
            Value = value;
            Reason = reason;
            RecoverySuggestion = recoverySuggestion;
        }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; }

        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; }

        [JsonProperty(PropertyName = "recovery_suggestion")]
        public string RecoverySuggestion { get; }
    }
}
using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxDocumentTextDataExtractionRecommendation : SandboxTaskResult
    {
        public SandboxDocumentTextDataExtractionRecommendation(string value, SandboxDocumentTextDataExtractionReason reason)
        {
            Value = value;
            Reason = reason;
        }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; }

        [JsonProperty(PropertyName = "reason")]
        public SandboxDocumentTextDataExtractionReason Reason { get; }
    }
}
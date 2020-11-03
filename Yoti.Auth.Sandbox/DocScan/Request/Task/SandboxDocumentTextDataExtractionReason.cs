using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxDocumentTextDataExtractionReason
    {
        public SandboxDocumentTextDataExtractionReason(string value, string detail)
        {
            Value = value;
            Detail = detail;
        }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; }

        [JsonProperty(PropertyName = "detail")]
        public string Detail { get; }
    }
}
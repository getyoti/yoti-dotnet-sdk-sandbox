using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Resource.Document
{
    public class DocumentResource : SandboxPayload
    {
        [JsonProperty(PropertyName = "document_type")]
        public string DocumentType { get; }

        [JsonProperty(PropertyName = "issuing_country")]
        public string IssuingCountry { get; }

        public DocumentResource(string documentType, string issuingCountry)
        {
            DocumentType = documentType;
            IssuingCountry = issuingCountry;
        }
    }
}
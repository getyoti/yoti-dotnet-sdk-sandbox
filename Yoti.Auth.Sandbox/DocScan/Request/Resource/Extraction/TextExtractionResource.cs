using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Resource.Extraction
{
    public class TextExtractionResource : SandboxPayload
    {
        public TextExtractionResource(string clientExtractionOutcome, Dictionary<string, object> documentFields)
        {
            ClientExtractionOutcome = clientExtractionOutcome;
            DocumentFields = documentFields;
        }

        [JsonProperty(PropertyName = "client_extraction_outcome")]
        public string ClientExtractionOutcome { get; }

        [JsonProperty(PropertyName = "document_fields")]
        public Dictionary<string, object> DocumentFields { get; }
    }
}
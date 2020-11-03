using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxSupplementaryDocTextDataExtractionTaskResult
    {
        [JsonProperty(PropertyName = "document_fields")]
        public Dictionary<string, object> DocumentFields { get; }

        [JsonProperty(PropertyName = "detected_country")]
        public string DetectedCountry { get; }

        [JsonProperty(PropertyName = "recommendation")]
        public SandboxDocumentTextDataExtractionRecommendation Recommendation { get; }

        public SandboxSupplementaryDocTextDataExtractionTaskResult(
            Dictionary<string, object> documentFields,
            string detectedCountry = null,
            SandboxDocumentTextDataExtractionRecommendation recommendation = null)
        {
            DocumentFields = documentFields;
            DetectedCountry = detectedCountry;
            Recommendation = recommendation;
        }
    }
}
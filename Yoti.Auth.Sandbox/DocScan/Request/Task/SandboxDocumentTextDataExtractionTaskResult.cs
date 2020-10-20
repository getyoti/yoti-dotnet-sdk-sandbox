using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxDocumentTextDataExtractionTaskResult
    {
        [JsonProperty(PropertyName = "document_fields")]
        public Dictionary<string, object> DocumentFields { get; }

        [JsonProperty(PropertyName = "document_id_photo")]
        public SandboxDocumentIdPhoto DocumentIdPhoto { get; }

        [JsonProperty(PropertyName = "detected_country")]
        public string DetectedCountry { get; }

        [JsonProperty(PropertyName = "recommendation")]
        public SandboxDocumentTextDataExtractionRecommendation Recommendation { get; }

        public SandboxDocumentTextDataExtractionTaskResult(
            Dictionary<string, object> documentFields,
            SandboxDocumentIdPhoto sandboxDocumentIdPhoto = null,
            string detectedCountry = null,
            SandboxDocumentTextDataExtractionRecommendation recommendation = null)
        {
            DocumentFields = documentFields;
            DocumentIdPhoto = sandboxDocumentIdPhoto;
            DetectedCountry = detectedCountry;
            Recommendation = recommendation;
        }
    }
}
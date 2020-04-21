using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxDocumentTextDataExtractionTaskResult
    {
        [JsonProperty(PropertyName = "document_fields")]
        public Dictionary<string, object> DocumentFields { get; }

        public SandboxDocumentTextDataExtractionTaskResult(Dictionary<string, object> documentFields)
        {
            DocumentFields = documentFields;
        }
    }
}
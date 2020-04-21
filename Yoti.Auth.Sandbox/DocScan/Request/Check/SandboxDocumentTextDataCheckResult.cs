using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxDocumentTextDataCheckResult : SandboxCheckResult
    {
        [JsonProperty(PropertyName = "document_fields")]
        public Dictionary<string, object> DocumentFields { get; internal set; }

        public SandboxDocumentTextDataCheckResult(SandboxCheckReport report)
            : base(report)
        {
        }

        public SandboxDocumentTextDataCheckResult(SandboxCheckReport report, Dictionary<string, object> documentFields)
             : base(report)
        {
            DocumentFields = documentFields;
        }
    }
}
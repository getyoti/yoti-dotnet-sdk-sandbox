using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxSupplementaryDocTextDataCheckResult : SandboxCheckResult
    {
        [JsonProperty(PropertyName = "document_fields")]
        public Dictionary<string, object> DocumentFields { get; }

        public SandboxSupplementaryDocTextDataCheckResult(SandboxCheckReport report, Dictionary<string, object> documentFields)
            : base(report)
        {
            DocumentFields = documentFields;
        }
    }
}
using Newtonsoft.Json;
using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxIdDocumentComparisonCheck : SandboxCheck
    {
        [JsonProperty(PropertyName = "secondary_document_filter")]
        public SandboxDocumentFilter SecondaryDocumentFilter { get; }

        public SandboxIdDocumentComparisonCheck(SandboxCheckResult result, SandboxDocumentFilter secondaryDocumentFilter)
    : base(result)
        {
            SecondaryDocumentFilter = secondaryDocumentFilter;
        }
    }
}
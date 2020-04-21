using Newtonsoft.Json;
using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxDocumentCheck : SandboxCheck
    {
        [JsonProperty(PropertyName = "document_filter")]
        public SandboxDocumentFilter DocumentFilter { get; }

        public SandboxDocumentCheck(SandboxCheckResult result)
            : base(result)
        {
        }

        public SandboxDocumentCheck(SandboxCheckResult result, SandboxDocumentFilter documentFilter)
            : base(result)
        {
            DocumentFilter = documentFilter;
        }
    }
}
using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxSupplementaryDocTextDataExtractionTask : SandboxTaskResult
    {
        public SandboxSupplementaryDocTextDataExtractionTask(SandboxSupplementaryDocTextDataExtractionTaskResult result, SandboxDocumentFilter documentFilter)
        {
            Result = result;
            DocumentFilter = documentFilter;
        }

        [JsonProperty(PropertyName = "result")]
        public SandboxSupplementaryDocTextDataExtractionTaskResult Result { get; }

        [JsonProperty(PropertyName = "document_filter")]
        public SandboxDocumentFilter DocumentFilter { get; }
    }
}
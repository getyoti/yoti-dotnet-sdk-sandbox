using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxDocumentTextDataExtractionTask : SandboxTaskResult
    {
        public SandboxDocumentTextDataExtractionTask(SandboxDocumentTextDataExtractionTaskResult result, SandboxDocumentFilter documentFilter)
        {
            Result = result;
            DocumentFilter = documentFilter;
        }

        [JsonProperty(PropertyName = "result")]
        public SandboxDocumentTextDataExtractionTaskResult Result { get; }

        [JsonProperty(PropertyName = "document_filter")]
        public SandboxDocumentFilter DocumentFilter { get; }
    }
}
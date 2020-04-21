using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxTaskResults
    {
        [JsonProperty(PropertyName = Constants.DocScanConstants.IdDocumentTextDataExtraction)]
        public List<SandboxDocumentTextDataExtractionTask> TextDataExtractionTasks { get; }

        public SandboxTaskResults(List<SandboxDocumentTextDataExtractionTask> textDataExtractionTasks)
        {
            TextDataExtractionTasks = textDataExtractionTasks;
        }
    }
}
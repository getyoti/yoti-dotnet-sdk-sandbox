using System.Collections.Generic;
using Newtonsoft.Json;
using Yoti.Auth.Constants;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxTaskResults
    {
        [JsonProperty(PropertyName = DocScanConstants.IdDocumentTextDataExtraction)]
        public List<SandboxDocumentTextDataExtractionTask> TextDataExtractionTasks { get; }

        public SandboxTaskResults(List<SandboxDocumentTextDataExtractionTask> textDataExtractionTasks)
        {
            TextDataExtractionTasks = textDataExtractionTasks;
        }
    }
}
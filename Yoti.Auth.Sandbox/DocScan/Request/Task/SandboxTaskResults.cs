using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxTaskResults
    {
        [JsonProperty(PropertyName = "ID_DOCUMENT_TEXT_DATA_EXTRACTION")]
        public List<SandboxDocumentTextDataExtractionTask> TextDataExtractionTasks { get; }

        [JsonProperty(PropertyName = "SUPPLEMENTARY_DOCUMENT_TEXT_DATA_EXTRACTION")]
        public List<SandboxSupplementaryDocTextDataExtractionTask> SupplementaryDocTextDataExtractionTasks { get; }

        public SandboxTaskResults(List<SandboxDocumentTextDataExtractionTask> textDataExtractionTasks, List<SandboxSupplementaryDocTextDataExtractionTask> supplementaryDocTextDataExtractionTask = null)
        {
            TextDataExtractionTasks = textDataExtractionTasks;
            SupplementaryDocTextDataExtractionTasks = supplementaryDocTextDataExtractionTask;
        }
    }
}
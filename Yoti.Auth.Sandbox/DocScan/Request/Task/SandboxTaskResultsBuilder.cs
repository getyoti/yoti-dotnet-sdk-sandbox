using System.Collections.Generic;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxTaskResultsBuilder
    {
        private readonly List<SandboxDocumentTextDataExtractionTask> _documentTextDataExtractionTasks = new List<SandboxDocumentTextDataExtractionTask>();

        public SandboxTaskResultsBuilder WithDocumentTextDataExtractionTask(SandboxDocumentTextDataExtractionTask textDataExtractionTask)
        {
            _documentTextDataExtractionTasks.Add(textDataExtractionTask);
            return this;
        }

        public SandboxTaskResults Build()
        {
            return new SandboxTaskResults(_documentTextDataExtractionTasks);
        }
    }
}
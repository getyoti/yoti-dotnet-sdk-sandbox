using System.Collections.Generic;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxTaskResultsBuilder
    {
        private readonly List<SandboxDocumentTextDataExtractionTask> _documentTextDataExtractionTasks = new List<SandboxDocumentTextDataExtractionTask>();
        private readonly List<SandboxSupplementaryDocTextDataExtractionTask> _supplementaryDocTextDataExtractionTasks = new List<SandboxSupplementaryDocTextDataExtractionTask>();

        public SandboxTaskResultsBuilder WithDocumentTextDataExtractionTask(SandboxDocumentTextDataExtractionTask textDataExtractionTask)
        {
            _documentTextDataExtractionTasks.Add(textDataExtractionTask);
            return this;
        }

        public SandboxTaskResultsBuilder WithSupplementaryDocTextDataExtractionTask(SandboxSupplementaryDocTextDataExtractionTask supplementaryDocTextDataExtractionTask)
        {
            _supplementaryDocTextDataExtractionTasks.Add(supplementaryDocTextDataExtractionTask);
            return this;
        }

        public SandboxTaskResults Build()
        {
            return new SandboxTaskResults(_documentTextDataExtractionTasks, _supplementaryDocTextDataExtractionTasks);
        }
    }
}
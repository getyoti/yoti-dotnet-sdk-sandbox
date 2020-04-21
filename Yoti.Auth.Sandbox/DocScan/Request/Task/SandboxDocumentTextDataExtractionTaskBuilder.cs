using System.Collections.Generic;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxDocumentTextDataExtractionTaskBuilder : SandboxTaskResult
    {
        private Dictionary<string, object> _documentFields = new Dictionary<string, object>();
        private SandboxDocumentFilter _documentFilter;

        public SandboxDocumentTextDataExtractionTaskBuilder WithDocumentField(string key, object value)
        {
            _documentFields.Add(key, value);
            return this;
        }

        public SandboxDocumentTextDataExtractionTaskBuilder WithDocumentFields(Dictionary<string, object> documentFields)
        {
            _documentFields = documentFields;
            return this;
        }

        public SandboxDocumentTextDataExtractionTaskBuilder WithDocumentFilter(SandboxDocumentFilter documentFilter)
        {
            _documentFilter = documentFilter;
            return this;
        }

        public SandboxDocumentTextDataExtractionTask Build()
        {
            SandboxDocumentTextDataExtractionTaskResult result = new SandboxDocumentTextDataExtractionTaskResult(_documentFields);
            return new SandboxDocumentTextDataExtractionTask(result, _documentFilter);
        }
    }
}
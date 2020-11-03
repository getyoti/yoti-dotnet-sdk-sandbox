using System.Collections.Generic;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxSupplementaryDocTextDataExtractionTaskBuilder : SandboxTaskResult
    {
        private Dictionary<string, object> _documentFields;
        private SandboxDocumentFilter _documentFilter;
        private string _detectedCountry;
        private SandboxDocumentTextDataExtractionRecommendation _recommendation;

        public SandboxSupplementaryDocTextDataExtractionTaskBuilder WithDocumentField(string key, object value)
        {
            if (_documentFields == null)
            {
                _documentFields = new Dictionary<string, object>();
            }
            _documentFields.Add(key, value);
            return this;
        }

        public SandboxSupplementaryDocTextDataExtractionTaskBuilder WithDocumentFields(Dictionary<string, object> documentFields)
        {
            _documentFields = documentFields;
            return this;
        }

        public SandboxSupplementaryDocTextDataExtractionTaskBuilder WithDocumentFilter(SandboxDocumentFilter documentFilter)
        {
            _documentFilter = documentFilter;
            return this;
        }

        public SandboxSupplementaryDocTextDataExtractionTaskBuilder WithDetectedCountry(string detectedCountry)
        {
            _detectedCountry = detectedCountry;
            return this;
        }

        public SandboxSupplementaryDocTextDataExtractionTaskBuilder WithRecommendation(SandboxDocumentTextDataExtractionRecommendation recommendation)
        {
            _recommendation = recommendation;
            return this;
        }

        public SandboxSupplementaryDocTextDataExtractionTask Build()
        {
            SandboxSupplementaryDocTextDataExtractionTaskResult result = new SandboxSupplementaryDocTextDataExtractionTaskResult(_documentFields, _detectedCountry, _recommendation);
            return new SandboxSupplementaryDocTextDataExtractionTask(result, _documentFilter);
        }
    }
}
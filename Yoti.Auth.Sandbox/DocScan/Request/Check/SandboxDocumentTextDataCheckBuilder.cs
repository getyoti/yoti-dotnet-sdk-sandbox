using System.Collections.Generic;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxDocumentTextDataCheckBuilder
        : SandboxDocumentCheckBuilder<SandboxDocumentTextDataCheckBuilder, SandboxDocumentTextDataCheck>
    {
        private Dictionary<string, object> _documentFields;

        public SandboxDocumentTextDataCheckBuilder WithDocumentField(string key, object value)
        {
            if (_documentFields == null)
            {
                _documentFields = new Dictionary<string, object>();
            }
            _documentFields.Add(key, value);
            return this;
        }

        public SandboxDocumentTextDataCheckBuilder WithDocumentFields(Dictionary<string, object> documentFields)
        {
            _documentFields = documentFields;
            return this;
        }

        public override SandboxDocumentTextDataCheck Build()
        {
            Validation.NotNull(Recommendation, nameof(Recommendation));

            SandboxCheckReport report = new SandboxCheckReport(Recommendation, Breakdown);
            SandboxDocumentTextDataCheckResult result = new SandboxDocumentTextDataCheckResult(report, _documentFields);

            return new SandboxDocumentTextDataCheck(result, DocumentFilter);
        }
    }
}
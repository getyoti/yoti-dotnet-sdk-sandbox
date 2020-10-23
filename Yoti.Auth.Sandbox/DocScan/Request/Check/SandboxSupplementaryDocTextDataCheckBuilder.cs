using System.Collections.Generic;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxSupplementaryDocTextDataCheckBuilder
        : SandboxDocumentCheckBuilder<SandboxSupplementaryDocTextDataCheckBuilder, SandboxSupplementaryDocTextDataCheck>
    {
        private Dictionary<string, object> _documentFields;

        public SandboxSupplementaryDocTextDataCheckBuilder WithDocumentField(string key, object value)
        {
            if (_documentFields == null)
            {
                _documentFields = new Dictionary<string, object>();
            }

            _documentFields.Add(key, value);
            return this;
        }

        public SandboxSupplementaryDocTextDataCheckBuilder WithDocumentFields(Dictionary<string, object> documentFields)
        {
            _documentFields = documentFields;
            return this;
        }

        public override SandboxSupplementaryDocTextDataCheck Build()
        {
            Validation.NotNull(Recommendation, nameof(Recommendation));

            var report = new SandboxCheckReport(Recommendation, Breakdown);
            var result = new SandboxSupplementaryDocTextDataCheckResult(report, _documentFields);

            return new SandboxSupplementaryDocTextDataCheck(result, DocumentFilter);
        }
    }
}
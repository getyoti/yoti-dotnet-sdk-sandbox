using System.Collections.Generic;

namespace Yoti.Auth.Sandbox.DocScan.Request.Resource.Extraction
{
    public class TextExtractionResourceBuilder
    {
        private string _clientExtractionOutcome;
        private Dictionary<string, object> _documentFields = new Dictionary<string, object>();

        public TextExtractionResourceBuilder WithClientExtractionOutcome(string clientExtractionOutcome)
        {
            _clientExtractionOutcome = clientExtractionOutcome;
            return this;
        }

        public TextExtractionResourceBuilder WithDocumentField(string key, object value)
        {
            _documentFields.Add(key, value);
            return this;
        }

        public TextExtractionResourceBuilder WithDocumentFields(Dictionary<string, object> documentFields)
        {
            _documentFields = documentFields;
            return this;
        }

        public TextExtractionResource Build()
        {
            Validation.NotNull(_clientExtractionOutcome, nameof(_clientExtractionOutcome));
            Validation.NotNull(_documentFields, nameof(_documentFields));

            return new TextExtractionResource(_clientExtractionOutcome, _documentFields);
        }
    }
}
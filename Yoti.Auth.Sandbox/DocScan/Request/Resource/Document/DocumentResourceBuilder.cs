namespace Yoti.Auth.Sandbox.DocScan.Request.Resource.Document
{
    public class DocumentResourceBuilder
    {
        private string _documentType;
        private string _issuingCountry;

        public DocumentResourceBuilder WithDocumentType(string documentType)
        {
            _documentType = documentType;
            return this;
        }

        public DocumentResourceBuilder WithIssuingCountry(string issuingCountry)
        {
            _issuingCountry = issuingCountry;
            return this;
        }

        public DocumentResource Build()
        {
            Validation.NotNullOrEmpty(_documentType, nameof(_documentType));
            Validation.NotNullOrEmpty(_issuingCountry, nameof(_issuingCountry));

            return new DocumentResource(_documentType, _issuingCountry);
        }
    }
}
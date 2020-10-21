using System.Collections.Generic;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxDocumentFilterBuilder
    {
        private List<string> _documentTypes;
        private List<string> _countryCodes;

        public SandboxDocumentFilterBuilder WithDocumentType(string documentType)
        {
            if (_documentTypes == null)
            {
                _documentTypes = new List<string>();
            }

            _documentTypes.Add(documentType);
            return this;
        }

        public SandboxDocumentFilterBuilder WithDocumentTypes(List<string> documentTypes)
        {
            _documentTypes = documentTypes;
            return this;
        }

        public SandboxDocumentFilterBuilder WithCountryCode(string countryCode)
        {
            if (_countryCodes == null)
            {
                _countryCodes = new List<string>();
            }

            _countryCodes.Add(countryCode);
            return this;
        }

        public SandboxDocumentFilterBuilder WithCountryCodes(List<string> countryCodes)
        {
            _countryCodes = countryCodes;
            return this;
        }

        public SandboxDocumentFilter Build()
        {
            return new SandboxDocumentFilter(_documentTypes, _countryCodes);
        }
    }
}
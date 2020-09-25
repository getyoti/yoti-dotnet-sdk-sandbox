using System.Collections.Generic;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxDocumentFilterBuilder
    {
        private List<string> _documentTypes;
        private List<string> _countryCodes;

        public SandboxDocumentFilterBuilder WithDocumentTypes(List<string> documentTypes)
        {
            _documentTypes = documentTypes;
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
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxDocumentFilter
    {
        public SandboxDocumentFilter(List<string> documentTypes, List<string> countryCodes)
        {
            DocumentTypes = documentTypes;
            CountryCodes = countryCodes;
        }

        [JsonProperty(PropertyName = "document_types")]
        public List<string> DocumentTypes { get; }

        [JsonProperty(PropertyName = "country_codes")]
        public List<string> CountryCodes { get; }
    }
}
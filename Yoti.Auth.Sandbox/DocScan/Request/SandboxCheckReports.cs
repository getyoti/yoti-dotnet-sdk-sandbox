using System.Collections.Generic;
using Newtonsoft.Json;
using Yoti.Auth.Sandbox.DocScan.Request.Check;

namespace Yoti.Auth.Sandbox.DocScan.Request
{
    public class SandboxCheckReports
    {
        public SandboxCheckReports(
            List<SandboxDocumentTextDataCheck> textDataChecks,
            List<SandboxDocumentAuthenticityCheck> documentAuthenticityChecks,
            List<SandboxLivenessCheck> livenessChecks,
            List<SandboxDocumentFaceMatchCheck> documentFaceMatchChecks,
            int? asyncReportDelay)
        {
            TextDataCheck = textDataChecks;
            DocumentAuthenticityCheck = documentAuthenticityChecks;
            LivenessChecks = livenessChecks;
            DocumentFaceMatchCheck = documentFaceMatchChecks;
            AsyncReportDelay = asyncReportDelay;
        }

        [JsonProperty(PropertyName = "ID_DOCUMENT_TEXT_DATA_CHECK")]
        public List<SandboxDocumentTextDataCheck> TextDataCheck { get; }

        [JsonProperty(PropertyName = "ID_DOCUMENT_AUTHENTICITY")]
        public List<SandboxDocumentAuthenticityCheck> DocumentAuthenticityCheck { get; }

        [JsonProperty(PropertyName = "LIVENESS")]
        public List<SandboxLivenessCheck> LivenessChecks { get; }

        [JsonProperty(PropertyName = "ID_DOCUMENT_FACE_MATCH")]
        public List<SandboxDocumentFaceMatchCheck> DocumentFaceMatchCheck { get; }

        [JsonProperty(PropertyName = "async_report_delay")]
        public int? AsyncReportDelay { get; }
    }
}
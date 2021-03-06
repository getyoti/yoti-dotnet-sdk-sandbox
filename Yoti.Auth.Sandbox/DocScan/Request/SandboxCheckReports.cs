﻿using System.Collections.Generic;
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
            int? asyncReportDelay,
            List<SandboxIdDocumentComparisonCheck> idDocumentComparisonChecks = null,
            List<SandboxSupplementaryDocTextDataCheck> supplementaryDocTextDataChecks = null,
            SandboxThirdPartyIdentityCheck thirdPartyIdentityCheck = null)
        {
            if (idDocumentComparisonChecks == null)
            {
                idDocumentComparisonChecks = new List<SandboxIdDocumentComparisonCheck>();
            }

            if (supplementaryDocTextDataChecks == null)
            {
                supplementaryDocTextDataChecks = new List<SandboxSupplementaryDocTextDataCheck>();
            }

            TextDataCheck = textDataChecks;
            DocumentAuthenticityCheck = documentAuthenticityChecks;
            LivenessChecks = livenessChecks;
            DocumentFaceMatchCheck = documentFaceMatchChecks;
            IdDocumentComparisonChecks = idDocumentComparisonChecks;
            SupplementaryDocTextDataChecks = supplementaryDocTextDataChecks;
            ThirdPartyIdentityCheck = thirdPartyIdentityCheck;
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

        [JsonProperty(PropertyName = "ID_DOCUMENT_COMPARISON")]
        public List<SandboxIdDocumentComparisonCheck> IdDocumentComparisonChecks { get; }

        [JsonProperty(PropertyName = "SUPPLEMENTARY_DOCUMENT_TEXT_DATA_CHECK")]
        public List<SandboxSupplementaryDocTextDataCheck> SupplementaryDocTextDataChecks { get; }

        [JsonProperty(PropertyName = "THIRD_PARTY_IDENTITY")]
        public SandboxThirdPartyIdentityCheck ThirdPartyIdentityCheck { get; }

        [JsonProperty(PropertyName = "async_report_delay")]
        public int? AsyncReportDelay { get; }
    }
}
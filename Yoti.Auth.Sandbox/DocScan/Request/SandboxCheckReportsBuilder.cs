﻿using System.Collections.Generic;
using Yoti.Auth.Sandbox.DocScan.Request.Check;

namespace Yoti.Auth.Sandbox.DocScan.Request
{
    public class SandboxCheckReportsBuilder
    {
        private readonly List<SandboxDocumentTextDataCheck> _textDataChecks;
        private readonly List<SandboxDocumentAuthenticityCheck> _documentAuthenticityChecks;
        private readonly List<SandboxLivenessCheck> _livenessChecks;
        private readonly List<SandboxDocumentFaceMatchCheck> _documentFaceMatchChecks;
        private int? _asyncReportDelay;

        public SandboxCheckReportsBuilder()

        {
            _textDataChecks = new List<SandboxDocumentTextDataCheck>();
            _documentAuthenticityChecks = new List<SandboxDocumentAuthenticityCheck>();
            _livenessChecks = new List<SandboxLivenessCheck>();
            _documentFaceMatchChecks = new List<SandboxDocumentFaceMatchCheck>();
        }

        public SandboxCheckReportsBuilder WithDocumentTextDataCheck(SandboxDocumentTextDataCheck textDataCheckReport)
        {
            _textDataChecks.Add(textDataCheckReport);
            return this;
        }

        public SandboxCheckReportsBuilder WithDocumentAuthenticityCheck(SandboxDocumentAuthenticityCheck documentAuthenticityReport)
        {
            _documentAuthenticityChecks.Add(documentAuthenticityReport);
            return this;
        }

        public SandboxCheckReportsBuilder WithLivenessCheck(SandboxLivenessCheck livenessReport)
        {
            _livenessChecks.Add(livenessReport);
            return this;
        }

        public SandboxCheckReportsBuilder WithDocumentFaceMatchCheck(SandboxDocumentFaceMatchCheck documentFaceMatchReport)
        {
            _documentFaceMatchChecks.Add(documentFaceMatchReport);
            return this;
        }

        public SandboxCheckReportsBuilder WithAsyncReportDelay(int asyncReportDelay)
        {
            _asyncReportDelay = asyncReportDelay;
            return this;
        }

        public SandboxCheckReports Build()
        {
            return new SandboxCheckReports(_textDataChecks, _documentAuthenticityChecks, _livenessChecks, _documentFaceMatchChecks, _asyncReportDelay);
        }
    }
}
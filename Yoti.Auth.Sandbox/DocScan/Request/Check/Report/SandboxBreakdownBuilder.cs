using System.Collections.Generic;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check.Report
{
    public class SandboxBreakdownBuilder
    {
        private string _subCheck;
        private string _result;
        private readonly List<SandboxDetail> _details = new List<SandboxDetail>();

        public SandboxBreakdownBuilder WithSubCheck(string subCheck)
        {
            _subCheck = subCheck;
            return this;
        }

        public SandboxBreakdownBuilder WithResult(string result)
        {
            _result = result;
            return this;
        }

        public SandboxBreakdownBuilder WithDetail(SandboxDetail detail)
        {
            _details.Add(detail);
            return this;
        }

        public SandboxBreakdown Build()
        {
            Validation.NotNullOrEmpty(_subCheck, nameof(_subCheck));
            Validation.NotNullOrEmpty(_result, nameof(_result));

            return new SandboxBreakdown(_subCheck, _result, _details);
        }
    }
}
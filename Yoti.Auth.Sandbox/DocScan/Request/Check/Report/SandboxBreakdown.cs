using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check.Report
{
    public class SandboxBreakdown
    {
        public SandboxBreakdown(string subCheck, string result, List<SandboxDetail> details)
        {
            SubCheck = subCheck;
            Result = result;

            if (details == null)
                details = new List<SandboxDetail>();

            Details = details;
        }

        [JsonProperty(PropertyName = "sub_check")]
        public string SubCheck { get; private set; }

        [JsonProperty(PropertyName = "result")]
        public string Result { get; private set; }

        [JsonProperty(PropertyName = "details")]
        public List<SandboxDetail> Details { get; private set; }
    }
}
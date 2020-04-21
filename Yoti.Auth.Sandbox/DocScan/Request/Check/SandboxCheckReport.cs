using System.Collections.Generic;
using Newtonsoft.Json;
using Yoti.Auth.Sandbox.DocScan.Request.Check.Report;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxCheckReport
    {
        public SandboxCheckReport(SandboxRecommendation recommendation, List<SandboxBreakdown> breakdown)
        {
            Recommendation = recommendation;
            Breakdown = breakdown;
        }

        [JsonProperty(PropertyName = "recommendation")]
        public SandboxRecommendation Recommendation { get; }

        [JsonProperty(PropertyName = "breakdown")]
        public List<SandboxBreakdown> Breakdown { get; }
    }
}
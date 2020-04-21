using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxCheckResult
    {
        public SandboxCheckResult(SandboxCheckReport report)
        {
            Report = report;
        }

        [JsonProperty(PropertyName = "report")]
        public SandboxCheckReport Report { get; }
    }
}
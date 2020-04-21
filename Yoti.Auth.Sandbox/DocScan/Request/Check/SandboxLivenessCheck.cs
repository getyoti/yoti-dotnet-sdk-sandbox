using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxLivenessCheck : SandboxCheck
    {
        public SandboxLivenessCheck(SandboxCheckResult result, string livenessType)
            : base(result)
        {
            LivenessType = livenessType;
        }

        [JsonProperty(PropertyName = "liveness_type")]
        public string LivenessType { get; set; }
    }
}
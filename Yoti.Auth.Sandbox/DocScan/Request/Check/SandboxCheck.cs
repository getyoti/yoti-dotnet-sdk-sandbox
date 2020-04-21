using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxCheck
    {
        public SandboxCheck(SandboxCheckResult result)
        {
            Result = result;
        }

        [JsonProperty(PropertyName = "result")]
        public virtual SandboxCheckResult Result { get; }
    }
}
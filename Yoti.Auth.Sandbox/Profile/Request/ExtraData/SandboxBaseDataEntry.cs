using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.Profile.Request.ExtraData
{
    public class SandboxBaseDataEntry
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        public SandboxBaseDataEntry(string type)
        {
            Type = type;
        }
    }
}
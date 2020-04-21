using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check.Report
{
    public class SandboxDetail
    {
        public SandboxDetail(string name, string value)
        {
            Name = name;
            Value = value;
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; private set; }
    }
}
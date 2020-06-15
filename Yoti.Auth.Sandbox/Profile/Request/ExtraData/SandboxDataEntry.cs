using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.Profile.Request.ExtraData
{
    public class SandboxDataEntry<T> : SandboxBaseDataEntry
    {
        [JsonProperty(PropertyName = "value")]
        public T Value { get; private set; }

        public SandboxDataEntry(string type, T value)
            : base(type)
        {
            Value = value;
        }
    }
}
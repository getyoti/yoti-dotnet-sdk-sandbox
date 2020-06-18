using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.Profile.Request.ExtraData.ThirdParty
{
    public class SandboxDefinition
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        public SandboxDefinition(string name)
        {
            Validation.NotNullOrEmpty(name, nameof(name));

            Name = name;
        }
    }
}
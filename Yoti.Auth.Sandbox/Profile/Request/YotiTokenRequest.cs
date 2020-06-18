using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Yoti.Auth.Sandbox.Profile.Request.Attribute;
using Yoti.Auth.Sandbox.Profile.Request.ExtraData;

namespace Yoti.Auth.Sandbox.Profile.Request
{
    public class YotiTokenRequest
    {
        public YotiTokenRequest(string rememberMeId, ReadOnlyCollection<SandboxAttribute> sandboxAttributes, SandboxExtraData extraData = null)
        {
            RememberMeId = rememberMeId;
            SandboxAttributes = sandboxAttributes;
            ExtraData = extraData;
        }

        [JsonProperty(PropertyName = "remember_me_id")]
        public string RememberMeId { get; private set; }

        [JsonProperty(PropertyName = "profile_attributes")]
        public ReadOnlyCollection<SandboxAttribute> SandboxAttributes { get; }

        [JsonProperty(PropertyName = "extra_data")]
        public SandboxExtraData ExtraData { get; }

        public static YotiTokenRequestBuilder Builder()
        {
            return new YotiTokenRequestBuilder();
        }
    }
}
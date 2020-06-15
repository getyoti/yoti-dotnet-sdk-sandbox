using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.Profile.Request.ExtraData.ThirdParty
{
    public class SandboxAttributeIssuanceDetailsValue
    {
        [JsonProperty(PropertyName = "issuance_token")]
        public string IssuanceToken { get; private set; }

        [JsonProperty(PropertyName = "issuing_attributes")]
        public SandboxIssuingAttributes IssuingAttributes { get; private set; }

        public SandboxAttributeIssuanceDetailsValue(string issuanceToken, SandboxIssuingAttributes issuingAttributes)
        {
            IssuanceToken = issuanceToken;
            IssuingAttributes = issuingAttributes;
        }
    }
}
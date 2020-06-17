namespace Yoti.Auth.Sandbox.Profile.Request.ExtraData.ThirdParty
{
    public class SandboxAttributeIssuanceDetails : SandboxDataEntry<SandboxAttributeIssuanceDetailsValue>
    {
        public SandboxAttributeIssuanceDetails(SandboxAttributeIssuanceDetailsValue value)
            : base("THIRD_PARTY_ATTRIBUTE", value)
        {
        }
    }
}
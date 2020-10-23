using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxSupplementaryDocTextDataCheck : SandboxDocumentCheck
    {
        public SandboxSupplementaryDocTextDataCheck(SandboxSupplementaryDocTextDataCheckResult result, SandboxDocumentFilter documentFilter)
            : base(result, documentFilter)
        {
        }
    }
}
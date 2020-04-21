using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxDocumentAuthenticityCheck : SandboxDocumentCheck
    {
        public SandboxDocumentAuthenticityCheck(SandboxCheckResult result, SandboxDocumentFilter documentFilter)
            : base(result, documentFilter)
        {
        }
    }
}
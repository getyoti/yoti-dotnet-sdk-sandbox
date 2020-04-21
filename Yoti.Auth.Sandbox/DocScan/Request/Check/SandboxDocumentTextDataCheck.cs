using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxDocumentTextDataCheck : SandboxDocumentCheck
    {
        public SandboxDocumentTextDataCheck(SandboxDocumentTextDataCheckResult result)
            : base(result)
        {
        }

        public SandboxDocumentTextDataCheck(SandboxDocumentTextDataCheckResult result, SandboxDocumentFilter documentFilter)
            : base(result, documentFilter)
        {
        }
    }
}
using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public class SandboxDocumentFaceMatchCheck : SandboxDocumentCheck
    {
        public SandboxDocumentFaceMatchCheck(SandboxCheckResult result)
          : base(result)
        {
        }

        public SandboxDocumentFaceMatchCheck(SandboxCheckResult result, SandboxDocumentFilter documentFilter)
            : base(result, documentFilter)
        {
        }
    }
}
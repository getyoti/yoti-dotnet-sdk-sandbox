using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.DocScan.Request.Check
{
    public abstract class SandboxDocumentCheckBuilder<TBuilder, TCheck>
        : SandboxCheckBuilder<TBuilder, TCheck>
        where TBuilder : SandboxDocumentCheckBuilder<TBuilder, TCheck>
        where TCheck : SandboxDocumentCheck
    {
        public SandboxDocumentFilter DocumentFilter { get; private set; }

        public TBuilder WithDocumentFilter(SandboxDocumentFilter documentFilter)
        {
            DocumentFilter = documentFilter;
            return (TBuilder)this;
        }
    }
}
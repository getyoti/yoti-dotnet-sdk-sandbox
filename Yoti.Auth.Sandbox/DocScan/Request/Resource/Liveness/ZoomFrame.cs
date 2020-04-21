using System.Net.Http.Headers;

namespace Yoti.Auth.Sandbox.DocScan.Request.Resource.Liveness
{
    public class ZoomFrame : SandboxMedia
    {
        public ZoomFrame(MediaTypeHeaderValue mediaType, byte[] binaryContent)
            : base(mediaType, binaryContent)
        {
        }
    }
}
using System.Net.Http.Headers;

namespace Yoti.Auth.Sandbox.DocScan.Request.Resource.Liveness
{
    public class FaceMap : SandboxMedia
    {
        public FaceMap(MediaTypeHeaderValue mediaType, byte[] binaryContent)
            : base(mediaType, binaryContent)
        {
        }
    }
}
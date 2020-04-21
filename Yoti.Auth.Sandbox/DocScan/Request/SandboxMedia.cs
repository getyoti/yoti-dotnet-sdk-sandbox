using System.Net.Http.Headers;

namespace Yoti.Auth.Sandbox.DocScan.Request.Resource
{
    public class SandboxMedia
    {
        public SandboxMedia(MediaTypeHeaderValue mediaType, byte[] binaryContent) : base()
        {
            MediaType = mediaType;
            SetBinaryContent(binaryContent);
        }

        public MediaTypeHeaderValue MediaType { get; }

        private byte[] _binaryContent;

        public byte[] GetBinaryContent()
        {
            return _binaryContent;
        }

        public void SetBinaryContent(byte[] value)
        {
            _binaryContent = value;
        }
    }
}
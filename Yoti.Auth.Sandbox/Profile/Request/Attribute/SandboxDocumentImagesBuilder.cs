using System.Collections.Generic;
using Yoti.Auth.Images;

namespace Yoti.Auth.Sandbox.Profile.Request.Attribute
{
    public class SandboxDocumentImagesBuilder
    {
        private readonly List<Image> _imageList = new List<Image>();

        public SandboxDocumentImagesBuilder WithJpegContent(byte[] content)
        {
            _imageList.Add(new JpegImage(content));
            return this;
        }

        public SandboxDocumentImagesBuilder WithPngContent(byte[] content)
        {
            _imageList.Add(new PngImage(content));
            return this;
        }

        public SandboxDocumentImages Build()
        {
            return new SandboxDocumentImages(_imageList);
        }
    }
}
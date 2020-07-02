using System.Collections.Generic;
using System.Linq;
using Yoti.Auth.Images;

namespace Yoti.Auth.Sandbox.Profile.Request.Attribute
{
    public class SandboxDocumentImages
    {
        public SandboxDocumentImages(List<Image> imageList)
        {
            Images = imageList;
        }

        public List<Image> Images { get; private set; }

        public string GetValues()
        {
            return string.Join("&", Images.Select(x => x.GetBase64URI()));
        }
    }
}
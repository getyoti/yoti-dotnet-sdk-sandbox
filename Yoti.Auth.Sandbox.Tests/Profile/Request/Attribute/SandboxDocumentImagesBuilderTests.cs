using System;
using System.Linq;
using System.Text;
using Xunit;
using Yoti.Auth.Sandbox.Profile.Request.Attribute;

namespace Yoti.Auth.Sandbox.Tests.Profile.Request.Attribute
{
    public class SandboxDocumentImagesBuilderTests
    {
        private static readonly byte[] _someContent = Encoding.UTF8.GetBytes("some image content");
        private static readonly string base64Content = Convert.ToBase64String(_someContent);
        private const string _mimeTypeJpeg = "image/jpeg";
        private const string _mimeTypePng = "image/png";
        private readonly string expectedJpegBase64DataUrl = $"data:{_mimeTypeJpeg};base64,{base64Content}";
        private readonly string expectedPngBase64DataUrl = $"data:{_mimeTypePng};base64,{base64Content}";

        [Fact]
        public void ShouldAddJpegContent()
        {
            SandboxDocumentImages documentImages = new SandboxDocumentImagesBuilder()
                .WithJpegContent(_someContent)
                .Build();

            Assert.Equal(_someContent, documentImages.Images.Single().GetContent());
            Assert.Equal(expectedJpegBase64DataUrl, documentImages.GetValues());
            Assert.Equal(_mimeTypeJpeg, documentImages.Images.Single().GetMIMEType());
        }

        [Fact]
        public void ShouldAddPngContent()
        {
            SandboxDocumentImages documentImages = new SandboxDocumentImagesBuilder()
               .WithPngContent(_someContent)
               .Build();

            Assert.Equal(_someContent, documentImages.Images[0].GetContent());
            Assert.Equal(expectedPngBase64DataUrl, documentImages.GetValues());
            Assert.Equal(_mimeTypePng, documentImages.Images.Single().GetMIMEType());
        }

        [Fact]
        public void ShouldAddMultipleImages()
        {
            SandboxDocumentImages documentImages = new SandboxDocumentImagesBuilder()
              .WithPngContent(_someContent)
              .WithPngContent(_someContent)
              .WithJpegContent(_someContent)
              .Build();

            Assert.Equal(3, documentImages.Images.Count);
            Assert.Equal(
                $"{expectedPngBase64DataUrl}&{expectedPngBase64DataUrl}&{expectedJpegBase64DataUrl}",
                documentImages.GetValues());
        }
    }
}
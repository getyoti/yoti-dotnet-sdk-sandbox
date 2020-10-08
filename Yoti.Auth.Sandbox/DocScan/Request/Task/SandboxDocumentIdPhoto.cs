using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Task
{
    public class SandboxDocumentIdPhoto
    {
        [JsonProperty(PropertyName = "content_type")]
        public string ContentType { get; }

        [JsonProperty(PropertyName = "data")]
        public string Base64Data { get; }

        public SandboxDocumentIdPhoto(string contentType, string base64Data)
        {
            ContentType = contentType;
            Base64Data = base64Data;
        }
    }
}
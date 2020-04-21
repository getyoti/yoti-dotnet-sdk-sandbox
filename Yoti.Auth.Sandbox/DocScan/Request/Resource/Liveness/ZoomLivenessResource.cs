using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.DocScan.Request.Resource.Liveness
{
    public class ZoomLivenessResource : SandboxPayload
    {
        [JsonProperty(PropertyName = "source")]
        public string Source { get; }

        public ZoomLivenessResource(string source)
        {
            Source = source;
        }

        public static ZoomLivenessResource ForWeb()
        {
            return new ZoomLivenessResource("WEB");
        }

        public static ZoomLivenessResource ForNative()
        {
            return new ZoomLivenessResource("NATIVE");
        }
    }
}
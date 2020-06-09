using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Yoti.Auth.Sandbox.Profile.Request;
using Yoti.Auth.Sandbox.Profile.Response;
using Yoti.Auth.Web;

namespace Yoti.Auth.Sandbox.Profile
{
    public class SandboxClient
    {
        private const string _yotiSandboxPathPrefix = "/sandbox/v1";
        private readonly Uri _defaultSandboxApiUrl = new Uri(Constants.Api.DefaultYotiHost + _yotiSandboxPathPrefix);
        private readonly HttpClient _httpClient;
        internal Uri SandboxApiUri { get; private set; }
        private readonly string _sdkId;
        private readonly AsymmetricCipherKeyPair _keyPair;

        public static SandboxClientBuilder Builder()
        {
            return new SandboxClientBuilder();
        }

        internal SandboxClient(string sdkId, AsymmetricCipherKeyPair keyPair, Uri apiUri = null, HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
            SandboxApiUri = apiUri ?? _defaultSandboxApiUrl;
            _sdkId = sdkId;
            _keyPair = keyPair;
        }

        public string SetupSharingProfile(YotiTokenRequest yotiTokenRequest)
        {
            try
            {
                string serializedTokenRequest = JsonConvert.SerializeObject(
                    yotiTokenRequest,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                byte[] body = Encoding.UTF8.GetBytes(serializedTokenRequest);

                Yoti.Auth.Web.Request request = new RequestBuilder()
                    .WithKeyPair(_keyPair)
                    .WithBaseUri(SandboxApiUri)
                    .WithEndpoint($"/apps/{_sdkId}/tokens")
                    .WithHttpMethod(HttpMethod.Post)
                    .WithContent(body)
                    .WithContentHeader(Constants.Api.ContentTypeHeader, Constants.Api.ContentTypeJson)
                    .Build();

                HttpResponseMessage response = request.Execute(_httpClient).Result;

                if (!response.IsSuccessStatusCode)
                {
                    Yoti.Auth.Web.Response.CreateYotiExceptionFromStatusCode<SandboxException>(response);
                }

                YotiTokenResponse yotiTokenResponse =
                    JsonConvert.DeserializeObject<YotiTokenResponse>(
                        response.Content.ReadAsStringAsync().Result);

                return yotiTokenResponse.Token;
            }
            catch (Exception ex)
            {
                throw new SandboxException(Properties.Resources.SharingProfileError, ex);
            }
        }
    }
}
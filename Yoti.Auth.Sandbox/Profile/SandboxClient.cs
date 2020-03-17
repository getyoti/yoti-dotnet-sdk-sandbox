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
        private readonly Uri _apiUri;
        private readonly string _appId;
        private readonly AsymmetricCipherKeyPair _keyPair;

        public static SandboxClientBuilder Builder()
        {
            return new SandboxClientBuilder();
        }

        public SandboxClient(HttpClient httpClient, Uri apiUri, string appId, AsymmetricCipherKeyPair keyPair)
        {
            _httpClient = httpClient;
            _apiUri = apiUri ?? _defaultSandboxApiUrl;
            _appId = appId;
            _keyPair = keyPair;
        }

        public string SetupSharingProfile(YotiTokenRequest yotiTokenRequest)
        {
            try
            {
                string serializedTokenRequest = JsonConvert.SerializeObject(yotiTokenRequest);
                byte[] body = Encoding.UTF8.GetBytes(serializedTokenRequest);

                Yoti.Auth.Web.Request request = new RequestBuilder()
                    .WithKeyPair(_keyPair)
                    .WithBaseUri(_apiUri)
                    .WithEndpoint($"/apps/{_appId}/tokens")
                    .WithHttpMethod(HttpMethod.Post)
                    .WithContent(body)
                    .Build();

                HttpResponseMessage response = request.Execute(_httpClient).Result;

                if (!response.IsSuccessStatusCode)
                {
                    Yoti.Auth.Web.Response.CreateExceptionFromStatusCode<SandboxException>(response);
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
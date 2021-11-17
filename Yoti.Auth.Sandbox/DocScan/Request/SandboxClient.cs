using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Yoti.Auth.Web;

namespace Yoti.Auth.Sandbox.DocScan.Request
{
    public class SandboxClient
    {
        private const string _yotiDocScanSandboxPathPrefix = "/sandbox/idverify/v1";
        private readonly Uri _defaultDocScanSandboxApiUrl = new Uri(Yoti.Auth.Constants.Api.DefaultYotiHost + _yotiDocScanSandboxPathPrefix);

        private readonly HttpClient _httpClient;
        internal Uri DocScanSandboxApiUrl { get; private set; }
        private readonly string _sdkId;
        private readonly AsymmetricCipherKeyPair _keyPair;

        public static SandboxClientBuilder Builder(HttpClient httpClient = null)
        {
            return new SandboxClientBuilder(httpClient);
        }

        internal SandboxClient(string sdkId, AsymmetricCipherKeyPair keyPair, Uri apiUri = null, HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
            DocScanSandboxApiUrl = apiUri ?? _defaultDocScanSandboxApiUrl;
            _sdkId = sdkId;
            _keyPair = keyPair;
        }

        public void ConfigureSessionResponse(string sessionId, ResponseConfig sandboxExpection)
        {
            try
            {
                string serializedSandboxResponseConfig = JsonConvert.SerializeObject(
                sandboxExpection,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                byte[] body = Encoding.UTF8.GetBytes(serializedSandboxResponseConfig);

                Yoti.Auth.Web.Request request = new RequestBuilder()
                    .WithKeyPair(_keyPair)
                    .WithBaseUri(DocScanSandboxApiUrl)
                    .WithEndpoint($"/sessions/{sessionId}/response-config")
                    .WithHttpMethod(HttpMethod.Put)
                    .WithContent(body)
                    .WithQueryParam("sdkId", _sdkId)
                    .Build();

                HttpResponseMessage response = request.Execute(_httpClient).Result;

                if (!response.IsSuccessStatusCode)
                {
                    Response.CreateYotiExceptionFromStatusCode<SandboxException>(response);
                }
            }
            catch (Exception ex)
            {
                if (ex is SandboxException)
                {
                    throw;
                }

                throw new SandboxException(Properties.Resources.DocScanSessionResponseError, ex);
            }
        }

        public void ConfigureApplicationResponse(ResponseConfig sandboxExpection)
        {
            try
            {
                string serializedSandboxResponseConfig = JsonConvert.SerializeObject(
               sandboxExpection,
               new JsonSerializerSettings
               {
                   NullValueHandling = NullValueHandling.Ignore
               });
                byte[] body = Encoding.UTF8.GetBytes(serializedSandboxResponseConfig);

                Yoti.Auth.Web.Request request = new RequestBuilder()
                    .WithKeyPair(_keyPair)
                    .WithBaseUri(DocScanSandboxApiUrl)
                    .WithEndpoint($"/apps/{_sdkId}/response-config")
                    .WithHttpMethod(HttpMethod.Put)
                    .WithContent(body)
                    .Build();

                HttpResponseMessage response = request.Execute(_httpClient).Result;

                if (!response.IsSuccessStatusCode)
                {
                    Response.CreateYotiExceptionFromStatusCode<SandboxException>(response);
                }
            }
            catch (Exception ex)
            {
                if (ex is SandboxException)
                {
                    throw;
                }

                throw new SandboxException(Properties.Resources.DocScanApplicationResponseError, ex);
            }
        }
    }
}
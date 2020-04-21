using System;
using System.IO;
using System.Net.Http;
using Org.BouncyCastle.Crypto;

namespace Yoti.Auth.Sandbox.DocScan.Request
{
    public class SandboxClientBuilder
    {
        private string _sdkId;
        private AsymmetricCipherKeyPair _keyPair;
        private Uri _apiUri;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initialise SandboxClientBuilder. If a <see cref="HttpClient"/>
        /// is provided, this will be used. Otherwise a new instance will be created.
        /// </summary>
        /// <param name="httpClient">Optional httpClient</param>
        public SandboxClientBuilder(HttpClient httpClient = null)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Use this method to override the default API URI.
        /// </summary>
        /// <param name="apiUri"></param>
        /// <returns><see cref="SandboxClientBuilder"/></returns>
        public SandboxClientBuilder WithApiUri(Uri apiUri)
        {
            _apiUri = apiUri;

            return this;
        }

        /// <summary>
        /// Set the Yoti Client SDK ID. This can be found from the Yoti Hub.
        /// </summary>
        /// <param name="sdkId"></param>
        /// <returns><see cref="SandboxClientBuilder"/></returns>
        public SandboxClientBuilder WithClientSdkId(string sdkId)
        {
            _sdkId = sdkId;
            return this;
        }

        /// <summary>
        /// Setting the keyPair with a <see cref="AsymmetricCipherKeyPair"/>.
        /// To get this object from a StreamReader, use <see cref="Yoti.Auth.CryptoEngine.LoadRsaKey(StreamReader)"/>.
        /// </summary>
        /// <param name="keyPair"></param>
        /// <returns><see cref="SandboxClientBuilder"/></returns>
        public SandboxClientBuilder WithKeyPair(AsymmetricCipherKeyPair keyPair)
        {
            _keyPair = keyPair;
            return this;
        }

        public SandboxClient Build()
        {
            Validation.NotNull(_sdkId, nameof(_sdkId));
            Validation.NotNull(_keyPair, nameof(_keyPair));

            return new SandboxClient(_sdkId, _keyPair, _apiUri, _httpClient);
        }
    }
}
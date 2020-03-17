using System;
using System.Net.Http;
using Org.BouncyCastle.Crypto;

namespace Yoti.Auth.Sandbox.Profile
{
    public class SandboxClientBuilder
    {
        private string _appId;
        private AsymmetricCipherKeyPair _keyPair;
        private Uri _apiUri;

        public SandboxClientBuilder()
        {
        }

        public SandboxClientBuilder WithApiUri(Uri apiUri)
        {
            _apiUri = apiUri;

            return this;
        }

        public SandboxClientBuilder ForApplication(string appId)
        {
            _appId = appId;
            return this;
        }

        public SandboxClientBuilder WithKeyPair(AsymmetricCipherKeyPair keypair)
        {
            _keyPair = keypair;
            return this;
        }

        public SandboxClient Build()
        {
            Validation.NotNull(_appId, nameof(_appId));
            Validation.NotNull(_keyPair, nameof(_keyPair));
            Validation.NotNull(_apiUri, nameof(_apiUri));

            return new SandboxClient(new HttpClient(), _apiUri, _appId, _keyPair);
        }
    }
}
using System;
using System.Collections.Generic;
using Yoti.Auth.Share.ThirdParty;

namespace Yoti.Auth.Sandbox.Profile.Request.ExtraData.ThirdParty
{
    public class SandboxAttributeIssuanceDetailsBuilder
    {
        private readonly List<AttributeDefinition> _definitions = new List<AttributeDefinition>();
        private string _issuanceToken;
        private DateTime? _expiryDate;

        public SandboxAttributeIssuanceDetailsBuilder WithIssuanceToken(string issuanceToken)
        {
            Validation.NotNullOrEmpty(issuanceToken, nameof(issuanceToken));

            _issuanceToken = issuanceToken;
            return this;
        }

        public SandboxAttributeIssuanceDetailsBuilder WithExpiryDate(DateTime expiryDate)
        {
            _expiryDate = expiryDate;
            return this;
        }

        public SandboxAttributeIssuanceDetailsBuilder WithDefinition(string attributeName)
        {
            Validation.NotNullOrEmpty(attributeName, nameof(attributeName));

            _definitions.Add(new AttributeDefinition(attributeName));
            return this;
        }

        public SandboxAttributeIssuanceDetails Build()
        {
            var value = new SandboxAttributeIssuanceDetailsValue(
                _issuanceToken,
                new SandboxIssuingAttributes(_expiryDate, _definitions));

            return new SandboxAttributeIssuanceDetails(value);
        }
    }
}
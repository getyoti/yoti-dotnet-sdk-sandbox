using System;
using System.Collections.Generic;
using System.Globalization;

namespace Yoti.Auth.Sandbox.Profile.Request.ExtraData.ThirdParty
{
    public class SandboxAttributeIssuanceDetailsBuilder
    {
        private readonly List<SandboxDefinition> _definitions = new List<SandboxDefinition>();
        private string _issuanceToken;
        private string _expiryDate;

        public SandboxAttributeIssuanceDetailsBuilder WithIssuanceToken(string issuanceToken)
        {
            Validation.NotNullOrEmpty(issuanceToken, nameof(issuanceToken));

            _issuanceToken = issuanceToken;
            return this;
        }

        public SandboxAttributeIssuanceDetailsBuilder WithExpiryDate(DateTime expiryDate)
        {
            _expiryDate = expiryDate.ToString(Yoti.Auth.Constants.Format.RFC3339PatternMilli, DateTimeFormatInfo.InvariantInfo);
            return this;
        }

        public SandboxAttributeIssuanceDetailsBuilder WithDefinition(string attributeName)
        {
            Validation.NotNullOrEmpty(attributeName, nameof(attributeName));

            _definitions.Add(new SandboxDefinition(attributeName));
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
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Yoti.Auth.Share.ThirdParty;

namespace Yoti.Auth.Sandbox.Profile.Request.ExtraData.ThirdParty
{
    public class SandboxIssuingAttributes
    {
        [JsonProperty(PropertyName = "expiry_date")]
        public DateTime? ExpiryDate { get; private set; }

        [JsonProperty(PropertyName = "definitions")]
        public List<AttributeDefinition> Definitions { get; private set; }

        public SandboxIssuingAttributes(DateTime? expiryDate, List<AttributeDefinition> definitions)
        {
            Validation.CollectionNotEmpty(definitions, nameof(definitions));

            ExpiryDate = expiryDate;
            Definitions = definitions;
        }
    }
}
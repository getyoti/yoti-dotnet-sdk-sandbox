using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.Profile.Request.ExtraData.ThirdParty
{
    public class SandboxIssuingAttributes
    {
        [JsonProperty(PropertyName = "expiry_date")]
        public DateTime? ExpiryDate { get; private set; }

        [JsonProperty(PropertyName = "definitions")]
        public List<SandboxDefinition> Definitions { get; private set; }

        public SandboxIssuingAttributes(DateTime? expiryDate, List<SandboxDefinition> definitions)
        {
            Validation.CollectionNotEmpty(definitions, nameof(definitions));

            ExpiryDate = expiryDate;
            Definitions = definitions;
        }
    }
}
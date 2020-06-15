using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yoti.Auth.Sandbox.Profile.Request.ExtraData
{
    public class SandboxExtraData
    {
        [JsonProperty(PropertyName = "data_entry")]
        public List<SandboxBaseDataEntry> DataEntries { get; private set; }

        public SandboxExtraData(List<SandboxBaseDataEntry> dataEntries)
        {
            DataEntries = dataEntries;
        }
    }
}
using System.Collections.Generic;

namespace Yoti.Auth.Sandbox.Profile.Request.ExtraData
{
    public class SandboxExtraDataBuilder
    {
        private readonly List<SandboxBaseDataEntry> _dataEntries = new List<SandboxBaseDataEntry>();

        public SandboxExtraDataBuilder WithDataEntry(SandboxBaseDataEntry dataEntry)
        {
            _dataEntries.Add(dataEntry);

            return this;
        }

        public SandboxExtraData Build()
        {
            Validation.CollectionNotEmpty(_dataEntries, nameof(_dataEntries));

            return new SandboxExtraData(_dataEntries);
        }
    }
}
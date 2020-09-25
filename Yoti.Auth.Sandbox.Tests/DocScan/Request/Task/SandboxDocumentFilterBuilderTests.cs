using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Yoti.Auth.Sandbox.DocScan.Request.Check;
using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.Tests.DocScan.Request.Task
{
    public class SandboxDocumentFilterBuilderTests
    {
        private readonly List<string> _someCountryCodes = new List<string> { "CR1", "CR2" };
        private readonly List<string> _someDocumentTypes = new List<string> { "DOCUMENT_TYPE_1", "DOCUMENT_TYPE_2" };

        [Fact]
        public void ShouldBuildSandboxDocumentFilter()
        {
            var filter = new SandboxDocumentFilterBuilder()
                .WithCountryCodes(_someCountryCodes)
                .WithDocumentTypes(_someDocumentTypes)
                .Build();

            Assert.Equal(_someCountryCodes, filter.CountryCodes);
            Assert.Equal(_someDocumentTypes, filter.DocumentTypes);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Yoti.Auth.Sandbox.DocScan.Request.Task;

namespace Yoti.Auth.Sandbox.Tests.DocScan.Request.Task
{
    public class SandboxDocumentFilterBuilderTests
    {
        private readonly string _country1 = "CR1";
        private readonly string _country2 = "CR2";
        private readonly string _documentType1 = "DOCUMENT_TYPE_1";
        private readonly string _documentType2 = "DOCUMENT_TYPE_2";

        [Fact]
        public void ShouldBuildSandboxDocumentFilterWithCountryCode()
        {
            var filter = new SandboxDocumentFilterBuilder()
                .WithCountryCode(_country1)
                .Build();

            Assert.Equal(_country1, filter.CountryCodes.Single());
        }

        [Fact]
        public void ShouldBuildSandboxDocumentFilteMultipleWithCountryCodes()
        {
            var filter = new SandboxDocumentFilterBuilder()
                .WithCountryCode(_country1)
                .WithCountryCode(_country2)
                .Build();

            Assert.Equal(new List<string> { _country1, _country2 }, filter.CountryCodes);
        }

        [Fact]
        public void ShouldBuildSandboxDocumentFilterWithCountryCodes()
        {
            var countryCodes = new List<string> { _country1, _country2 };

            var filter = new SandboxDocumentFilterBuilder()
                .WithCountryCodes(countryCodes)
                .Build();

            Assert.Equal(countryCodes, filter.CountryCodes);
        }

        [Fact]
        public void ShouldBuildSandboxDocumentFilterWithDocumentType()
        {
            var filter = new SandboxDocumentFilterBuilder()
                .WithDocumentType(_country1)
                .Build();

            Assert.Equal(_country1, filter.DocumentTypes.Single());
        }

        [Fact]
        public void ShouldBuildSandboxDocumentFilterMultipleWithDocumentTypes()
        {
            var filter = new SandboxDocumentFilterBuilder()
                .WithDocumentType(_documentType1)
                .WithDocumentType(_documentType2)
                .Build();

            Assert.Equal(new List<string> { _documentType1, _documentType2 }, filter.DocumentTypes);
        }

        [Fact]
        public void ShouldBuildSandboxDocumentFilterWithDocumentTypes()
        {
            var documentTypes = new List<string> { _documentType1, _documentType2 };

            var filter = new SandboxDocumentFilterBuilder()
                .WithDocumentTypes(documentTypes)
                .Build();

            Assert.Equal(documentTypes, filter.DocumentTypes);
        }
    }
}
using Xunit;
using Yoti.Auth.Sandbox.Profile.Request.Attribute;

namespace Yoti.Auth.Sandbox.Tests.Profile.Request.Attribute
{
    public static class SandboxAttributeTests
    {
        private const string _someName = "someName";
        private const string _someDerivation = "someDerivation";
        private const string _someValue = "someValue";

        [Fact]
        public static void ShouldNotBeOptionalByDefault()
        {
            SandboxAttribute result = SandboxAttribute.Builder()
                    .WithName(_someName)
                    .WithDerivation(_someDerivation)
                    .WithValue(_someValue)
                    .Build();

            Assert.Equal(_someName, result.Name);
            Assert.Equal(_someDerivation, result.Derivation);
            Assert.Equal(_someValue, result.Value);
#pragma warning disable 0618
            Assert.Equal("False", result.Optional); //NOSONAR
#pragma warning restore 0618
        }

        [Fact]
        public static void ShouldBeOptionalWhenSpecified()
        {
#pragma warning disable 0618
            SandboxAttribute result = SandboxAttribute.Builder()
                    .WithName(_someName)
                    .WithDerivation(_someDerivation)
                    .WithValue(_someValue)
                    .WithOptional(true) //NOSONAR
#pragma warning restore 0618

                    .Build();

            Assert.Equal(_someName, result.Name);
            Assert.Equal(_someDerivation, result.Derivation);
            Assert.Equal(_someValue, result.Value);
#pragma warning disable 0618
            Assert.Equal("True", result.Optional); //NOSONAR
#pragma warning restore 0618
        }
    }
}
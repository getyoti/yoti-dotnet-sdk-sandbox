using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yoti.Auth.Sandbox.Profile;
using Yoti.Auth.Sandbox.Profile.Request;
using Yoti.Auth.Sandbox.Profile.Request.Attribute.Derivation;

namespace Yoti.Auth.Sandbox.Examples
{
    [TestClass]
    public class ProfileSandboxExample
    {
        public void TestProfile()
        {
            Org.BouncyCastle.Crypto.AsymmetricCipherKeyPair sandboxKeyPair;

            using (StreamReader stream = File.OpenText("path/to/hub-private-key.pem"))
            {
                sandboxKeyPair = Yoti.Auth.CryptoEngine.LoadRsaKey(stream);
            }

            const string sandboxClientSdkid = "your SDK ID";

            SandboxClient sandboxClient = new SandboxClientBuilder()
                .WithClientSdkId(sandboxClientSdkid)
                .WithKeyPair(sandboxKeyPair)
                .Build();

            SandboxAgeVerification ageVerification = new SandboxAgeVerificationBuilder()
                .WithDateOfBirth(new DateTime(2001, 12, 31))
                .WithAgeOver(18)
                .Build();

            YotiTokenRequest tokenRequest = new YotiTokenRequestBuilder()
                .WithRememberMeId("some Remember Me ID")
                .WithGivenNames("some given names")
                .WithFamilyName("some family name")
                .WithFullName("some full name")
                .WithDateOfBirth(new DateTime(1980, 10, 30))
                .WithAgeVerification(ageVerification)
                .WithGender("some gender")
                .WithPhoneNumber("some phone number")
                .WithNationality("some nationality")
                .WithStructuredPostalAddress(Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    building_number = 1,
                    address_line1 = "some address"
                }))
                .WithBase64Selfie(Convert.ToBase64String(Encoding.UTF8.GetBytes("some base64 encoded selfie")))
                .WithEmailAddress("some@email")
                .WithDocumentDetails("PASSPORT USA 1234abc")
                .Build();

            var sandboxOneTimeUseToken = sandboxClient.SetupSharingProfile(tokenRequest);

            var yotiClient = new YotiClient(new HttpClient(), sandboxClientSdkid, sandboxKeyPair);

            Uri sandboxUri = new UriBuilder(
                "https",
                "api.yoti.com",
                443,
                "sandbox/v1").Uri;

            yotiClient.OverrideApiUri(sandboxUri);

            ActivityDetails activityDetails = yotiClient.GetActivityDetails(sandboxOneTimeUseToken);

            // Perform tests
            Assert.AreEqual("some@email", activityDetails.Profile.EmailAddress.GetValue());
        }
    }
}
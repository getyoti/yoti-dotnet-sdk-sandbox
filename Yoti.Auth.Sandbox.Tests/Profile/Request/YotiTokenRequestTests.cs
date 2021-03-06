﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using Xunit;
using Yoti.Auth.Document;
using Yoti.Auth.Sandbox.Profile.Request;
using Yoti.Auth.Sandbox.Profile.Request.Attribute;
using Yoti.Auth.Sandbox.Profile.Request.Attribute.Derivation;
using Yoti.Auth.Sandbox.Profile.Request.ExtraData;
using Yoti.Auth.Sandbox.Profile.Request.ExtraData.ThirdParty;

namespace Yoti.Auth.Sandbox.Tests.Profile.Request
{
    public static class YotiTokenRequestTests
    {
        private const string _someRememberMeId = "someRememberMeId";
        private const string _someAttributeName = "someAttributeName";
        private const string _someFamilyName = "someFamilyName";
        private const string _someGivenNames = "given names";
        private const string _someFullName = "fullName";
        private const string _someDoB = "1902-02-02";
        private const string _someGender = "someGender";
        private const string _dobUnder18 = "2009-02-02";
        private const string _dobOver18 = "1978-02-02";
        private const string _somePostalAddress = "somePostalAddress";
        private const string _someNationality = "someNationality";
        private const string _somePhoneNumber = "somePhoneNumber";
        private const string _someEmailAddress = "someEmailAddress";
        private const string _someBase64Selfie = "someBase64Selfie";
        private const string _someDocumentDetails = "someDocumentDetails";

        private static readonly byte[] _someImageContent = Encoding.UTF8.GetBytes("image");
        private static readonly string base64Content = Convert.ToBase64String(_someImageContent);
        private const string _mimeTypeJpeg = "image/jpeg";
        private const string _mimeTypePng = "image/png";
        private static readonly string expectedJpegBase64DataUrl = $"data:{_mimeTypeJpeg};base64,{base64Content}";
        private static readonly string expectedPngBase64DataUrl = $"data:{_mimeTypePng};base64,{base64Content}";
        private static readonly string _expectedDocumentImagesAttributeValue = $"{expectedJpegBase64DataUrl}&{expectedPngBase64DataUrl}";

        private static readonly List<SandboxAnchor> anchors = new List<SandboxAnchor> { SandboxAnchor.Builder().Build() };

        private static readonly SandboxAttribute SOME_ATTRIBUTE = SandboxAttribute.Builder()
               .WithName(_someAttributeName)
               .Build();

        [Fact]
        public static void ShouldCreateRequestWithRememberMeId()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithRememberMeId(_someRememberMeId)
                    .Build();

            Assert.Equal(_someRememberMeId, yotiTokenRequest.RememberMeId);
        }

        [Fact]
        public static void ShouldAddAttributes()
        {
            SandboxAttribute otherAttribute = SandboxAttribute.Builder()
                    .WithName("otherAttributeName")
                    .Build();

            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithAttribute(SOME_ATTRIBUTE)
                    .WithAttribute(otherAttribute)
                    .Build();

            Assert.True(yotiTokenRequest.SandboxAttributes.Count == 2);
            Assert.Contains(SOME_ATTRIBUTE, yotiTokenRequest.SandboxAttributes);
            Assert.Contains(otherAttribute, yotiTokenRequest.SandboxAttributes);
        }

        [Fact]
        public static void ShouldAddAnAttributeOnlyOnce()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithAttribute(SOME_ATTRIBUTE)
                    .WithAttribute(SOME_ATTRIBUTE)
                    .Build();

            Assert.True(yotiTokenRequest.SandboxAttributes.Count == 1);
            Assert.Contains(SOME_ATTRIBUTE, yotiTokenRequest.SandboxAttributes);
        }

        [Fact]
        public static void ShouldAllowSameAttributeWithDifferingDerivationNames()
        {
            SandboxAttribute derivationAttribute = SandboxAttribute.Builder()
                    .WithName(_someAttributeName)
                    .WithDerivation("derivation1")
                    .Build();

            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithAttribute(SOME_ATTRIBUTE)
                    .WithAttribute(derivationAttribute)
                    .Build();

            Assert.True(yotiTokenRequest.SandboxAttributes.Count == 2);
            Assert.Contains(SOME_ATTRIBUTE, yotiTokenRequest.SandboxAttributes);
            Assert.Contains(derivationAttribute, yotiTokenRequest.SandboxAttributes);
        }

        [Fact]
        public static void ShouldCreateRequestWithFamilyName()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithFamilyName(_someFamilyName)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(
                result,
                name: Yoti.Auth.Constants.UserProfile.FamilyNameAttribute,
                value: _someFamilyName);
        }

        [Fact]
        public static void ShouldCreateRequestWithFamilyNameAndAnchors()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithFamilyName(_someFamilyName, anchors)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(
                result,
                Yoti.Auth.Constants.UserProfile.FamilyNameAttribute,
                _someFamilyName,
                anchors);
        }

        [Fact]
        public static void ShouldCreateRequestWithGivenNames()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithGivenNames(_someGivenNames)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.GivenNamesAttribute, _someGivenNames);
        }

        [Fact]
        public static void ShouldCreateRequestWithGivenNamesAndAnchors()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithGivenNames(_someGivenNames, anchors)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.GivenNamesAttribute, _someGivenNames, anchors);
        }

        [Fact]
        public static void ShouldCreateRequestWithFullName()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithFullName(_someFullName)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.FullNameAttribute, _someFullName);
        }

        [Fact]
        public static void ShouldCreateRequestWithFullNameAndAnchors()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithFullName(_someFullName, anchors)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.FullNameAttribute, _someFullName, anchors);
        }

        [Fact]
        public static void ShouldCreateRequestWithGender()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithGender(_someGender)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.GenderAttribute, _someGender);
        }

        [Fact]
        public static void ShouldCreateRequestWithGenderAndAnchors()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithGender(_someGender, anchors)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.GenderAttribute, _someGender, anchors);
        }

        [Fact]
        public static void ShouldCreateRequestWithDateOfBirthFromString()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithDateOfBirth(_someDoB)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.DateOfBirthAttribute, _someDoB);
        }

        [Fact]
        public static void ShouldCreateRequestWithDateOfBirthFromStringAndAnchors()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithDateOfBirth(_someDoB, anchors)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.DateOfBirthAttribute, _someDoB, anchors);
        }

        [Fact]
        public static void ShouldCreateRequestWithDateOfBirthFromDate()

        {
            DateTime.TryParseExact(
                   s: _someDoB,
                   format: "yyyy-MM-dd",
                   provider: CultureInfo.InvariantCulture,
                   style: DateTimeStyles.None,
                   result: out DateTime parsedDate);

            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                .WithDateOfBirth(parsedDate)
                .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.DateOfBirthAttribute, _someDoB);
        }

        [Fact]
        public static void ShouldCreateRequestWithDateOfBirthFromDateAndAnchors()

        {
            DateTime.TryParseExact(
                   s: _someDoB,
                   format: "yyyy-MM-dd",
                   provider: CultureInfo.InvariantCulture,
                   style: DateTimeStyles.None,
                   result: out DateTime parsedDate);

            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                .WithDateOfBirth(parsedDate, anchors)
                .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.DateOfBirthAttribute, _someDoB, anchors);
        }

        [Fact]
        public static void ShouldCreateRequestWithAgeUnderVerification()
        {
            SandboxAgeVerification sandboxAgeVerification = SandboxAgeVerification.Builder()
                    .WithDateOfBirth(_dobUnder18)
                    .WithAgeUnder(18)
                    .Build();
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithAgeVerification(sandboxAgeVerification)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsDerivedAttribute(
                result,
                Yoti.Auth.Constants.UserProfile.DateOfBirthAttribute,
                _dobUnder18,
                "age_under:18");
        }

        [Fact]
        public static void ShouldCreateRequestWithAgeOverVerification()
        {
            SandboxAgeVerification sandboxAgeVerification = SandboxAgeVerification.Builder()
                    .WithDateOfBirth(_dobOver18)
                    .WithAgeOver(18)
                    .Build();
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithAgeVerification(sandboxAgeVerification)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsDerivedAttribute(
                result,
                Yoti.Auth.Constants.UserProfile.DateOfBirthAttribute,
                _dobOver18,
                "age_over:18");
        }

        [Fact]
        public static void ShouldCreateRequestWithMultipleAgeVerifications()
        {
            SandboxAgeVerification ageOver = SandboxAgeVerification.Builder()
                    .WithDateOfBirth(_dobOver18)
                    .WithAgeOver(18)
                    .Build();
            SandboxAgeVerification ageUnder = SandboxAgeVerification.Builder()
                    .WithDateOfBirth(_dobOver18)
                    .WithAgeUnder(18)
                    .Build();
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithAgeVerification(ageOver)
                    .WithAgeVerification(ageUnder)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 2);
            AttributeMatcher.AssertContainsDerivedAttribute(
                result,
                Yoti.Auth.Constants.UserProfile.DateOfBirthAttribute,
                _dobOver18,
                "age_over:18");
            AttributeMatcher.AssertContainsDerivedAttribute(
                result,
                Yoti.Auth.Constants.UserProfile.DateOfBirthAttribute,
                _dobOver18,
                "age_under:18");
        }

        [Fact]
        public static void ShouldCreateRequestWithPostalAddress()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithPostalAddress(_somePostalAddress)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.PostalAddressAttribute, _somePostalAddress);
        }

        [Fact]
        public static void ShouldCreateRequestWithPostalAddressAndAnchors()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithPostalAddress(_somePostalAddress, anchors)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.PostalAddressAttribute, _somePostalAddress, anchors);
        }

        [Fact]
        public static void ShouldCreateRequestWithStructuredAddress()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithStructuredPostalAddress(_somePostalAddress)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.StructuredPostalAddressAttribute, _somePostalAddress);
        }

        [Fact]
        public static void ShouldCreateRequestWithStructuredAddressAndAnchors()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithStructuredPostalAddress(_somePostalAddress, anchors)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.StructuredPostalAddressAttribute, _somePostalAddress, anchors);
        }

        [Fact]
        public static void ShouldCreateRequestWithNationality()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithNationality(_someNationality)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.NationalityAttribute, _someNationality);
        }

        [Fact]
        public static void ShouldCreateRequestWithNationalityAndAnchors()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithNationality(_someNationality, anchors)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.NationalityAttribute, _someNationality, anchors);
        }

        [Fact]
        public static void ShouldCreateRequestWithPhoneNumber()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithPhoneNumber(_somePhoneNumber)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.PhoneNumberAttribute, _somePhoneNumber);
        }

        [Fact]
        public static void ShouldCreateRequestWithPhoneNumberAndAnchors()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithPhoneNumber(_somePhoneNumber, anchors)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.PhoneNumberAttribute, _somePhoneNumber, anchors);
        }

        [Fact]
        public static void ShouldCreateRequestWithEmailAddress()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithEmailAddress(_someEmailAddress)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.EmailAddressAttribute, _someEmailAddress);
        }

        [Fact]
        public static void ShouldCreateRequestWithEmailAddressAndAnchors()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithEmailAddress(_someEmailAddress, anchors)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.EmailAddressAttribute, _someEmailAddress, anchors);
        }

        [Fact]
        public static void ShouldCreateRequestWithDocumentDetails()
        {
            DocumentDetails documentDetails = new DocumentDetailsBuilder()
                    .WithType("type")
                    .WithIssuingCountry("country")
                    .WithNumber("number")
                    .Build();
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithDocumentDetails(documentDetails)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.DocumentDetailsAttribute, "type country number");
        }

        [Fact]
        public static void ShouldCreateRequestWithDocumentDetailsAndAnchors()
        {
            DocumentDetails documentDetails = new DocumentDetailsBuilder()
                    .WithType("type")
                    .WithIssuingCountry("country")
                    .WithNumber("number")
                    .Build();
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithDocumentDetails(documentDetails, anchors)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(
                result,
                Yoti.Auth.Constants.UserProfile.DocumentDetailsAttribute,
                "type country number",
                anchors);
        }

        [Fact]
        public static void ShouldCreateRequestWithDocumentDetailsString()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithDocumentDetails(_someDocumentDetails)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.DocumentDetailsAttribute, _someDocumentDetails);
        }

        [Fact]
        public static void ShouldCreateRequestWithDocumentDetailsStringAndAnchors()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithDocumentDetails(_someDocumentDetails, anchors)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.DocumentDetailsAttribute, _someDocumentDetails, anchors);
        }

        [Fact]
        public static void ShouldCreateRequestWithDocumentImages()
        {
            SandboxDocumentImages documentImages = new SandboxDocumentImagesBuilder()
                    .WithJpegContent(_someImageContent)
                    .WithPngContent(_someImageContent)
                    .Build();

            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithDocumentImages(documentImages)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(
                result,
                Yoti.Auth.Constants.UserProfile.DocumentImagesAttribute,
                _expectedDocumentImagesAttributeValue);
        }

        [Fact]
        public static void ShouldCreateRequestWithDocumentImagesAndAnchors()
        {
            SandboxDocumentImages documentImages = new SandboxDocumentImagesBuilder()
                      .WithJpegContent(_someImageContent)
                      .WithPngContent(_someImageContent)
                      .Build();

            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithDocumentImages(documentImages, anchors)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(
                result,
                Yoti.Auth.Constants.UserProfile.DocumentImagesAttribute,
                _expectedDocumentImagesAttributeValue,
                anchors);
        }

        [Fact]
        public static void ShouldCreateRequestWithSelfieBytes()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithSelfie(Encoding.UTF8.GetBytes(_someBase64Selfie))
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(
                result,
                Yoti.Auth.Constants.UserProfile.SelfieAttribute,
                Conversion.BytesToBase64(
                    Encoding.UTF8.GetBytes(_someBase64Selfie)));
        }

        [Fact]
        public static void ShouldCreateRequestWithSelfieBytesAndAnchors()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithSelfie(Encoding.UTF8.GetBytes(_someBase64Selfie), anchors)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(
                result,
                Yoti.Auth.Constants.UserProfile.SelfieAttribute,
                Conversion.BytesToBase64(
                    Encoding.UTF8.GetBytes(_someBase64Selfie)),
                anchors);
        }

        [Fact]
        public static void ShouldCreateRequestWithBase64Selfie()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithBase64Selfie(_someBase64Selfie)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.SelfieAttribute, _someBase64Selfie);
        }

        [Fact]
        public static void ShouldCreateRequestWithBase64SelfieAndAnchors()
        {
            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithBase64Selfie(_someBase64Selfie, anchors)
                    .Build();

            ReadOnlyCollection<SandboxAttribute> result = yotiTokenRequest.SandboxAttributes;

            Assert.True(result.Count == 1);
            AttributeMatcher.AssertContainsAttribute(result, Yoti.Auth.Constants.UserProfile.SelfieAttribute, _someBase64Selfie, anchors);
        }

        [Fact]
        public static void ShouldCreateRequestWithExtraData()
        {
            SandboxAttributeIssuanceDetails sandboxAttributeIssuanceDetails =
                new SandboxAttributeIssuanceDetailsBuilder()
                .WithDefinition("attributeName")
                .WithExpiryDate(new DateTime(2030, 12, 31, 12, 23, 59, 999))
                .WithIssuanceToken("issuanceToken")
                .Build();

            var extraData = new SandboxExtraData(
                new List<SandboxBaseDataEntry> { sandboxAttributeIssuanceDetails });

            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithExtraData(extraData)
                    .Build();

            var baseResult = yotiTokenRequest.ExtraData.DataEntries.Single();
            var result = baseResult as SandboxDataEntry<SandboxAttributeIssuanceDetailsValue>;

            Assert.Equal("THIRD_PARTY_ATTRIBUTE", result.Type);
            Assert.Equal("attributeName", result.Value.IssuingAttributes.Definitions.Single().Name);
            Assert.Equal("2030-12-31T12:23:59.999Z", result.Value.IssuingAttributes.ExpiryDate);
            Assert.Equal("issuanceToken", result.Value.IssuanceToken);
        }

        [Fact]
        public static void ShouldHaveNullExpiryDateIfNotSpecified()
        {
            SandboxAttributeIssuanceDetails sandboxAttributeIssuanceDetails =
                new SandboxAttributeIssuanceDetailsBuilder()
                .WithDefinition("attributeName")
                .WithIssuanceToken("issuanceToken")
                .Build();

            var extraData = new SandboxExtraData(
                new List<SandboxBaseDataEntry> { sandboxAttributeIssuanceDetails });

            YotiTokenRequest yotiTokenRequest = YotiTokenRequest.Builder()
                    .WithExtraData(extraData)
                    .Build();

            var baseResult = yotiTokenRequest.ExtraData.DataEntries.Single();
            var result = baseResult as SandboxDataEntry<SandboxAttributeIssuanceDetailsValue>;

            Assert.Null(result.Value.IssuingAttributes.ExpiryDate);
        }
    }
}
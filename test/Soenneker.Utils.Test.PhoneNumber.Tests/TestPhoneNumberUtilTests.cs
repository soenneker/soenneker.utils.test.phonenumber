using FluentAssertions;
using PhoneNumbers;
using Soenneker.Tests.FixturedUnit;
using System;
using Xunit;

namespace Soenneker.Utils.Test.PhoneNumber.Tests;

[Collection("Collection")]
public class TestPhoneNumberUtilTests : FixturedUnitTest
{
    public TestPhoneNumberUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }

    [Fact]
    public void Should_return_valid_phone_number_for_US()
    {
        // Act
        string phoneNumber = TestPhoneNumberUtil.GetRandomValidPhoneNumber("US");

        // Assert
        var phoneUtil = PhoneNumberUtil.GetInstance();
        var parsed = phoneUtil.Parse(phoneNumber, "US");

        phoneUtil.IsValidNumberForRegion(parsed, "US").Should().BeTrue();
        phoneNumber.Length.Should().Be(10);
        phoneNumber.Should().MatchRegex(@"^\d{10}$");
    }

    [Theory]
    [InlineData("US")]
    [InlineData("CA")]
    [InlineData("GB")]
    public void Should_return_valid_phone_number_for_region(string region)
    {
        // Act
        string phoneNumber = TestPhoneNumberUtil.GetRandomValidPhoneNumber(region);

        // Assert
        var phoneUtil = PhoneNumberUtil.GetInstance();
        var parsed = phoneUtil.Parse(phoneNumber, region);

        phoneUtil.IsValidNumberForRegion(parsed, region).Should().BeTrue();
        phoneNumber.Should().MatchRegex(@"^\d{10}$");
    }

    [Fact]
    public void Should_throw_if_invalid_region()
    {
        // Act
        Action act = () => TestPhoneNumberUtil.GetRandomValidPhoneNumber("INVALID_REGION");

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }
}

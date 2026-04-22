using AwesomeAssertions;
using PhoneNumbers;
using Soenneker.Tests.HostedUnit;
using System;

namespace Soenneker.Utils.Test.PhoneNumber.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class TestPhoneNumberUtilTests : HostedUnitTest
{
    public TestPhoneNumberUtilTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }

    [Test]
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

    [Test]
    public void Should_throw_if_invalid_region()
    {
        // Act
        Action act = () => TestPhoneNumberUtil.GetRandomValidPhoneNumber("INVALID_REGION");

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }
}

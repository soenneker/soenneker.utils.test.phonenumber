using Bogus;
using PhoneNumbers;
using System;

namespace Soenneker.Utils.Test.PhoneNumber;

/// <summary>
/// Utility class for generating valid test phone numbers.
/// </summary>
public static class TestPhoneNumberUtil
{
    private static readonly Faker _faker = new();
    private static readonly PhoneNumberUtil _phoneUtil = PhoneNumberUtil.GetInstance();

    /// <summary>
    /// Generates a random, valid 10-digit phone number for the specified region.
    /// </summary>
    /// <param name="defaultRegion">The region code to validate the phone number against (e.g., "US"). Defaults to "US".</param>
    /// <returns>A valid phone number string formatted as a 10-digit number.</returns>
    public static string GetRandomValidPhoneNumber(string defaultRegion = "US")
    {
        const int maxAttempts = 100;

        for (var i = 0; i < maxAttempts; i++)
        {
            string phoneNumber = _faker.Phone.PhoneNumber("##########");

            try
            {
                PhoneNumbers.PhoneNumber? parsedPhoneNumber = _phoneUtil.Parse(phoneNumber, defaultRegion);

                if (_phoneUtil.IsValidNumberForRegion(parsedPhoneNumber, defaultRegion))
                    return phoneNumber;
            }
            catch (NumberParseException)
            {
                // Continue to next attempt
            }
        }

        throw new InvalidOperationException($"Failed to generate a valid phone number after {maxAttempts} attempts.");
    }
}
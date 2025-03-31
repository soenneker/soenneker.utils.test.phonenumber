using PhoneNumbers;
using System;
using Soenneker.Utils.Random;

namespace Soenneker.Utils.Test.PhoneNumber;

/// <summary>
/// Utility class for generating valid test phone numbers.
/// </summary>
public static class TestPhoneNumberUtil
{
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
            string phoneNumber = GenerateRandom10DigitNumber();

            try
            {
                PhoneNumbers.PhoneNumber? parsedPhoneNumber = _phoneUtil.Parse(phoneNumber, defaultRegion);

                if (_phoneUtil.IsValidNumberForRegion(parsedPhoneNumber, defaultRegion))
                    return phoneNumber;
            }
            catch (NumberParseException)
            {
                // Ignore and try again
            }
        }

        throw new InvalidOperationException($"Failed to generate a valid phone number after {maxAttempts} attempts.");
    }

    private static string GenerateRandom10DigitNumber()
    {
        // Generate a 10-digit number (not starting with 0)
        int areaCode = RandomUtil.Next(100, 1000);  // 3 digits, can't start with 0
        int prefix = RandomUtil.Next(100, 1000);    // 3 digits
        int lineNumber = RandomUtil.Next(1000, 10000); // 4 digits

        return $"{areaCode}{prefix}{lineNumber}";
    }
}
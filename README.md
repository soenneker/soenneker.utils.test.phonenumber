[![](https://img.shields.io/nuget/v/soenneker.utils.test.phonenumber.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.test.phonenumber/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.test.phonenumber/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.test.phonenumber/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.utils.test.phonenumber.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.test.phonenumber/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.test.phonenumber/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.utils.test.phonenumber/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.Test.PhoneNumber
Generates random 10-digit test candidates that pass libphonenumber validation for a region.

## Installation

```bash
dotnet add package Soenneker.Utils.Test.PhoneNumber
```

## Usage

```csharp
using Soenneker.Utils.Test.PhoneNumber;

string phoneNumber = TestPhoneNumberUtil.GetRandomValidPhoneNumber("US");

// Example shape: "3125550187"
```

The region defaults to `"US"` when omitted. The returned value contains exactly ten digits with no country calling code or formatting characters.

## How generation succeeds or fails

The utility generates up to 100 ten-digit candidates, parses each one with libphonenumber using the requested default region, and returns the first candidate for which `IsValidNumberForRegion` is true. Parse failures are skipped. If no candidate succeeds—including for an invalid or incompatible region—it throws `InvalidOperationException`.

Because every candidate is ten digits, this helper is most reliable for regions whose national numbers can have that length, such as NANP regions. It is not a general international phone-number generator.

## Test-data safety

Libphonenumber validation checks numbering-plan metadata; it does not prove that a number is unassigned or reserved for examples. A generated value may belong to a real person or organization. Do not call it, text it, persist it as a trusted fixture, or use it in tests that contact external providers.

Generation uses the package's ordinary random utility and is not deterministic or cryptographically secure. Use explicit reserved example numbers when reproducibility or guaranteed non-delivery matters.

Call the static method directly; no dependency-injection registration is required.

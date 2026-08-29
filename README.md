[![](https://img.shields.io/nuget/v/soenneker.utils.test.phonenumber.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.test.phonenumber/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.test.phonenumber/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.test.phonenumber/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.utils.test.phonenumber.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.test.phonenumber/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.test.phonenumber/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.utils.test.phonenumber/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.Test.PhoneNumber
Generates a random valid 10-digit phone number.

## Installation

```bash
dotnet add package Soenneker.Utils.Test.PhoneNumber
```

## Quick start

```csharp
using Soenneker.Utils.Test.PhoneNumber;
```

Call the static `TestPhoneNumberUtil` methods directly; no dependency-injection registration is required.

## Common operations

- `GetRandomValidPhoneNumber()` - Generates a random, valid 10-digit phone number for the specified region. Returns a valid phone number string formatted as a 10-digit number.

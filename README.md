# QRCoder.Core - QR Code Generator Library

[![Build status](https://github.com/afonsoft/QRCoder.Core/actions/workflows/build-and-pack.yml/badge.svg?branch=main)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/build-and-pack.yml)
[![codecov](https://codecov.io/gh/afonsoft/QRCoder.Core/graph/badge.svg?token=N8RED1A0D7)](https://codecov.io/gh/afonsoft/QRCoder.Core)
[![NuGet Badge](https://buildstats.info/nuget/QRCoder.Core?rnd=0892982314)](https://www.nuget.org/packages/QRCoder.Core/)
[![Code Quality](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)

> **[Leia em Portugues (pt-BR)](README.pt-br.md)**

## Documentation

- **[Usage Guide (English)](docs/en-US/usage-guide.md)** — PNG, SVG, PDF, ASCII, Base64, Postscript, Artistic QR Codes
- **[Guia de Uso (Portugues)](docs/pt-BR/guia-de-uso.md)** — PNG, SVG, PDF, ASCII, Base64, Postscript, QR Codes Artisticos

## Project Description

QRCoder.Core is a cross-platform .NET library for QR Code generation using **SkiaSharp** for image rendering. Compatible with **Windows**, **Linux**, **macOS**, and **mobile** (Xamarin / MAUI).

Based on [QRCoder](https://github.com/codebude/QRCoder). Developed and maintained by [AFONSOFT](https://github.com/afonsoft).

### Supported Output Formats

| Format | Class | Description |
|--------|-------|-------------|
| **SKBitmap** | `QRCode` | SkiaSharp bitmap image (cross-platform) |
| **PNG** | `PngByteQRCode` | PNG byte array (no System.Drawing needed) |
| **SVG** | `SvgQRCode` | Scalable vector graphics string |
| **PDF** | `PdfByteQRCode` | PDF document as byte array |
| **ASCII** | `ASCIIQRCode` | ASCII art for terminal output |
| **Base64** | `Base64QRCode` | Base64-encoded image string |
| **Postscript** | `PostscriptQRCode` | Postscript/EPS format |
| **Artistic** | `ArtQRCode` | Custom QR with rounded dots and backgrounds |
| **BMP Bytes** | `BitmapByteQRCode` | Bitmap byte array |

### Supported Payload Types

The `PayloadGenerator` class provides formatted strings for common QR code use cases:

| Payload | Description |
|---------|-------------|
| `Url` | Website URL |
| `WiFi` | Wi-Fi network credentials |
| `Mail` | Email with subject and body |
| `SMS` | SMS message |
| `PhoneNumber` | Phone number |
| `MMS` | Multimedia message |
| `Geolocation` | GPS coordinates |
| `CalendarEvent` | Calendar event (iCal/vEvent) |
| `ContactData` | vCard / MeCard contact |
| `BitcoinLikeCryptoCurrencyAddress` | Bitcoin/crypto payment |
| `Girocode` | European SEPA payment |
| `BezahlCode` | German payment standard |
| `SwissQrCode` | Swiss QR-bill payment |
| `OneTimePassword` | TOTP/HOTP for 2FA |
| `ShadowSocksConfig` | ShadowSocks proxy config |
| `Bookmark` | Browser bookmark |
| `SkypeCall` | Skype call link |
| `WhatsAppMessage` | WhatsApp message |
| `RussiaPaymentOrder` | Russian payment order |
| `SlovenianUpnQr` | Slovenian UPN QR payment |

## Test Coverage

| Metric | Coverage | Status |
|--------|----------|--------|
| **Line Coverage** | 78%+ | Good |
| **Branch Coverage** | 83%+ | Excellent |
| **Method Coverage** | 78%+ | Good |
| **Total Tests** | 300+ | All Passed |

## Project Status

**Complete** - Actively maintained with modern CI/CD pipelines.

## Prerequisites

This library is compatible with multiple .NET versions:

- **.NET Standard 2.1** — Maximum compatibility
- **.NET 8.0** — LTS recommended
- **.NET 10.0** — Latest version
- **.NET Framework 4.8** — Legacy support

**Technologies Used:**
- **C#** — Primary programming language
- **SkiaSharp** — Cross-platform graphics library for rendering
- **SkiaSharp.Views** — SkiaSharp UI components
- **System.Text.Encoding.CodePages** — Additional code page support

## Installation

### NuGet Package Manager (recommended)

```bash
Install-Package QRCoder.Core
```

### .NET CLI

```bash
dotnet add package QRCoder.Core
```

### PackageReference

```xml
<PackageReference Include="QRCoder.Core" Version="2.0.0" />
```

## Quick Start

Generate your first QR code with just a few lines of code:

```csharp
using QRCoder.Core;
using SkiaSharp;

// Create the QR Code generator
using var generator = new QRCodeGenerator();
using var data = generator.CreateQrCode("https://github.com/afonsoft/QRCoder.Core",
    QRCodeGenerator.ECCLevel.M);

// Render as PNG bytes (cross-platform, no System.Drawing needed)
using var png = new PngByteQRCode(data);
byte[] pngBytes = png.GetGraphic(10);
File.WriteAllBytes("qrcode.png", pngBytes);

// Or render as SKBitmap
using var qrCode = new QRCode(data);
using var bitmap = qrCode.GetGraphic(10);
```

### More Output Formats

```csharp
// SVG output
using var svg = new SvgQRCode(data);
string svgString = svg.GetGraphic(10);

// ASCII output (great for terminal)
using var ascii = new ASCIIQRCode(data);
Console.WriteLine(ascii.GetGraphic(1));

// PDF output
using var pdf = new PdfByteQRCode(data);
byte[] pdfBytes = pdf.GetGraphic(5);

// Base64 PNG (embed in HTML)
using var b64 = new Base64QRCode(data);
string base64Img = b64.GetGraphic(10);
// Use in HTML: <img src="data:image/png;base64,{base64Img}" />

// With custom colors
using var colorQr = new QRCode(data);
using var colorBmp = colorQr.GetGraphic(10, "#1a1a2e", "#e0e0e0");

// Postscript / EPS
using var ps = new PostscriptQRCode(data);
string psString = ps.GetGraphic(5);
```

### Payload Examples

```csharp
using QRCoder.Core;

// Wi-Fi QR Code
var wifiPayload = new PayloadGenerator.WiFi("MyNetwork", "MyPassword",
    PayloadGenerator.WiFi.Authentication.WPA);
using var gen = new QRCodeGenerator();
using var wifiData = gen.CreateQrCode(wifiPayload.ToString(), QRCodeGenerator.ECCLevel.M);

// URL QR Code
var urlPayload = new PayloadGenerator.Url("https://github.com/afonsoft/QRCoder.Core");
using var urlData = gen.CreateQrCode(urlPayload.ToString(), QRCodeGenerator.ECCLevel.M);

// Email QR Code
var mailPayload = new PayloadGenerator.Mail("test@example.com", "Subject", "Body text");
using var mailData = gen.CreateQrCode(mailPayload.ToString(), QRCodeGenerator.ECCLevel.M);

// Phone Number
var phonePayload = new PayloadGenerator.PhoneNumber("+5511999999999");
using var phoneData = gen.CreateQrCode(phonePayload.ToString(), QRCodeGenerator.ECCLevel.M);

// Contact Card (vCard)
var contactPayload = new PayloadGenerator.ContactData(
    PayloadGenerator.ContactData.ContactOutputType.VCard3,
    "Doe", "John",
    phone: "+5511999999999",
    email: "john.doe@example.com");
using var contactData = gen.CreateQrCode(contactPayload.ToString(), QRCodeGenerator.ECCLevel.M);
```

See the full **[Usage Guide](docs/en-US/usage-guide.md)** for all output formats, payload types, advanced settings, and error correction levels.

## Error Correction Levels

| Level | Recovery | Use Case |
|-------|----------|----------|
| `ECCLevel.L` | ~7% | Maximum data capacity |
| `ECCLevel.M` | ~15% | General purpose (recommended) |
| `ECCLevel.Q` | ~25% | Higher reliability |
| `ECCLevel.H` | ~30% | Maximum error recovery (logos, artistic QR) |

## Repository Structure

```
.
├── QRCoder.Core/              # Core library source code
│   ├── QRCodeGenerator.cs     # Main QR code data generator
│   ├── QRCodeData.cs          # QR code data structure
│   ├── QRCode.cs              # SKBitmap renderer
│   ├── PngByteQRCode.cs       # PNG byte array renderer
│   ├── SvgQRCode.cs           # SVG string renderer
│   ├── PdfByteQRCode.cs       # PDF byte array renderer
│   ├── ASCIIQRCode.cs         # ASCII art renderer
│   ├── Base64QRCode.cs        # Base64 image renderer
│   ├── PostscriptQRCode.cs    # Postscript/EPS renderer
│   ├── ArtQRCode.cs           # Artistic QR code renderer
│   ├── BitmapByteQRCode.cs    # BMP byte array renderer
│   ├── AbstractQRCode.cs      # Base class for renderers
│   ├── PayloadGenerator.cs    # Payload formatters (WiFi, URL, etc.)
│   └── Assets/                # NuGet assets
├── QRCoder.Core.Tests/        # Unit tests (300+ tests)
├── docs/
│   ├── en-US/usage-guide.md   # English usage guide
│   └── pt-BR/guia-de-uso.md   # Portuguese usage guide
└── Docs/media/                # Documentation media assets
```

## CI/CD and Build

This project uses a complete CI/CD pipeline with GitHub Actions:

### Available Workflows

- **Build & Pack** — Main build with tests, coverage, and package creation
- **Code Quality** — Code analysis with Qodana and SonarCloud
- **Security Scans** — Security analysis with CodeQL, Snyk, and SonarCloud
- **Publish NuGet** — Automatic publishing to NuGet.org and GitHub Packages
- **CI Build & Test** — Continuous build and automated testing

### Running Tests Locally

```bash
# Build the project
dotnet build QRCoder.Core.sln --configuration Release

# Run all tests with coverage
dotnet test QRCoder.Core.Tests/QRCoder.Core.Tests.csproj \
  --configuration Release \
  --logger "trx;LogFileName=test-results.trx" \
  --results-directory TestResults \
  --collect:"XPlat Code Coverage"

# Generate HTML coverage report
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator \
  -reports:"TestResults/**/coverage.cobertura.xml" \
  -targetdir:"TestResults/CoverageReport" \
  -reporttypes:"Html;XmlSummary;TextSummary"

# View report: open TestResults/CoverageReport/index.html
```

## Contributing

1. **Create a branch** from `main`:
   ```bash
   git checkout -b feature/your-feature
   ```

2. **Make your changes** following code conventions

3. **Automated workflows** will run:
   - **Build & Pack** — Validates your code
   - **Code Quality** — Analyzes quality
   - **Security Scan** — Checks security

4. **Pull Request**: Create a PR to `main`

5. **Review and Merge**: After approval, your code will be merged

## Developers

- **Afonso Dutra Nogueira Filho** (AFONSOFT) — Lead developer

## License

This project is licensed under the MIT License. See the [LICENSE.txt](LICENSE.txt) file for details.

## Changelog

### [2.0.0] - Latest
#### Changed
- Multi-language documentation (en-US default + pt-BR)
- Updated NuGet package README with examples

### [1.0.6] - 2025-02-17
#### Added
- Comprehensive test coverage reporting (78% line, 83.1% branch, 78.1% method)
- 239 unit tests across all target frameworks
- Performance optimization packages
- Complete CI/CD pipeline with GitHub Actions
- Support for .NET 10.0 target framework
- Multiple security scans (CodeQL, Snyk, SonarCloud)

#### Changed
- Updated README with detailed test coverage information
- Updated target frameworks: .NET Standard 2.1, .NET 8.0, .NET 10.0, .NET Framework 4.8

#### Fixed
- GitHub Actions syntax issues
- Environment variable references

### [1.0.5] - 2025-02-17
#### Added
- Support for .NET 10.0 target framework
- Complete CI/CD pipeline
- Automated NuGet publishing workflow

### [1.0.4] - 2025-07-13
#### Changed
- General adjustments in the project and documentation
- SkiaSharp adjustments

### [1.0.3] - 2024-04-01
#### Fixed
- Action corrections
#### Changed
- Dependency updates (codecov/codecov-action, NuGet/setup-nuget)

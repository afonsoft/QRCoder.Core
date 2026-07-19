# QRCoder.Core - QR Code Generator Library

[![License](https://img.shields.io/github/license/afonsoft/QRCoder.Core)](https://github.com/afonsoft/QRCoder.Core/blob/main/LICENSE.txt)
[![Build](https://github.com/afonsoft/QRCoder.Core/actions/workflows/ci-build-test.yml/badge.svg?branch=main)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/ci-build-test.yml)
[![Code Quality](https://github.com/afonsoft/QRCoder.Core/actions/workflows/code-quality.yml/badge.svg?branch=main)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/code-quality.yml)
[![Security Scan](https://github.com/afonsoft/QRCoder.Core/actions/workflows/security-scan.yml/badge.svg?branch=main)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/security-scan.yml)
[![codecov](https://codecov.io/gh/afonsoft/QRCoder.Core/graph/badge.svg?token=N8RED1A0D7)](https://codecov.io/gh/afonsoft/QRCoder.Core)
[![NuGet](https://img.shields.io/nuget/v/QRCoder.Core.svg)](https://www.nuget.org/packages/QRCoder.Core/)
[![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=afonsoft_QRCoder.Core&metric=alert_status)](https://sonarcloud.io/project/overview?id=afonsoft_QRCoder.Core)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=afonsoft_QRCoder.Core&metric=security_rating)](https://sonarcloud.io/project/overview?id=afonsoft_QRCoder.Core)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=afonsoft_QRCoder.Core&metric=coverage)](https://sonarcloud.io/project/overview?id=afonsoft_QRCoder.Core)
[![GitHub issues](https://img.shields.io/github/issues/afonsoft/QRCoder.Core)](https://github.com/afonsoft/QRCoder.Core/issues)
![GitHub top language](https://img.shields.io/github/languages/top/afonsoft/QRCoder.Core)

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
| **ASCII** | `AsciiQRCode` | ASCII art for terminal output |
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
| **Line Coverage** | 96.9% | Excellent |
| **Branch Coverage** | 92.6% | Excellent |
| **Method Coverage** | 96.0% | Excellent |
| **Total Tests** | 502 | All Passed |

## Project Status

**Complete** - Actively maintained with modern CI/CD pipelines.

## Business Vision

QRCoder.Core provides a lightweight, cross-platform foundation for QR code generation that can be embedded in any .NET product — from mobile and web backends to desktop and CLI tooling. The goal is to remove platform-specific graphics dependencies while offering a predictable, extensible API for multiple output formats and industry-standard payloads.

## Technical Vision

The library is organized as a **Clean Architecture** pipeline:

- **Generation**: `QRCodeGenerator` builds an abstract `QRCodeData` matrix (models).
- **Payloads**: `PayloadGenerator` formats standard data strings (Wi-Fi, vCard, SEPA, etc.) without coupling to rendering.
- **Rendering**: `AbstractQRCode` implementations produce output formats (PNG, SVG, PDF, ASCII, Base64, Postscript, Art, BMP) using **SkiaSharp** for cross-platform bitmap rendering.
- **Dependency rule**: `Abstractions` and `Models` have no external dependencies; `Renderers` and `Generators` depend only on `Models` and `Abstractions`.
- **Quality gates**: build with zero warnings, xUnit tests with **~97% line coverage**, and static analysis via SonarCloud / Codecov / Snyk.

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
- **Microsoft.Extensions.ObjectPool** — Reusable buffer pooling
- **xUnit** — Unit testing framework
- **Shouldly** — Assertion library
- **coverlet** — Cross-platform code coverage
- **dotnet-reportgenerator-globaltool** — Coverage report generation
- **GitHub Actions** — CI/CD automation
- **SonarCloud** — Static analysis and quality gates
- **Codecov** — Coverage reporting
- **Snyk** — Security vulnerability scanning

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
<PackageReference Include="QRCoder.Core" Version="2.0.1" />
```

## Quick Start

Generate your first QR code with just a few lines of code:

```csharp
using System;
using System.IO;
using QRCoder.Core.Generators;
using QRCoder.Core.Models;
using QRCoder.Core.Renderers;
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
using System;
using System.IO;
using QRCoder.Core.Generators;
using QRCoder.Core.Models;
using QRCoder.Core.Renderers;
using SkiaSharp;

// SVG output
using var svg = new SvgQRCode(data);
string svgString = svg.GetGraphic(10);

// ASCII output (great for terminal)
using var ascii = new AsciiQRCode(data);
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
using System;
using System.IO;
using QRCoder.Core.Generators;
using QRCoder.Core.Models;
using QRCoder.Core.Renderers;
using SkiaSharp;

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
│   ├── Abstractions/          # Abstract base class and contracts
│   │   └── AbstractQRCode.cs  # Base class for all renderers
│   ├── Models/                # QR code data model and value objects
│   │   ├── QRCodeData.cs      # QR code data structure
│   │   └── Size.cs            # Rendering size value object
│   ├── Generators/            # QR code generation engine
│   │   ├── QRCodeGenerator.cs # Main QR code data generator
│   │   └── PayloadGenerator.cs# Payload formatters (WiFi, URL, etc.)
│   ├── Renderers/             # Output format renderers
│   │   ├── QRCode.cs          # SKBitmap renderer
│   │   ├── PngByteQRCode.cs   # PNG byte array renderer
│   │   ├── SvgQRCode.cs       # SVG string renderer
│   │   ├── PdfByteQRCode.cs   # PDF byte array renderer
│   │   ├── AsciiQRCode.cs     # ASCII art renderer
│   │   ├── Base64QRCode.cs    # Base64 image renderer
│   │   ├── PostscriptQRCode.cs# Postscript/EPS renderer
│   │   ├── ArtQRCode.cs       # Artistic QR code renderer
│   │   └── BitmapByteQRCode.cs# BMP byte array renderer
│   ├── Extensions/            # SkiaSharp and helper extensions
│   ├── Exceptions/            # Custom exceptions
│   └── Assets/                # NuGet assets
├── QRCoder.Core.Tests/        # Unit tests (502 tests)
├── QRCoder.Core.Benchmarks/   # Performance benchmarks
├── docs/                      # Usage guides
│   ├── en-US/usage-guide.md   # English usage guide
│   └── pt-BR/guia-de-uso.md   # Portuguese usage guide
├── .github/workflows/         # CI/CD pipelines
├── CHANGELOG.md               # Version history
└── README.md / README.pt-br.md# English and Portuguese documentation
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

## Star History

[![Star History Chart](https://api.star-history.com/svg?repos=afonsoft/qrcoder.core&type=Date)](https://star-history.com/#afonsoft/qrcoder.core&Date)

## StarMapper

[![StarMapper Map](https://starmapper.bruniaux.com/afonsoft/QRCoder.Core/opengraph-image)](https://starmapper.bruniaux.com/afonsoft/QRCoder.Core)

## License

This project is licensed under the MIT License. See the [LICENSE.txt](LICENSE.txt) file for details.

## Changelog

See the full [CHANGELOG.md](CHANGELOG.md) for the complete version history.

### [2.0.1] - 2026-07-11
#### Added
- XML documentation for all public APIs (CS1591 removed from NoWarn).
- Repository structure, business vision, and technical vision sections in README.
- `BDDTests.cs` with BDD-style `Given/When/Then` tests for QR code generation and rendering.

#### Changed
- Bumped package version to `2.0.1`.
- Updated CI, NuGet, SonarCloud, and Codecov badges in README files.
- Updated SonarCloud links to the correct project (`afonsoft_QRCoder.Core`).
- Consolidated CHANGELOG.md following Keep a Changelog and SemVer.

#### Fixed
- Broken NuGet badge (now using shields.io).
- Broken CI build badge (now using `ci-build-test.yml`).
- SonarQube S2184 (integer division in `PdfByteQRCode` media size).
- SonarQube S4136 by grouping `GetGraphic` overloads in `QRCode` and `PdfByteQRCode`.

### [2.0.0] - 2026-05-10
#### Changed
- Reorganized codebase with SOLID and Clean Architecture folder structure.
- Multi-language documentation (en-US default + pt-BR).
- Updated target frameworks: .NET Standard 2.1, .NET 8.0, .NET 10.0, .NET Framework 4.8.

### [1.0.8] - 2026-02-18
#### Added
- SkiaSharp native library handling for Linux CI.
- Consolidated publish workflows.

### [1.0.5] - 2025-07-13
#### Changed
- Migrated rendering to SkiaSharp.
- General project and documentation adjustments.

### [1.0.3] - 2024-04-01
#### Changed
- Dependency updates.
#### Fixed
- Action corrections.


# QRCoder.Core - QR Code Generator Library

[![Build status](https://github.com/afonsoft/QRCoder.Core/actions/workflows/ci-build-test.yml/badge.svg?branch=main)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/ci-build-test.yml)
[![codecov](https://codecov.io/gh/afonsoft/QRCoder.Core/graph/badge.svg?token=N8RED1A0D7)](https://codecov.io/gh/afonsoft/QRCoder.Core)
[![NuGet Badge](https://buildstats.info/nuget/QRCoder.Core?rnd=0892982314)](https://www.nuget.org/packages/QRCoder.Core/)
[![Code Quality](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)

## Project Description / Descrição do Projeto

**EN:** QRCoder.Core is a cross-platform C# .NET library for QR code generation and rendering, based on [QRCoder](https://github.com/codebude/QRCoder). It supports multiple output formats (PNG, SVG, PDF, ASCII, Base64, Postscript, Bitmap) and runs on Windows, Linux, macOS, and mobile platforms via .NET Standard 2.1, .NET 8.0, .NET 10.0 and .NET Framework 4.8. Developed and maintained by [AFONSOFT](https://github.com/afonsoft).

**PT-BR:** QRCoder.Core é uma biblioteca C# .NET multiplataforma para geração e renderização de códigos QR, baseada em [QRCoder](https://github.com/codebude/QRCoder). Suporta múltiplos formatos de saída (PNG, SVG, PDF, ASCII, Base64, Postscript, Bitmap) e funciona em Windows, Linux, macOS e plataformas móveis via .NET Standard 2.1, .NET 8.0, .NET 10.0 e .NET Framework 4.8. Desenvolvida e mantida pela [AFONSOFT](https://github.com/afonsoft).

## Installation / Instalação

### NuGet Package Manager
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

## Technologies / Tecnologias

| Technology | Purpose |
|---|---|
| C# | Primary language |
| .NET Standard 2.1 / .NET 8.0 / .NET 10.0 / .NET Framework 4.8 | Target frameworks |
| SkiaSharp | Cross-platform 2D graphics rendering |
| Microsoft.Extensions.ObjectPool | Object pool performance optimization |
| xUnit + Shouldly | Unit testing |
| GitHub Actions | CI/CD pipelines |

## Repository Structure / Estrutura do Repositório

```
.
├── QRCoder.Core/                        # Main library source code
│   ├── Abstractions/                    # Base classes and interfaces
│   │   └── AbstractQRCode.cs            # Abstract base class for all QR code renderers
│   ├── Exceptions/                      # Custom exception types
│   │   └── DataTooLongException.cs      # Exception for payload size overflow
│   ├── Extensions/                      # Extension methods and attributes
│   │   ├── SKColorExtensions.cs         # SkiaSharp color conversion helpers
│   │   └── StringValueAttribute.cs      # Enum string value attribute
│   ├── Generators/                      # QR code data generation
│   │   ├── QRCodeGenerator.cs           # Main QR code encoding engine
│   │   └── PayloadGenerator.cs          # Typed payload builders (WiFi, URL, vCard, etc.)
│   ├── Models/                          # Data models
│   │   ├── QRCodeData.cs                # QR code matrix data structure
│   │   └── Size.cs                      # Size value type
│   ├── Renderers/                       # Output format renderers
│   │   ├── ArtQRCode.cs                 # Artistic QR code with rounded dots
│   │   ├── AsciiQRCode.cs              # ASCII text representation
│   │   ├── Base64QRCode.cs             # Base64-encoded image string
│   │   ├── BitmapByteQRCode.cs         # BMP byte array
│   │   ├── PdfByteQRCode.cs            # PDF document byte array
│   │   ├── PngByteQRCode.cs            # PNG byte array (no SkiaSharp dependency)
│   │   ├── PostscriptQRCode.cs         # PostScript/EPS format
│   │   ├── QRCode.cs                   # SkiaSharp SKBitmap renderer
│   │   └── SvgQRCode.cs               # SVG string renderer
│   └── Assets/                          # NuGet package assets
├── QRCoder.Core.Tests/                  # Unit test project
│   ├── Generators/                      # Generator tests
│   ├── Renderers/                       # Renderer tests
│   ├── Helpers/                         # Test utilities
│   └── assets/                          # Test assets (images)
├── Docs/                                # Auto-generated API documentation
├── docs/                                # Usage guides (EN/PT-BR)
└── .github/workflows/                   # CI/CD pipeline definitions
```

## Quick Start / Início Rápido

### Basic QR Code Generation / Geração Básica

```csharp
using QRCoder.Core.Generators;
using QRCoder.Core.Renderers;

// Generate QR code data
using var qrGenerator = new QRCodeGenerator();
using var qrCodeData = qrGenerator.CreateQrCode("https://github.com/afonsoft/QRCoder.Core", QRCodeGenerator.ECCLevel.Q);

// Render as PNG byte array (cross-platform, no SkiaSharp needed)
using var pngQrCode = new PngByteQRCode(qrCodeData);
byte[] pngBytes = pngQrCode.GetGraphic(20);
File.WriteAllBytes("qrcode.png", pngBytes);
```

### SVG Output / Saída SVG

```csharp
using QRCoder.Core.Generators;
using QRCoder.Core.Renderers;

using var qrGenerator = new QRCodeGenerator();
using var qrCodeData = qrGenerator.CreateQrCode("Hello World", QRCodeGenerator.ECCLevel.M);
using var svgQrCode = new SvgQRCode(qrCodeData);
string svgContent = svgQrCode.GetGraphic(10);
File.WriteAllText("qrcode.svg", svgContent);
```

### ASCII Output / Saída ASCII

```csharp
using QRCoder.Core.Generators;
using QRCoder.Core.Renderers;

using var qrGenerator = new QRCodeGenerator();
using var qrCodeData = qrGenerator.CreateQrCode("Test", QRCodeGenerator.ECCLevel.L);
using var asciiQrCode = new AsciiQRCode(qrCodeData);
string asciiArt = asciiQrCode.GetGraphic(1);
Console.WriteLine(asciiArt);
```

### Custom Colors / Cores Personalizadas

```csharp
using QRCoder.Core.Generators;
using QRCoder.Core.Renderers;
using SkiaSharp;

using var qrGenerator = new QRCodeGenerator();
using var qrCodeData = qrGenerator.CreateQrCode("Colored QR", QRCodeGenerator.ECCLevel.Q);
using var qrCode = new QRCode(qrCodeData);

// Using SKColor
SKBitmap bitmap = qrCode.GetGraphic(20, SKColors.DarkRed, SKColors.White);

// Using hex strings
SKBitmap bitmapHex = qrCode.GetGraphic(20, "#8B0000", "#FFFFFF");
```

### PayloadGenerator / Gerador de Payloads

```csharp
using QRCoder.Core.Generators;

// WiFi QR code
var wifiPayload = new PayloadGenerator.WiFi("MyNetwork", "MyPassword", PayloadGenerator.WiFi.Authentication.WPA);
string wifiString = wifiPayload.ToString();

// vCard contact
var contactPayload = new PayloadGenerator.ContactData(
    PayloadGenerator.ContactData.ContactOutputType.VCard3,
    "Doe", "John",
    email: "john@example.com",
    phone: "+1234567890"
);
```

## Available Renderers / Renderizadores Disponíveis

| Renderer | Output | Platform Dependencies |
|---|---|---|
| `PngByteQRCode` | PNG `byte[]` | None (pure .NET) |
| `SvgQRCode` | SVG `string` | None (pure .NET) |
| `AsciiQRCode` | ASCII `string` | None (pure .NET) |
| `PostscriptQRCode` | PS/EPS `string` | None (pure .NET) |
| `QRCode` | `SKBitmap` | SkiaSharp |
| `ArtQRCode` | `SKBitmap` (artistic) | SkiaSharp |
| `Base64QRCode` | Base64 `string` | SkiaSharp |
| `PdfByteQRCode` | PDF `byte[]` | SkiaSharp |
| `SKBitmapByteQRCode` | BMP `byte[]` | None |

## Architecture / Arquitetura

The v2.0.0 codebase follows **SOLID** principles and **Clean Architecture**:

| Namespace | Responsibility |
|---|---|
| `QRCoder.Core.Abstractions` | Base types (`AbstractQRCode`) — **Single Responsibility / Open-Closed** |
| `QRCoder.Core.Models` | Data models (`QRCodeData`, `Size`) — **Single Responsibility** |
| `QRCoder.Core.Generators` | Encoding engine (`QRCodeGenerator`, `PayloadGenerator`) — **Single Responsibility** |
| `QRCoder.Core.Renderers` | Output format renderers — **Open-Closed / Liskov Substitution** |
| `QRCoder.Core.Exceptions` | Custom exceptions (`DataTooLongException`) |
| `QRCoder.Core.Extensions` | Utility extensions (`SKColorExtensions`, `StringValueAttribute`) |

### Migration from v1.x / Migração do v1.x

In v2.0.0, types were reorganized into sub-namespaces. Update your `using` statements:

```csharp
// v1.x
using QRCoder.Core;

// v2.0.0
using QRCoder.Core.Generators;    // QRCodeGenerator, PayloadGenerator
using QRCoder.Core.Renderers;     // QRCode, SvgQRCode, PngByteQRCode, etc.
using QRCoder.Core.Models;        // QRCodeData, Size
using QRCoder.Core.Abstractions;  // AbstractQRCode
using QRCoder.Core.Exceptions;    // DataTooLongException (unchanged)
using QRCoder.Core.Extensions;    // SKColorExtensions (unchanged)
```

## Platform Compatibility / Compatibilidade de Plataformas

| Platform | Framework | Status |
|---|---|---|
| Windows | .NET 8.0 / 10.0 / Framework 4.8 | Supported |
| Linux | .NET 8.0 / 10.0 | Supported |
| macOS | .NET 8.0 / 10.0 | Supported |
| Android/iOS (MAUI) | .NET Standard 2.1 | Supported |
| Blazor WebAssembly | .NET Standard 2.1 | Supported (PngByteQRCode, SvgQRCode) |

## Running Tests Locally / Executando Testes Localmente

```bash
# Build
dotnet build QRCoder.Core.sln --configuration Release

# Run tests with coverage
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
```

## CI/CD

The project uses GitHub Actions for automated build, test, security scanning, and NuGet publishing:

- **CI Build & Test**: Builds and tests across all target frameworks
- **Code Quality**: SonarCloud and Qodana analysis
- **Security**: CodeQL and Snyk vulnerability scanning
- **Publish**: Automated NuGet.org and GitHub Packages publishing

### Required Secrets

| Secret | Purpose |
|---|---|
| `CODECOV_TOKEN` | Coverage upload to [Codecov](https://codecov.io/) |
| `NUGET_TOKEN` | NuGet.org package publishing |
| `SONNAR_TOKEN` | SonarCloud code analysis |

## Contributing / Contribuindo

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/my-feature`)
3. Follow the existing code style and architecture
4. Add tests for new functionality
5. Ensure all tests pass (`dotnet test`)
6. Submit a Pull Request

## Developer / Desenvolvedor

- **Afonso Dutra Nogueira Filho** ([AFONSOFT](https://github.com/afonsoft)) — Lead developer

## License / Licença

This project is licensed under the MIT License. See [LICENSE.txt](LICENSE.txt) for details.

## Changelog

### [2.0.0] - 2026-05-03
#### Breaking Changes
- Reorganized codebase following SOLID principles and Clean Architecture
- Types moved to sub-namespaces: `Abstractions`, `Models`, `Generators`, `Renderers`
- Consumers must update `using` statements (see Migration Guide above)

#### Added
- New folder/namespace structure: `Abstractions/`, `Models/`, `Generators/`, `Renderers/`
- Additional unit tests for edge cases and full coverage
- Bilingual README (EN/PT-BR)
- Migration guide from v1.x

#### Changed
- Version bumped to 2.0.0
- Improved README with architecture documentation and platform compatibility table

### [1.0.8] - 2026-05-03
#### Changed
- Documentation improvements and best practices tests

### [1.0.6] - 2025-02-17
#### Added
- Test coverage reporting, performance optimization packages, CI/CD pipeline
- Support for .NET 10.0

### [1.0.5] - 2025-02-17
#### Added
- Complete CI/CD pipeline, security scans, automated NuGet publishing

### [1.0.4] - 2025-07-13
#### Changed
- SkiaSharp adjustments, documentation improvements

### [1.0.3] - 2024-04-01
#### Fixed
- Action corrections and dependency updates

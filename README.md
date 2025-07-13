
# QRCoder.Core - QR Code Generator Library

|Code coverage|Build status|NuGet Package|
|-------------|------------|-------------|
[![codecov](https://codecov.io/gh/afonsoft/QRCoder.Core/graph/badge.svg?token=N8RED1A0D7)](https://codecov.io/gh/afonsoft/QRCoder.Core)|[![Build, test, pack, push (Release)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/build-and-pack.yml/badge.svg?branch=main)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/build-and-pack.yml)|[![NuGet Badge](https://buildstats.info/nuget/QRCoder.Core?rnd=0892982314)](https://www.nuget.org/packages/QRCoder.Core/)|

|Code Smell|Lines of Code|Bugs|Vulnerabilities|
|----------|-------------|----|---------------|
|[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=bugs)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|

## Project Description
QRCoder.Core is a simple C# .NET library, based on [QrCode](https://github.com/codebude/QRCoder), that allows the creation of QR codes. This version is optimized for .NET Core and is available as a NuGet package. The project is developed and maintained by AFONSOFT, focusing on providing a robust and easy-to-use solution for QR code generation in .NET environments.

## Project Status
Completed

## Repository Structure
```
.
├── [Docs/](Docs/)                                   # Automatically generated documentation for the library.
│   └── media/                              # Images and media used in the documentation.
├── [LICENSE.txt](LICENSE.txt)                             # Project license file.
├── [QRCoder.Core/](QRCoder.Core/)                           # Main source code for the QRCoder.Core library.
│   ├── [ASCIIQRCode.cs](QRCoder.Core/ASCIIQRCode.cs)                      # Implementation for generating QR Codes in ASCII format.
│   ├── [AbstractQRCode.cs](QRCoder.Core/AbstractQRCode.cs)                   # Abstract base class for all QR Code types.
│   ├── [ArtQRCode.cs](QRCoder.Core/ArtQRCode.cs)                        # Implementation for generating artistic QR Codes.
│   ├── [Assets/](QRCoder.Core/Assets/)                             # Project assets, including icons and README files for NuGet.
│   │   ├── nuget-icon.png                  # NuGet package icon.
│   │   └── nuget-readme.md                 # README content for the NuGet package.
│   ├── [Base64QRCode.cs](QRCoder.Core/Base64QRCode.cs)                     # Implementation for generating QR Codes in Base64 format.
│   ├── [BitmapByteQRCode.cs](QRCoder.Core/BitmapByteQRCode.cs)                 # Implementation for generating QR Codes as byte bitmaps.
│   ├── [Exceptions/](QRCoder.Core/Exceptions/)                         # Custom exception classes for the library.
│   │   └── [DataTooLongException.cs](QRCoder.Core/Exceptions/DataTooLongException.cs)         # Exception thrown when data exceeds QR Code limit.
│   ├── [Extensions/](QRCoder.Core/Extensions/)                         # Extension methods for additional functionalities.
│   │   └── [StringValueAttribute.cs](QRCoder.Core/Extensions/StringValueAttribute.cs)         # Attribute for custom string values.
│   ├── [PayloadGenerator.cs](QRCoder.Core/PayloadGenerator.cs)                 # Payload generator for different QR Code types (e.g., URL, SMS, Wi-Fi).
│   ├── [PdfByteQRCode.cs](QRCoder.Core/PdfByteQRCode.cs)                    # Implementation for generating QR Codes in PDF format.
│   ├── [PngByteQRCode.cs](QRCoder.Core/PngByteQRCode.cs)                    # Implementation for generating QR Codes in PNG format.
│   ├── [PostscriptQRCode.cs](QRCoder.Core/PostscriptQRCode.cs)                 # Implementation for generating QR Codes in Postscript format.
│   ├── [QRCode.cs](QRCoder.Core/QRCode.cs)                           # Main class for QR Code manipulation and rendering.
│   ├── [QRCodeData.cs](QRCoder.Core/QRCodeData.cs)                       # Data structure for storing QR Code data.
│   ├── [QRCodeGenerator.cs](QRCoder.Core/QRCodeGenerator.cs)                  # QR Code data generator.
│   ├── [QRCoder.Core.csproj](QRCoder.Core/QRCoder.Core.csproj)                 # C# project file for the QRCoder.Core library.
│   └── [SvgQRCode.cs](QRCoder.Core/SvgQRCode.cs)                        # Implementation for generating QR Codes in SVG format.
├── [QRCoder.Core.Docs.shfbproj](QRCoder.Core.Docs.shfbproj)              # Sandcastle Help File Builder documentation project.
├── [QRCoder.Core.Docs.sln](QRCoder.Core.Docs.sln)                   # Solution for the documentation project.
├── [QRCoder.Core.Tests/](QRCoder.Core.Tests/)                     # Unit test project for the library.
│   ├── [ArtQRCodeRendererTests.cs](QRCoder.Core.Tests/ArtQRCodeRendererTests.cs)           # Tests for the artistic QR Code renderer.
│   ├── [AsciiQRCodeRendererTests.cs](QRCoder.Core.Tests/AsciiQRCodeRendererTests.cs)         # Tests for the ASCII QR Code renderer.
│   ├── [Helpers/](QRCoder.Core.Tests/Helpers/)                            # Helper classes for tests.
│   │   ├── [CategoryDiscoverer.cs](QRCoder.Core.Tests/Helpers/CategoryDiscoverer.cs)           # Helper for test category discovery.
│   │   └── [HelperFunctions.cs](QRCoder.Core.Tests/Helpers/HelperFunctions.cs)              # General helper functions for tests.
│   ├── [PayloadGeneratorTests.cs](QRCoder.Core.Tests/PayloadGeneratorTests.cs)            # Tests for the payload generator.
│   ├── [PngByteQRCodeRendererTests.cs](QRCoder.Core.Tests/PngByteQRCodeRendererTests.cs)       # Tests for the PNG QR Code renderer.
│   ├── [QRCodeRendererTests.cs](QRCoder.Core.Tests/QRCodeRendererTests.cs)              # Tests for the general QR Code renderer.
│   ├── [QRCoder.Core.Tests.csproj](QRCoder.Core.Tests/QRCoder.Core.Tests.csproj)           # C# project file for the tests.
│   ├── [QRGeneratorTests.cs](QRCoder.Core.Tests/QRGeneratorTests.cs)                 # Tests for the QR Code generator.
│   ├── [SvgQRCodeRendererTests.cs](QRCoder.Core.Tests/SvgQRCodeRendererTests.cs)           # Tests for the SVG QR Code renderer.
│   └── [assets/](QRCoder.Core.Tests/assets/)                             # Assets used in tests (images, etc.).
├── [QRCoder.Core.sln](QRCoder.Core.sln)                        # Main solution for the QRCoder.Core project.
└── [readme.md](readme.md)                               # Original repository README.
```

## Technologies Used
*   **C#**: Main programming language.
*   **.NET Standard 2.1, .NET 6.0, .NET 8.0**: Target frameworks for the library.
*   **SkiaSharp**: Graphics library for rendering QR Codes in different formats.
*   **SkiaSharp.Views**: UI components for SkiaSharp.
*   **System.Text.Encoding**: For text encoding manipulation.
*   **System.Text.Encoding.Extensions**: Extensions for text encoding.
*   **System.Text.Encoding.CodePages**: Support for additional code pages.
*   **SourceLink.Create.CommandLine**: For source code debugging.
*   **Microsoft.SourceLink.GitHub**: For integration with GitHub SourceLink.

## Prerequisites
To use or contribute to this project, you will need to have the .NET SDK installed on your machine, compatible with .NET Standard 2.1, .NET 6.0, or .NET 8.0 versions.

## Getting Started
You can generate and view your first QR code with just a few lines of C# code.

```csharp
using QRCoder;
using System.Drawing; // Required for Bitmap, may vary depending on the .NET environment

// Instantiate the QR Code generator
using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
{
    // Create QR Code data from a string and error correction level
    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode("The text to be encoded.", QRCodeGenerator.ECCLevel.Q))
    {
        // Create a QRCode instance with the data
        using (QRCode qrCode = new QRCode(qrCodeData))
        {
            // Get the graphical representation of the QR Code as a Bitmap
            // The '20' parameter defines the module size (pixel) of the QR Code
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // Example of how to save the image (requires System.Drawing.Common for .NET Core/5+)
            // qrCodeImage.Save("qrcode.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
```

### Optional Parameters and Overloads
The `GetGraphic` method has several overloads. The first two allow you to define the QR code graphic color using `Color` types or HTML hexadecimal color notation.

```csharp
// Define color using Color types
Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.DarkRed, Color.PaleGreen, true);

// Define color using HTML hexadecimal color notation
Bitmap qrCodeImage = qrCode.GetGraphic(20, "#000ff0", "#0ff000");
```

This overload allows rendering a logo/image in the center of the QR code.

```csharp
Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)Bitmap.FromFile("path/to/your/image.png"));
```

## Project Flow
The `QRCoder.Core` project is a library that facilitates QR code generation in .NET applications. The main flow involves:
1.  **Data Generation**: The `QRCodeGenerator` class is responsible for taking an input string and converting it into `QRCodeData`, which is a binary representation of the QR Code, considering the error correction level (ECCLevel).
2.  **Rendering**: Classes inheriting from `AbstractQRCode` (such as `QRCode`, `PngByteQRCode`, `SvgQRCode`, `ASCIIQRCode`, etc.) use `QRCodeData` to render the QR Code in different graphic formats (Bitmap, PNG, SVG, ASCII, etc.).
3.  **Payload Generation**: The `PayloadGenerator` class offers methods to create formatted payloads for specific QR Code types, such as URLs, SMS, contacts, Wi-Fi, among others, simplifying the creation of QR Codes for common use cases.
4.  **Exception Handling**: The project includes custom exceptions, such as `DataTooLongException`, to handle scenarios where the provided data exceeds the maximum capacity of a QR Code.

## Code Coverage
Code coverage is monitored and results can be viewed through the badge:
[![codecov](https://codecov.io/gh/afonsoft/QRCoder.Core/graph/badge.svg?token=N8RED1A0D7)](https://codecov.io/gh/afonsoft/QRCoder.Core)

## Developers/Contributors
*   **Afonso Dutra Nogueira Filho** (AFONSOFT) - Main developer.

## License
This project is licensed under the MIT License. For more details, see the [LICENSE.txt](LICENSE.txt) file.

## Changelog

### [1.0.4] - 2025-07-13
#### Changed
- General adjustments in the project and documentation.
- Improvements in README.md formatting.
- Typo corrections in README.md.
- Wiki link updates in README.md.
- Adjustments related to SkiaSharp.

### [1.0.3] - 2024-04-01
#### Fixed
- Action corrections (fix actions).
#### Changed
- Dependency updates (codecov/codecov-action from 4 to 5, NuGet/setup-nuget from 2.0.0 to 2.0.1).
- Condition adjustments.

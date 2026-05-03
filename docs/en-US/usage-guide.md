# QRCoder.Core — Usage Guide (en-US)

Cross-platform .NET library for QR Code generation using SkiaSharp. Compatible with **Windows**, **Linux**, **macOS**, and **mobile** (Xamarin / MAUI).

## Table of Contents

- [Installation](#installation)
- [Quick Start](#quick-start)
- [Output Formats](#output-formats)
  - [QRCode (SKBitmap)](#qrcode-skbitmap)
  - [PNG Bytes](#png-bytes)
  - [SVG](#svg)
  - [Base64](#base64)
  - [PDF](#pdf)
  - [ASCII Art](#ascii-art)
  - [Postscript / EPS](#postscript--eps)
  - [Artistic QR Code](#artistic-qr-code)
  - [BMP Bytes](#bmp-bytes)
- [Payloads (Content Types)](#payloads-content-types)
- [Advanced Settings](#advanced-settings)
- [Supported Platforms](#supported-platforms)

---

## Installation

```bash
dotnet add package QRCoder.Core
```

Or via NuGet Package Manager:

```
Install-Package QRCoder.Core
```

### Platform-Specific Dependencies

SkiaSharp requires native libraries for each platform. `QRCoder.Core` automatically includes the correct dependencies:

| Platform | Native Package                     |
| -------- | ---------------------------------- |
| Linux    | `SkiaSharp.NativeAssets.Linux`     |
| macOS    | `SkiaSharp.NativeAssets.macOS`     |
| Windows  | `SkiaSharp.NativeAssets.Win32`     |
| Android  | `SkiaSharp.NativeAssets.Android`   |
| iOS      | `SkiaSharp.NativeAssets.iOS`       |

---

## Quick Start

```csharp
using QRCoder.Core;
using SkiaSharp;

// 1. Create the generator
using var generator = new QRCodeGenerator();

// 2. Generate QR Code data
using var data = generator.CreateQrCode("https://github.com/afonsoft/QRCoder.Core",
    QRCodeGenerator.ECCLevel.M);

// 3. Render as image
using var qrCode = new QRCode(data);
using var image = qrCode.GetGraphic(10); // 10 pixels per module

// 4. Save as PNG
using var stream = File.OpenWrite("qrcode.png");
image.Encode(stream, SKEncodedImageFormat.Png, 100);
```

---

## Output Formats

### QRCode (SKBitmap)

Generates an `SKBitmap` with the QR Code rendered via SkiaSharp.

```csharp
using var generator = new QRCodeGenerator();
using var data = generator.CreateQrCode("Hello World!", QRCodeGenerator.ECCLevel.H);
using var qr = new QRCode(data);

// Default black and white
using var bmp = qr.GetGraphic(10);

// Custom colors
using var colorBmp = qr.GetGraphic(10, SKColors.DarkBlue, SKColors.LightGray, true);

// Using hex colors
using var hexBmp = qr.GetGraphic(10, "#1a1a2e", "#e0e0e0");

// With centered logo
using var logo = SKBitmap.Decode("logo.png");
using var logoBmp = qr.GetGraphic(10, SKColors.Black, SKColors.White,
    icon: logo, iconSizePercent: 15, iconBorderWidth: 2);
```

### PNG Bytes

Generates the QR Code directly as a PNG byte array — ideal for APIs and web services.

```csharp
using var generator = new QRCodeGenerator();
using var data = generator.CreateQrCode("API Data", QRCodeGenerator.ECCLevel.M);
using var png = new PngByteQRCode(data);

// Default black and white
byte[] pngBytes = png.GetGraphic(5);
File.WriteAllBytes("qrcode.png", pngBytes);

// With custom colors (RGB)
byte[] darkColor = new byte[] { 0, 0, 128 };      // Dark blue
byte[] lightColor = new byte[] { 255, 255, 200 };  // Light yellow
byte[] colorBytes = png.GetGraphic(5, darkColor, lightColor);

// With transparency (RGBA)
byte[] darkAlpha = new byte[] { 0, 0, 0, 255 };
byte[] lightAlpha = new byte[] { 255, 255, 255, 128 };  // Semi-transparent
byte[] alphaBytes = png.GetGraphic(5, darkAlpha, lightAlpha);
```

### SVG

Generates the QR Code as an SVG string — perfect for web and vector documents.

```csharp
using var generator = new QRCodeGenerator();
using var data = generator.CreateQrCode("https://example.com", QRCodeGenerator.ECCLevel.Q);
using var svg = new SvgQRCode(data);

// Default SVG
string svgString = svg.GetGraphic(10);
File.WriteAllText("qrcode.svg", svgString);

// With custom colors
string colorSvg = svg.GetGraphic(10, SKColors.DarkRed, SKColors.White);

// With specific viewBox size
string viewBoxSvg = svg.GetGraphic(new Size(200, 200));

// Without quiet zone
string noBorderSvg = svg.GetGraphic(10, SKColors.Black, SKColors.White, false);

// With embedded SVG logo
string svgLogo = File.ReadAllText("logo.svg");
var logoObj = new SvgQRCode.SvgLogo(svgLogo, 15);
string logoSvg = svg.GetGraphic(10, SKColors.Black, SKColors.White, logo: logoObj);
```

### Base64

Generates the QR Code as Base64-encoded string — useful for embedding in HTML/CSS.

```csharp
using var generator = new QRCodeGenerator();
using var data = generator.CreateQrCode("Base64 Data", QRCodeGenerator.ECCLevel.M);
using var b64 = new Base64QRCode(data);

// PNG as Base64
string base64Png = b64.GetGraphic(5);

// JPEG as Base64
string base64Jpeg = b64.GetGraphic(5, SKColors.Black, SKColors.White,
    true, Base64QRCode.ImageType.Jpeg);

// Use in HTML
string htmlImg = $"<img src=\"data:image/png;base64,{base64Png}\" alt=\"QR Code\" />";
```

### PDF

Generates the QR Code as a PDF document in bytes.

```csharp
using var generator = new QRCodeGenerator();
using var data = generator.CreateQrCode("PDF Document", QRCodeGenerator.ECCLevel.M);
using var pdf = new PdfByteQRCode(data);

// Default PDF
byte[] pdfBytes = pdf.GetGraphic(5);
File.WriteAllBytes("qrcode.pdf", pdfBytes);

// With custom colors and DPI
byte[] colorPdf = pdf.GetGraphic(5, "#000080", "#FFFFFF", 300, 95);
```

### ASCII Art

Generates the QR Code as ASCII text — useful for terminal output and logs.

```csharp
using var generator = new QRCodeGenerator();
using var data = generator.CreateQrCode("Terminal QR", QRCodeGenerator.ECCLevel.L);
using var ascii = new AsciiQRCode(data);

// Default
string text = ascii.GetGraphic(1);
Console.WriteLine(text);

// Custom symbols
string custom = ascii.GetGraphic(1, "██", "  ", true);

// Get line by line
string[] lines = ascii.GetLineByLineGraphic(1);
foreach (var line in lines)
    Console.WriteLine(line);

// Via helper (one-liner)
string result = AsciiQRCodeHelper.GetQRCode("Quick!", 1, "██", "  ",
    QRCodeGenerator.ECCLevel.M);
```

### Postscript / EPS

Generates the QR Code in Postscript or EPS format.

```csharp
using var generator = new QRCodeGenerator();
using var data = generator.CreateQrCode("Print Quality", QRCodeGenerator.ECCLevel.M);
using var ps = new PostscriptQRCode(data);

// Standard Postscript
string postscript = ps.GetGraphic(5);
File.WriteAllText("qrcode.ps", postscript);

// EPS format
string eps = ps.GetGraphic(5, epsFormat: true);
File.WriteAllText("qrcode.eps", eps);

// With colors
string colorPs = ps.GetGraphic(5, "#FF0000", "#FFFFFF");

// With viewBox
string viewBoxPs = ps.GetGraphic(new Size(200, 200));
```

### Artistic QR Code

Generates QR Codes with artistic styling (dots instead of squares).

```csharp
using var generator = new QRCodeGenerator();
using var data = generator.CreateQrCode("Artistic QR", QRCodeGenerator.ECCLevel.H);
using var art = new ArtQRCode(data);

// Default (rounded dots)
using var bmp = art.GetGraphic(10);

// With custom pixel size (0.0 to 1.0)
using var smallBmp = art.GetGraphic(10, SKColors.Black, SKColors.White,
    SKColors.Transparent, pixelSizeFactor: 0.5);

// With background image
using var background = SKBitmap.Decode("background.png");
using var bgBmp = art.GetGraphic(background);

// With custom finder pattern
using var finder = SKBitmap.Decode("finder.png");
using var customBmp = art.GetGraphic(10, SKColors.Black, SKColors.White,
    SKColors.Transparent, finderPatternImage: finder);
```

### BMP Bytes

Generates the QR Code as a Windows Bitmap byte array.

```csharp
using var generator = new QRCodeGenerator();
using var data = generator.CreateQrCode("BMP test", QRCodeGenerator.ECCLevel.M);
using var bmp = new SKBitmapByteQRCode(data);

// Default
byte[] bmpBytes = bmp.GetGraphic(5);

// With hex colors
byte[] colorBytes = bmp.GetGraphic(5, "#FF0000", "#00FF00");

// Via helper
byte[] helperBytes = SKBitmapByteQRCodeHelper.GetQRCode("Quick!", 5,
    "#000000", "#FFFFFF", QRCodeGenerator.ECCLevel.M);
```

---

## Payloads (Content Types)

The `PayloadGenerator` creates structured content for various QR Code types:

### WiFi

```csharp
var wifi = new PayloadGenerator.WiFi("MyNetwork", "MyPassword123",
    PayloadGenerator.WiFi.Authentication.WPA);
string content = wifi.ToString();

// Hidden network
var hiddenWifi = new PayloadGenerator.WiFi("HiddenNet", "Password",
    PayloadGenerator.WiFi.Authentication.WPA, isHiddenSSID: true);
```

### URL

```csharp
var url = new PayloadGenerator.Url("https://github.com/afonsoft/QRCoder.Core");
string content = url.ToString();
```

### Email

```csharp
var email = new PayloadGenerator.Mail("contact@example.com",
    "Email Subject", "Message body");
string content = email.ToString();
```

### SMS

```csharp
var sms = new PayloadGenerator.SMS("+1234567890", "Hello via QR Code!");
string content = sms.ToString();
```

### Phone Number

```csharp
var phone = new PayloadGenerator.PhoneNumber("+1234567890");
string content = phone.ToString();
// Result: tel:+1234567890
```

### Geolocation

```csharp
var geo = new PayloadGenerator.Geolocation("40.7128", "-74.0060");
string content = geo.ToString();
// Result: geo:40.7128,-74.0060
```

### Bitcoin

```csharp
var btc = new PayloadGenerator.BitcoinAddress(
    "1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa",
    amount: 0.001,
    label: "Donation",
    message: "Thank you for your support!");
string content = btc.ToString();
```

### vCard (Contact)

```csharp
var contact = new PayloadGenerator.ContactData(
    PayloadGenerator.ContactData.ContactOutputType.VCard3,
    firstname: "John",
    lastname: "Doe",
    org: "Example Corp",
    email: "john@example.com",
    phone: "+1234567890",
    street: "123 Main Street",
    city: "New York",
    stateRegion: "NY",
    country: "United States");
string content = contact.ToString();
```

### Calendar Event

```csharp
var calEvent = new PayloadGenerator.CalendarEvent(
    "Team Meeting",
    "Event description",
    "Room 101",
    new DateTime(2026, 06, 15, 14, 0, 0),
    new DateTime(2026, 06, 15, 15, 0, 0),
    true);
string content = calEvent.ToString();
```

---

## Advanced Settings

### Error Correction Levels (ECC)

| Level | Recovery Capacity | Recommended For               |
| ----- | ----------------- | ----------------------------- |
| L     | ~7%               | Simple data, short URLs       |
| M     | ~15%              | General use (default)         |
| Q     | ~25%              | QR Codes with logos           |
| H     | ~30%              | High-wear environments        |

### Data Serialization

```csharp
using var generator = new QRCodeGenerator();
using var data = generator.CreateQrCode("Serializable data", QRCodeGenerator.ECCLevel.M);

// Save to file
data.SaveRawData("data.qrr", QRCodeData.Compression.GZip);

// Load from file
using var loadedData = new QRCodeData("data.qrr", QRCodeData.Compression.GZip);

// Serialize to bytes
byte[] rawBytes = data.GetRawData(QRCodeData.Compression.Deflate);

// Deserialize from bytes
using var fromBytes = new QRCodeData(rawBytes, QRCodeData.Compression.Deflate);
```

### Force UTF-8

```csharp
using var generator = new QRCodeGenerator();
// Force UTF-8 encoding with BOM
using var data = generator.CreateQrCode("Text with special characters",
    QRCodeGenerator.ECCLevel.M,
    forceUtf8: true,
    utf8BOM: true);
```

### Fixed QR Code Version

```csharp
using var generator = new QRCodeGenerator();
// Force QR Code version 10 (57x57 modules)
using var data = generator.CreateQrCode("Text",
    QRCodeGenerator.ECCLevel.M,
    requestedVersion: 10);
```

---

## Supported Platforms

| Framework             | Version | Status     |
| --------------------- | ------- | ---------- |
| .NET Standard         | 2.1    | Supported  |
| .NET                  | 8.0    | Supported  |
| .NET                  | 10.0   | Supported  |
| .NET Framework        | 4.8    | Supported  |
| Xamarin.Android       | -      | Via SkiaSharp |
| Xamarin.iOS           | -      | Via SkiaSharp |
| .NET MAUI             | -      | Via SkiaSharp |

### ASP.NET Core API Example

```csharp
[HttpGet("qrcode")]
public IActionResult GenerateQRCode([FromQuery] string text)
{
    using var generator = new QRCodeGenerator();
    using var data = generator.CreateQrCode(text, QRCodeGenerator.ECCLevel.M);
    using var png = new PngByteQRCode(data);

    byte[] bytes = png.GetGraphic(5);
    return File(bytes, "image/png");
}
```

### .NET MAUI / Xamarin Example

```csharp
public ImageSource GenerateQRCodeImage(string text)
{
    using var generator = new QRCodeGenerator();
    using var data = generator.CreateQrCode(text, QRCodeGenerator.ECCLevel.M);
    using var png = new PngByteQRCode(data);

    byte[] bytes = png.GetGraphic(5);
    return ImageSource.FromStream(() => new MemoryStream(bytes));
}
```

### Console Example

```csharp
using var generator = new QRCodeGenerator();
using var data = generator.CreateQrCode("Terminal!", QRCodeGenerator.ECCLevel.L);
using var ascii = new AsciiQRCode(data);

Console.WriteLine(ascii.GetGraphic(1));
```

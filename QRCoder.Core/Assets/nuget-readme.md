# QRCoder.Core

A cross-platform .NET library for QR Code generation using **SkiaSharp**. Compatible with **Windows**, **Linux**, **macOS**, and **mobile** (Xamarin / MAUI).

Based on [QRCoder](https://github.com/codebude/QRCoder). Supports **.NET Standard 2.1**, **.NET 8.0**, **.NET 10.0**, and **.NET Framework 4.8**.

---

## Quick Start

```csharp
using QRCoder.Core;

// Generate QR code data
using var generator = new QRCodeGenerator();
using var data = generator.CreateQrCode("https://github.com/afonsoft/QRCoder.Core",
    QRCodeGenerator.ECCLevel.M);

// Render as PNG bytes (cross-platform, no System.Drawing needed)
using var png = new PngByteQRCode(data);
byte[] pngBytes = png.GetGraphic(10);
File.WriteAllBytes("qrcode.png", pngBytes);
```

## Output Formats

| Format | Class | Example |
|--------|-------|---------|
| **PNG** | `PngByteQRCode` | `new PngByteQRCode(data).GetGraphic(10)` → `byte[]` |
| **SVG** | `SvgQRCode` | `new SvgQRCode(data).GetGraphic(10)` → `string` |
| **PDF** | `PdfByteQRCode` | `new PdfByteQRCode(data).GetGraphic(5)` → `byte[]` |
| **ASCII** | `ASCIIQRCode` | `new ASCIIQRCode(data).GetGraphic(1)` → `string` |
| **Base64** | `Base64QRCode` | `new Base64QRCode(data).GetGraphic(10)` → `string` |
| **SKBitmap** | `QRCode` | `new QRCode(data).GetGraphic(10)` → `SKBitmap` |
| **Postscript** | `PostscriptQRCode` | `new PostscriptQRCode(data).GetGraphic(5)` → `string` |
| **Artistic** | `ArtQRCode` | `new ArtQRCode(data).GetGraphic(10)` → `SKBitmap` |
| **BMP** | `BitmapByteQRCode` | `new BitmapByteQRCode(data).GetGraphic(10)` → `byte[]` |

## Multiple Formats Example

```csharp
using QRCoder.Core;

using var gen = new QRCodeGenerator();
using var data = gen.CreateQrCode("Hello World", QRCodeGenerator.ECCLevel.M);

// SVG
using var svg = new SvgQRCode(data);
string svgString = svg.GetGraphic(10);

// ASCII (terminal)
using var ascii = new ASCIIQRCode(data);
Console.WriteLine(ascii.GetGraphic(1));

// PDF
using var pdf = new PdfByteQRCode(data);
byte[] pdfBytes = pdf.GetGraphic(5);

// With custom colors
using var qr = new QRCode(data);
using var bitmap = qr.GetGraphic(10, "#1a1a2e", "#e0e0e0");
```

## Payload Types

Generate formatted QR code content for common use cases:

```csharp
using QRCoder.Core;

using var gen = new QRCodeGenerator();

// Wi-Fi
var wifi = new PayloadGenerator.WiFi("MyNetwork", "MyPassword",
    PayloadGenerator.WiFi.Authentication.WPA);
using var wifiData = gen.CreateQrCode(wifi.ToString(), QRCodeGenerator.ECCLevel.M);

// URL
var url = new PayloadGenerator.Url("https://github.com/afonsoft/QRCoder.Core");
using var urlData = gen.CreateQrCode(url.ToString(), QRCodeGenerator.ECCLevel.M);

// Email
var mail = new PayloadGenerator.Mail("test@example.com", "Subject", "Body");
using var mailData = gen.CreateQrCode(mail.ToString(), QRCodeGenerator.ECCLevel.M);

// Phone Number
var phone = new PayloadGenerator.PhoneNumber("+1234567890");
using var phoneData = gen.CreateQrCode(phone.ToString(), QRCodeGenerator.ECCLevel.M);

// Contact Card (vCard)
var contact = new PayloadGenerator.ContactData(
    PayloadGenerator.ContactData.ContactOutputType.VCard3,
    "Doe", "John", phone: "+1234567890", email: "john@example.com");
using var contactData = gen.CreateQrCode(contact.ToString(), QRCodeGenerator.ECCLevel.M);
```

Supported payloads: URL, WiFi, Mail, SMS, PhoneNumber, MMS, Geolocation, CalendarEvent, ContactData, Bitcoin, Girocode, BezahlCode, SwissQrCode, OneTimePassword, ShadowSocksConfig, Bookmark, SkypeCall, WhatsAppMessage, and more.

## Error Correction Levels

| Level | Recovery | Use Case |
|-------|----------|----------|
| `ECCLevel.L` | ~7% | Maximum data capacity |
| `ECCLevel.M` | ~15% | General purpose (recommended) |
| `ECCLevel.Q` | ~25% | Higher reliability |
| `ECCLevel.H` | ~30% | Maximum recovery (logos, artistic QR) |

## Documentation & Source

- **Repository**: [https://github.com/afonsoft/QRCoder.Core](https://github.com/afonsoft/QRCoder.Core)
- **Usage Guide**: [https://github.com/afonsoft/QRCoder.Core/blob/main/docs/en-US/usage-guide.md](https://github.com/afonsoft/QRCoder.Core/blob/main/docs/en-US/usage-guide.md)
- **Issues**: [https://github.com/afonsoft/QRCoder.Core/issues](https://github.com/afonsoft/QRCoder.Core/issues)
- **License**: MIT

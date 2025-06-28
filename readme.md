# QRCoder.Core
A simple .NET library for generating QR codes.


|Code coverage|Build status|NuGet Package|
|-------------|------------|-------------|
[![codecov](https://codecov.io/gh/afonsoft/QRCoder.Core/graph/badge.svg?token=N8RED1A0D7)](https://codecov.io/gh/afonsoft/QRCoder.Core)|[![Build, test, pack, push (Release)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/build-and-pack.yml/badge.svg?branch=main)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/build-and-pack.yml)|[![NuGet Badge](https://buildstats.info/nuget/QRCoder.Core?rnd=0892982314)](https://www.nuget.org/packages/QRCoder.Core/)|


|Code Smell|Lines of Code|Bugs|Vulnerabilities|
|----------|-------------|----|---------------|
|[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=bugs)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|

## About

QRCoder.Core is a simple C#.NET library based on [QrCode](https://github.com/codebude/QRCoder) that enables you to create QR codes. It is available as a .NET Core version on NuGet.


## Usage

## Wiki Documentation

👉 For detailed documentation of QRCoder and its functions, please visit our wiki.
* [Original QRCoder Wiki](https://github.com/codebude/QRCoder/wiki) or [QRCoder.Core Wiki](https://github.com/afonsoft/QRCoder.Core/wiki)

## Quick Start

You can generate and view your first QR code with just a few lines of C# code.

```csharp

using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
using (QRCodeData qrCodeData = qrGenerator.CreateQrCode("The text which should be encoded.", QRCodeGenerator.ECCLevel.Q))
using (QRCode qrCode = new QRCode(qrCodeData))
{
    Bitmap qrCodeImage = qrCode.GetGraphic(20);
}
```

## Optional parameters and overloads

The GetGraphic method has several overloads. The first two allow you to set the color of the QR code graphic using either Color-class types or HTML hex color notation.

```csharp
//Set color using Color-class types
Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.DarkRed, Color.PaleGreen, true);

//Set color using HTML hex color notation
Bitmap qrCodeImage = qrCode.GetGraphic(20, "#000ff0", "#0ff000");
```

This overload allows you to render a logo/image in the center of the QR code.

```csharp
Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)Bitmap.FromFile("path/to/your/image.png"));
```
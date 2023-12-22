# QRCoder

|Code coverage|Build status|NuGet Package|
|-------------|------------|-------------|
[![codecov](https://codecov.io/gh/afonsoft/QRCoder.Core/graph/badge.svg?token=N8RED1A0D7)](https://codecov.io/gh/afonsoft/QRCoder.Core)|[![Build, test, pack, push (Release)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/build-and-pack.yml/badge.svg?branch=main)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/build-and-pack.yml)|[![NuGet Badge](https://buildstats.info/nuget/QRCoder.Core?rnd=0892982314)](https://www.nuget.org/packages/QRCoder.Core/)|


|Code Smell|Lines of Code|Bugs|Vulnerabilities|
|----------|-------------|----|---------------|
|[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=bugs)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|

## Info

QRCoder.Core is a simple library, written in C#.NET, based on [QrCode](https://github.com/codebude/QRCoder) which enables you to create QR codes. It is available as .NET Core version on NuGet.

***

## Documentation

👉 *Your first place to go should be our wiki. Here you can find a detailed documentation of the QRCoder and its functions.*
* [**QRCode Wiki**](https://github.com/codebude/QRCoder/wiki)

## Usage / Quick start

You only need four lines of code, to generate and view your first QR code.

```csharp
using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
using (QRCodeData qrCodeData = qrGenerator.CreateQrCode("The text which should be encoded.", QRCodeGenerator.ECCLevel.Q))
using (QRCode qrCode = new QRCode(qrCodeData))
{
    Bitmap qrCodeImage = qrCode.GetGraphic(20);
}
```

### Optional parameters and overloads

The GetGraphics-method has some more overloads. The first two enable you to set the color of the QR code graphic. One uses Color-class-types, the other HTML hex color notation.

```csharp
//Set color by using Color-class types
Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.DarkRed, Color.PaleGreen, true);

//Set color by using HTML hex color notation
Bitmap qrCodeImage = qrCode.GetGraphic(20, "#000ff0", "#0ff000");
```

The other overload enables you to render a logo/image in the center of the QR code.

```csharp
Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)Bitmap.FromFile("C:\\myimage.png"));
```
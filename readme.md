# QRCoder

|Build|Code coverage|Build status|NuGet Package|
|-----|-------------|------------|-------------|
|Latest / Stable|[![codecov](https://codecov.io/gh/codebude/QRCoder/branch/master/graph/badge.svg?token=3yNs88KD8S)](https://codecov.io/gh/codebude/QRCoder)|[![Build, test, pack, push (Release)](https://github.com/codebude/QRCoder/actions/workflows/wf-build-release.yml/badge.svg?branch=master)](https://github.com/codebude/QRCoder/actions/workflows/wf-build-release.yml)|[![NuGet Badge](https://buildstats.info/nuget/QRCoder?rnd=0892982314)](https://www.nuget.org/packages/QRCoder/)|
|CI / Last commit|[![codecov](https://codecov.io/gh/codebude/QRCoder/branch/master/graph/badge.svg?token=3yNs88KD8S)](https://codecov.io/gh/codebude/QRCoder)|[![Build, test, pack, push (CI)](https://github.com/codebude/QRCoder/actions/workflows/wf-build-release-ci.yml/badge.svg)](https://github.com/codebude/QRCoder/actions/workflows/wf-build-release-ci.yml)|[![Github packages](https://img.shields.io/badge/Github-Packages-blue)](https://github.com/codebude/qrcoder/packages)|


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
# GetGraphic(Bitmap) Method


Renders an art-style QR code with dots as modules and a background image (With default settings: DarkColor=Black, LightColor=White, Background=Transparent, QuietZone=true)



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+4632349aa2a984532af965c24d83952cef07f5b3  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public Bitmap GetGraphic(
	Bitmap backgroundImage = null
)
```
**C++**
``` C++
public:
Bitmap^ GetGraphic(
	Bitmap^ backgroundImage = nullptr
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.drawing.bitmap" target="_blank" rel="noopener noreferrer">Bitmap</a>  (Optional)</dt><dd>A bitmap object that will be used as background picture</dd></dl>

#### Return Value
<a href="https://learn.microsoft.com/dotnet/api/system.drawing.bitmap" target="_blank" rel="noopener noreferrer">Bitmap</a>  
QRCode graphic as bitmap

## See Also


#### Reference
<a href="T_QRCoder_Core_ArtQRCode.md">ArtQRCode Class</a>  
<a href="Overload_QRCoder_Core_ArtQRCode_GetGraphic.md">GetGraphic Overload</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

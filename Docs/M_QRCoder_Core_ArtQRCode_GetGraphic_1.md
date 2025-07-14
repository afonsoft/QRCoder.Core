# GetGraphic(Int32) Method


Renders an art-style QR code with dots as modules. (With default settings: DarkColor=Black, LightColor=White, Background=Transparent, QuietZone=true)



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public Bitmap GetGraphic(
	int pixelsPerModule
)
```
**C++**
``` C++
public:
Bitmap^ GetGraphic(
	int pixelsPerModule
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a></dt><dd>Amount of px each dark/light module of the QR code shall take place in the final QR code image</dd></dl>

#### Return Value
SKBitmap  
QRCode graphic as bitmap

## See Also


#### Reference
<a href="T_QRCoder_Core_ArtQRCode.md">ArtQRCode Class</a>  
<a href="Overload_QRCoder_Core_ArtQRCode_GetGraphic.md">GetGraphic Overload</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

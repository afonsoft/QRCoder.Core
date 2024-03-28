# GetGraphic(Int32, Color, Color, Boolean, SvgQRCode.SizingMode, SvgQRCode.SvgLogo) Method


Returns a QR code as SVG string with custom colors, optional quietzone and logo



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public string GetGraphic(
	int pixelsPerModule,
	Color darkColor,
	Color lightColor,
	bool drawQuietZones = true,
	SvgQRCode.SizingMode sizingMode = SvgQRCode.SizingMode.WidthHeightAttribute,
	SvgQRCode.SvgLogo logo = null
)
```
**C++**
``` C++
public:
String^ GetGraphic(
	int pixelsPerModule, 
	Color darkColor, 
	Color lightColor, 
	bool drawQuietZones = true, 
	SvgQRCode.SizingMode sizingMode = SvgQRCode.SizingMode::WidthHeightAttribute, 
	SvgQRCode.SvgLogo^ logo = nullptr
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a></dt><dd>The pixel size each b/w module is drawn</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.drawing.color" target="_blank" rel="noopener noreferrer">Color</a></dt><dd>Color of the dark modules</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.drawing.color" target="_blank" rel="noopener noreferrer">Color</a></dt><dd>Color of the light modules</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>If true a white border is drawn around the whole QR Code</dd><dt>  <a href="T_QRCoder_Core_SvgQRCode_SizingMode.md">SvgQRCode.SizingMode</a>  (Optional)</dt><dd>Defines if width/height or viewbox should be used for size definition</dd><dt>  <a href="T_QRCoder_Core_SvgQRCode_SvgLogo.md">SvgQRCode.SvgLogo</a>  (Optional)</dt><dd>A (optional) logo to be rendered on the code (either Bitmap or SVG)</dd></dl>

#### Return Value
<a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  
SVG as string

## See Also


#### Reference
<a href="T_QRCoder_Core_SvgQRCode.md">SvgQRCode Class</a>  
<a href="Overload_QRCoder_Core_SvgQRCode_GetGraphic.md">GetGraphic Overload</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

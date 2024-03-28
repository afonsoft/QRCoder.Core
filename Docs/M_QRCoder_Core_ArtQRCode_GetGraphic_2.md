# GetGraphic(Int32, Color, Color, Color, Bitmap, Double, Boolean, ArtQRCode.QuietZoneStyle, ArtQRCode.BackgroundImageStyle, Bitmap) Method


Renders an art-style QR code with dots as modules and various user settings



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+4632349aa2a984532af965c24d83952cef07f5b3  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public Bitmap GetGraphic(
	int pixelsPerModule,
	Color darkColor,
	Color lightColor,
	Color backgroundColor,
	Bitmap backgroundImage = null,
	double pixelSizeFactor = 0,8,
	bool drawQuietZones = true,
	ArtQRCode.QuietZoneStyle quietZoneRenderingStyle = ArtQRCode.QuietZoneStyle.Dotted,
	ArtQRCode.BackgroundImageStyle backgroundImageStyle = ArtQRCode.BackgroundImageStyle.DataAreaOnly,
	Bitmap finderPatternImage = null
)
```
**C++**
``` C++
public:
Bitmap^ GetGraphic(
	int pixelsPerModule, 
	Color darkColor, 
	Color lightColor, 
	Color backgroundColor, 
	Bitmap^ backgroundImage = nullptr, 
	double pixelSizeFactor = 0,8, 
	bool drawQuietZones = true, 
	ArtQRCode.QuietZoneStyle quietZoneRenderingStyle = ArtQRCode.QuietZoneStyle::Dotted, 
	ArtQRCode.BackgroundImageStyle backgroundImageStyle = ArtQRCode.BackgroundImageStyle::DataAreaOnly, 
	Bitmap^ finderPatternImage = nullptr
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a></dt><dd>Amount of px each dark/light module of the QR code shall take place in the final QR code image</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.drawing.color" target="_blank" rel="noopener noreferrer">Color</a></dt><dd>Color of the dark modules</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.drawing.color" target="_blank" rel="noopener noreferrer">Color</a></dt><dd>Color of the light modules</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.drawing.color" target="_blank" rel="noopener noreferrer">Color</a></dt><dd>Color of the background</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.drawing.bitmap" target="_blank" rel="noopener noreferrer">Bitmap</a>  (Optional)</dt><dd>A bitmap object that will be used as background picture</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.double" target="_blank" rel="noopener noreferrer">Double</a>  (Optional)</dt><dd>Value between 0.0 to 1.0 that defines how big the module dots are. The bigger the value, the less round the dots will be.</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>If true a white border is drawn around the whole QR Code</dd><dt>  <a href="T_QRCoder_Core_ArtQRCode_QuietZoneStyle.md">ArtQRCode.QuietZoneStyle</a>  (Optional)</dt><dd>Style of the quiet zones</dd><dt>  <a href="T_QRCoder_Core_ArtQRCode_BackgroundImageStyle.md">ArtQRCode.BackgroundImageStyle</a>  (Optional)</dt><dd>Style of the background image (if set). Fill=spanning complete graphic; DataAreaOnly=Don't paint background into quietzone</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.drawing.bitmap" target="_blank" rel="noopener noreferrer">Bitmap</a>  (Optional)</dt><dd>Optional image that should be used instead of the default finder patterns</dd></dl>

#### Return Value
<a href="https://learn.microsoft.com/dotnet/api/system.drawing.bitmap" target="_blank" rel="noopener noreferrer">Bitmap</a>  
QRCode graphic as bitmap

## See Also


#### Reference
<a href="T_QRCoder_Core_ArtQRCode.md">ArtQRCode Class</a>  
<a href="Overload_QRCoder_Core_ArtQRCode_GetGraphic.md">GetGraphic Overload</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

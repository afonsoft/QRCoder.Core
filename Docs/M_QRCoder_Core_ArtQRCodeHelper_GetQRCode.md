# GetQRCode Method


Helper function to create an ArtQRCode graphic with a single function call



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public static Bitmap GetQRCode(
	string plainText,
	int pixelsPerModule,
	Color darkColor,
	Color lightColor,
	Color backgroundColor,
	QRCodeGenerator.ECCLevel eccLevel,
	bool forceUtf8 = false,
	bool utf8BOM = false,
	QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default,
	int requestedVersion = -1,
	Bitmap backgroundImage = null,
	double pixelSizeFactor = 0,8,
	bool drawQuietZones = true,
	ArtQRCode.QuietZoneStyle quietZoneRenderingStyle = ArtQRCode.QuietZoneStyle.Flat,
	ArtQRCode.BackgroundImageStyle backgroundImageStyle = ArtQRCode.BackgroundImageStyle.DataAreaOnly,
	Bitmap finderPatternImage = null
)
```
**C++**
``` C++
public:
static Bitmap^ GetQRCode(
	String^ plainText, 
	int pixelsPerModule, 
	Color darkColor, 
	Color lightColor, 
	Color backgroundColor, 
	QRCodeGenerator.ECCLevel eccLevel, 
	bool forceUtf8 = false, 
	bool utf8BOM = false, 
	QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode::Default, 
	int requestedVersion = -1, 
	Bitmap^ backgroundImage = nullptr, 
	double pixelSizeFactor = 0,8, 
	bool drawQuietZones = true, 
	ArtQRCode.QuietZoneStyle quietZoneRenderingStyle = ArtQRCode.QuietZoneStyle::Flat, 
	ArtQRCode.BackgroundImageStyle backgroundImageStyle = ArtQRCode.BackgroundImageStyle::DataAreaOnly, 
	Bitmap^ finderPatternImage = nullptr
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Text/payload to be encoded inside the QR code</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">

Int32</a></dt><dd>Amount of px each dark/light module of the QR code shall take place in the final QR code image</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.drawing.color" target="_blank" rel="noopener noreferrer">Color</a></dt><dd>Color of the dark modules</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.drawing.color" target="_blank" rel="noopener noreferrer">Color</a></dt><dd>Color of the light modules</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.drawing.color" target="_blank" rel="noopener noreferrer">Color</a></dt><dd>Color of the background</dd><dt>  <a href="T_QRCoder_Core_QRCodeGenerator_ECCLevel.md">QRCodeGenerator.ECCLevel</a></dt><dd>The level of error correction data</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>Shall the generator be forced to work in UTF-8 mode?</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>Should the byte-order-mark be used?</dd><dt>  <a href="T_QRCoder_Core_QRCodeGenerator_EciMode.md">QRCodeGenerator.EciMode</a>  (Optional)</dt><dd>Which ECI mode shall be used?</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a>  (Optional)</dt><dd>Set fixed QR code target version.</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.drawing.bitmap" target="_blank" rel="noopener noreferrer">Bitmap</a>  (Optional)</dt><dd>A bitmap object that will be used as background picture</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.double" target="_blank" rel="noopener noreferrer">Double</a>  (Optional)</dt><dd>Value between 0.0 to 1.0 that defines how big the module dots are. The bigger the value, the less round the dots will be.</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>If true a white border is drawn around the whole QR Code</dd><dt>  <a href="T_QRCoder_Core_ArtQRCode_QuietZoneStyle.md">ArtQRCode.QuietZoneStyle</a>  (Optional)</dt><dd>Style of the quiet zones</dd><dt>  <a href="T_QRCoder_Core_ArtQRCode_BackgroundImageStyle.md">ArtQRCode.BackgroundImageStyle</a>  (Optional)</dt><dd>Style of the background image (if set). Fill=spanning complete graphic; DataAreaOnly=Don't paint background into quietzone</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.drawing.bitmap" target="_blank" rel="noopener noreferrer">Bitmap</a>  (Optional)</dt><dd>Optional image that should be used instead of the default finder patterns</dd></dl>

#### Return Value
<a href="https://learn.microsoft.com/dotnet/api/system.drawing.bitmap" target="_blank" rel="noopener noreferrer">Bitmap</a>  
QRCode graphic as bitmap

## See Also


#### Reference
<a href="T_QRCoder_Core_ArtQRCodeHelper.md">ArtQRCodeHelper Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

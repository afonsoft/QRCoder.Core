# GetQRCode Method


GetQRCode



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
	QRCodeGenerator.ECCLevel eccLevel,
	bool forceUtf8 = false,
	bool utf8BOM = false,
	QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default,
	int requestedVersion = -1,
	Bitmap icon = null,
	int iconSizePercent = 15,
	int iconBorderWidth = 0,
	bool drawQuietZones = true
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
	QRCodeGenerator.ECCLevel eccLevel, 
	bool forceUtf8 = false, 
	bool utf8BOM = false, 
	QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode::Default, 
	int requestedVersion = -1, 
	Bitmap^ icon = nullptr, 
	int iconSizePercent = 15, 
	int iconBorderWidth = 0, 
	bool drawQuietZones = true
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>\[Missing &lt;param name="plainText"/&gt; documentation for "M:QRCoder.Core.QRCodeHelper.GetQRCode(System.String,System.Int32,System.Drawing.Color,System.Drawing.Color,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Drawing.Bitmap,System.Int32,System.Int32,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a></dt><dd>\[Missing &lt;param name="pixelsPerModule"/&gt; documentation for "M:QRCoder.Core.QRCodeHelper.GetQRCode(System.String,System.Int32,System.Drawing.Color,System.Drawing.Color,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Drawing.Bitmap,System.Int32,System.Int32,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.drawing.color" target="_blank" rel="noopener noreferrer">Color</a></dt><dd>\[Missing &lt;param name="darkColor"/&gt; documentation for "M:QRCoder.Core.QRCodeHelper.GetQRCode(System.String,System.Int32,System.Drawing.Color,System.Drawing.Color,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Drawing.Bitmap,System.Int32,System.Int32,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.drawing.color" target="_blank" rel="noopener noreferrer">Color</a></dt><dd>\[Missing &lt;param name="lightColor"/&gt; documentation for "M:QRCoder.Core.QRCodeHelper.GetQRCode(System.String,System.Int32,System.Drawing.Color,System.Drawing.Color,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Drawing.Bitmap,System.Int32,System.Int32,System.Boolean)"\]</dd><dt>  <a href="T_QRCoder_Core_QRCodeGenerator_ECCLevel.md">QRCodeGenerator.ECCLevel</a></dt><dd>\[Missing &lt;param name="eccLevel"/&gt; documentation for "M:QRCoder.Core.QRCodeHelper.GetQRCode(System.String,System.Int32,System.Drawing.Color,System.Drawing.Color,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Drawing.Bitmap,System.Int32,System.Int32,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>\[Missing &lt;param name="forceUtf8"/&gt; documentation for "M:QRCoder.Core.QRCodeHelper.GetQRCode(System.String,System.Int32,System.Drawing.Color,System.Drawing.Color,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Drawing.Bitmap,System.Int32,System.Int32,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>\[Missing &lt;param name="utf8BOM"/&gt; documentation for "M:QRCoder.Core.QRCodeHelper.GetQRCode(System.String,System.Int32,System.Drawing.Color,System.Drawing.Color,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Drawing.Bitmap,System.Int32,System.Int32,System.Boolean)"\]</dd><dt>  <a href="T_QRCoder_Core_QRCodeGenerator_EciMode.md">QRCodeGenerator.EciMode</a>  (Optional)</dt><dd>\[Missing &lt;param name="eciMode"/&gt; documentation for "M:QRCoder.Core.QRCodeHelper.GetQRCode(System.String,System.Int32,System.Drawing.Color,System.Drawing.Color,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Drawing.Bitmap,System.Int32,System.Int32,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a>  (Optional)</dt><dd>\[Missing &lt;param name="requestedVersion"/&gt; documentation for "M:QRCoder.Core.QRCodeHelper.GetQRCode(System.String,System.Int32,System.Drawing.Color,System.Drawing.Color,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Drawing.Bitmap,System.Int32,System.Int32,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.drawing.bitmap" target="_blank" rel="noopener noreferrer">Bitmap</a>  (Optional)</dt><dd>\[Missing &lt;param name="icon"/&gt; documentation for "M:QRCoder.Core.QRCodeHelper.GetQRCode(System.String,System.Int32,System.Drawing.Color,System.Drawing.Color,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Drawing.Bitmap,System.Int32,System.Int32,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a>  (Optional)</dt><dd>\[Missing &lt;param name="iconSizePercent"/&gt; documentation for "M:QRCoder.Core.QRCodeHelper.GetQRCode(System.String,System.Int32,System.Drawing.Color,System.Drawing.Color,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Drawing.Bitmap,System.Int32,System.Int32,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a>  (Optional)</dt><dd>\[Missing &lt;param name="iconBorderWidth"/&gt; documentation for "M:QRCoder.Core.QRCodeHelper.GetQRCode(System.String,System.Int32,System.Drawing.Color,System.Drawing.Color,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Drawing.Bitmap,System.Int32,System.Int32,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>\[Missing &lt;param name="drawQuietZones"/&gt; documentation for "M:QRCoder.Core.QRCodeHelper.GetQRCode(System.String,System.Int32,System.Drawing.Color,System.Drawing.Color,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Drawing.Bitmap,System.Int32,System.Int32,System.Boolean)"\]</dd></dl>

#### Return Value
<a href="https://learn.microsoft.com/dotnet/api/system.drawing.bitmap" target="_blank" rel="noopener noreferrer">Bitmap</a>  
\[Missing &lt;returns&gt; documentation for "M:QRCoder.Core.QRCodeHelper.GetQRCode(System.String,System.Int32,System.Drawing.Color,System.Drawing.Color,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Drawing.Bitmap,System.Int32,System.Int32,System.Boolean)"\]

## See Also


#### Reference
<a href="T_QRCoder_Core_QRCodeHelper.md">QRCodeHelper Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

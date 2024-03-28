# GetQRCode Method


\[Missing &lt;summary&gt; documentation for "M:QRCoder.Core.SvgQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,QRCoder.Core.SvgQRCode.SizingMode,QRCoder.Core.SvgQRCode.SvgLogo)"\]



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+4632349aa2a984532af965c24d83952cef07f5b3  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public static string GetQRCode(
	string plainText,
	int pixelsPerModule,
	string darkColorHex,
	string lightColorHex,
	QRCodeGenerator.ECCLevel eccLevel,
	bool forceUtf8 = false,
	bool utf8BOM = false,
	QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default,
	int requestedVersion = -1,
	bool drawQuietZones = true,
	SvgQRCode.SizingMode sizingMode = SvgQRCode.SizingMode.WidthHeightAttribute,
	SvgQRCode.SvgLogo logo = null
)
```
**C++**
``` C++
public:
static String^ GetQRCode(
	String^ plainText, 
	int pixelsPerModule, 
	String^ darkColorHex, 
	String^ lightColorHex, 
	QRCodeGenerator.ECCLevel eccLevel, 
	bool forceUtf8 = false, 
	bool utf8BOM = false, 
	QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode::Default, 
	int requestedVersion = -1, 
	bool drawQuietZones = true, 
	SvgQRCode.SizingMode sizingMode = SvgQRCode.SizingMode::WidthHeightAttribute, 
	SvgQRCode.SvgLogo^ logo = nullptr
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>\[Missing &lt;param name="plainText"/&gt; documentation for "M:QRCoder.Core.SvgQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,QRCoder.Core.SvgQRCode.SizingMode,QRCoder.Core.SvgQRCode.SvgLogo)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a></dt><dd>\[Missing &lt;param name="pixelsPerModule"/&gt; documentation for "M:QRCoder.Core.SvgQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,QRCoder.Core.SvgQRCode.SizingMode,QRCoder.Core.SvgQRCode.SvgLogo)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>\[Missing &lt;param name="darkColorHex"/&gt; documentation for "M:QRCoder.Core.SvgQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,QRCoder.Core.SvgQRCode.SizingMode,QRCoder.Core.SvgQRCode.SvgLogo)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>\[Missing &lt;param name="lightColorHex"/&gt; documentation for "M:QRCoder.Core.SvgQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,QRCoder.Core.SvgQRCode.SizingMode,QRCoder.Core.SvgQRCode.SvgLogo)"\]</dd><dt>  <a href="T_QRCoder_Core_QRCodeGenerator_ECCLevel.md">QRCodeGenerator.ECCLevel</a></dt><dd>\[Missing &lt;param name="eccLevel"/&gt; documentation for "M:QRCoder.Core.SvgQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,QRCoder.Core.SvgQRCode.SizingMode,QRCoder.Core.SvgQRCode.SvgLogo)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>\[Missing &lt;param name="forceUtf8"/&gt; documentation for "M:QRCoder.Core.SvgQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,QRCoder.Core.SvgQRCode.SizingMode,QRCoder.Core.SvgQRCode.SvgLogo)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>\[Missing &lt;param name="utf8BOM"/&gt; documentation for "M:QRCoder.Core.SvgQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,QRCoder.Core.SvgQRCode.SizingMode,QRCoder.Core.SvgQRCode.SvgLogo)"\]</dd><dt>  <a href="T_QRCoder_Core_QRCodeGenerator_EciMode.md">QRCodeGenerator.EciMode</a>  (Optional)</dt><dd>\[Missing &lt;param name="eciMode"/&gt; documentation for "M:QRCoder.Core.SvgQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,QRCoder.Core.SvgQRCode.SizingMode,QRCoder.Core.SvgQRCode.SvgLogo)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a>  (Optional)</dt><dd>\[Missing &lt;param name="requestedVersion"/&gt; documentation for "M:QRCoder.Core.SvgQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,QRCoder.Core.SvgQRCode.SizingMode,QRCoder.Core.SvgQRCode.SvgLogo)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>\[Missing &lt;param name="drawQuietZones"/&gt; documentation for "M:QRCoder.Core.SvgQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,QRCoder.Core.SvgQRCode.SizingMode,QRCoder.Core.SvgQRCode.SvgLogo)"\]</dd><dt>  <a href="T_QRCoder_Core_SvgQRCode_SizingMode.md">SvgQRCode.SizingMode</a>  (Optional)</dt><dd>\[Missing &lt;param name="sizingMode"/&gt; documentation for "M:QRCoder.Core.SvgQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,QRCoder.Core.SvgQRCode.SizingMode,QRCoder.Core.SvgQRCode.SvgLogo)"\]</dd><dt>  <a href="T_QRCoder_Core_SvgQRCode_SvgLogo.md">SvgQRCode.SvgLogo</a>  (Optional)</dt><dd>\[Missing &lt;param name="logo"/&gt; documentation for "M:QRCoder.Core.SvgQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,QRCoder.Core.SvgQRCode.SizingMode,QRCoder.Core.SvgQRCode.SvgLogo)"\]</dd></dl>

#### Return Value
<a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  
\[Missing &lt;returns&gt; documentation for "M:QRCoder.Core.SvgQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,QRCoder.Core.SvgQRCode.SizingMode,QRCoder.Core.SvgQRCode.SvgLogo)"\]

## See Also


#### Reference
<a href="T_QRCoder_Core_SvgQRCodeHelper.md">SvgQRCodeHelper Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

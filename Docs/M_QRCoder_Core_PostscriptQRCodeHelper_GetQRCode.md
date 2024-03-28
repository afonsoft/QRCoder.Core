# GetQRCode Method


\[Missing &lt;summary&gt; documentation for "M:QRCoder.Core.PostscriptQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,System.Boolean)"\]



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public static string GetQRCode(
	string plainText,
	int pointsPerModule,
	string darkColorHex,
	string lightColorHex,
	QRCodeGenerator.ECCLevel eccLevel,
	bool forceUtf8 = false,
	bool utf8BOM = false,
	QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default,
	int requestedVersion = -1,
	bool drawQuietZones = true,
	bool epsFormat = false
)
```
**C++**
``` C++
public:
static String^ GetQRCode(
	String^ plainText, 
	int pointsPerModule, 
	String^ darkColorHex, 
	String^ lightColorHex, 
	QRCodeGenerator.ECCLevel eccLevel, 
	bool forceUtf8 = false, 
	bool utf8BOM = false, 
	QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode::Default, 
	int requestedVersion = -1, 
	bool drawQuietZones = true, 
	bool epsFormat = false
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>\[Missing &lt;param name="plainText"/&gt; documentation for "M:QRCoder.Core.PostscriptQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a></dt><dd>\[Missing &lt;param name="pointsPerModule"/&gt; documentation for "M:QRCoder.Core.PostscriptQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>\[Missing &lt;param name="darkColorHex"/&gt; documentation for "M:QRCoder.Core.PostscriptQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>\[Missing &lt;param name="lightColorHex"/&gt; documentation for "M:QRCoder.Core.PostscriptQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,System.Boolean)"\]</dd><dt>  <a href="T_QRCoder_Core_QRCodeGenerator_ECCLevel.md">QRCodeGenerator.ECCLevel</a></dt><dd>\[Missing &lt;param name="eccLevel"/&gt; documentation for "M:QRCoder.Core.PostscriptQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>\[Missing &lt;param name="forceUtf8"/&gt; documentation for "M:QRCoder.Core.PostscriptQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>\[Missing &lt;param name="utf8BOM"/&gt; documentation for "M:QRCoder.Core.PostscriptQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,System.Boolean)"\]</dd><dt>  <a href="T_QRCoder_Core_QRCodeGenerator_EciMode.md">QRCodeGenerator.EciMode</a>  (Optional)</dt><dd>\[Missing &lt;param name="eciMode"/&gt; documentation for "M:QRCoder.Core.PostscriptQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a>  (Optional)</dt><dd>\[Missing &lt;param name="requestedVersion"/&gt; documentation for "M:QRCoder.Core.PostscriptQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>\[Missing &lt;param name="drawQuietZones"/&gt; documentation for "M:QRCoder.Core.PostscriptQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>\[Missing &lt;param name="epsFormat"/&gt; documentation for "M:QRCoder.Core.PostscriptQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,System.Boolean)"\]</dd></dl>

#### Return Value
<a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  
\[Missing &lt;returns&gt; documentation for "M:QRCoder.Core.PostscriptQRCodeHelper.GetQRCode(System.String,System.Int32,System.String,System.String,QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean,System.Boolean)"\]

## See Also


#### Reference
<a href="T_QRCoder_Core_PostscriptQRCodeHelper.md">PostscriptQRCodeHelper Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

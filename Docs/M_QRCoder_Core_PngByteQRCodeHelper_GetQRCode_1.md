# GetQRCode(String, Int32, Byte[], Byte[], QRCodeGenerator.ECCLevel, Boolean, Boolean, QRCodeGenerator.EciMode, Int32, Boolean) Method


\[Missing &lt;summary&gt; documentation for "M:QRCoder.Core.PngByteQRCodeHelper.GetQRCode(System.String,System.Int32,System.Byte[],System.Byte[],QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean)"\]



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public static byte[] GetQRCode(
	string plainText,
	int pixelsPerModule,
	byte[] darkColorRgba,
	byte[] lightColorRgba,
	QRCodeGenerator.ECCLevel eccLevel,
	bool forceUtf8 = false,
	bool utf8BOM = false,
	QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default,
	int requestedVersion = -1,
	bool drawQuietZones = true
)
```
**C++**
``` C++
public:
static array<unsigned char>^ GetQRCode(
	String^ plainText, 
	int pixelsPerModule, 
	array<unsigned char>^ darkColorRgba, 
	array<unsigned char>^ lightColorRgba, 
	QRCodeGenerator.ECCLevel eccLevel, 
	bool forceUtf8 = false, 
	bool utf8BOM = false, 
	QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode::Default, 
	int requestedVersion = -1, 
	bool drawQuietZones = true
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>\[Missing &lt;param name="plainText"/&gt; documentation for "M:QRCoder.Core.PngByteQRCodeHelper.GetQRCode(System.String,System.Int32,System.Byte[],System.Byte[],QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a></dt><dd>\[Missing &lt;param name="pixelsPerModule"/&gt; documentation for "M:QRCoder.Core.PngByteQRCodeHelper.GetQRCode(System.String,System.Int32,System.Byte[],System.Byte[],QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.byte" target="_blank" rel="noopener noreferrer">Byte</a>[]</dt><dd>\[Missing &lt;param name="darkColorRgba"/&gt; documentation for "M:QRCoder.Core.PngByteQRCodeHelper.GetQRCode(System.String,System.Int32,System.Byte[],System.Byte[],QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.byte" target="_blank" rel="noopener noreferrer">Byte</a>[]</dt><dd>\[Missing &lt;param name="lightColorRgba"/&gt; documentation for "M:QRCoder.Core.PngByteQRCodeHelper.GetQRCode(System.String,System.Int32,System.Byte[],System.Byte[],QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean)"\]</dd><dt>  <a href="T_QRCoder_Core_QRCodeGenerator_ECCLevel.md">QRCodeGenerator.ECCLevel</a></dt><dd>\[Missing &lt;param name="eccLevel"/&gt; documentation for "M:QRCoder.Core.PngByteQRCodeHelper.GetQRCode(System.String,System.Int32,System.Byte[],System.Byte[],QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>\[Missing &lt;param name="forceUtf8"/&gt; documentation for "M:QRCoder.Core.PngByteQRCodeHelper.GetQRCode(System.String,System.Int32,System.Byte[],System.Byte[],QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>\[Missing &lt;param name="utf8BOM"/&gt; documentation for "M:QRCoder.Core.PngByteQRCodeHelper.GetQRCode(System.String,System.Int32,System.Byte[],System.Byte[],QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean)"\]</dd><dt>  <a href="T_QRCoder_Core_QRCodeGenerator_EciMode.md">QRCodeGenerator.EciMode</a>  (Optional)</dt><dd>\[Missing &lt;param name="eciMode"/&gt; documentation for "M:QRCoder.Core.PngByteQRCodeHelper.GetQRCode(System.String,System.Int32,System.Byte[],System.Byte[],QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a>  (Optional)</dt><dd>\[Missing &lt;param name="requestedVersion"/&gt; documentation for "M:QRCoder.Core.PngByteQRCodeHelper.GetQRCode(System.String,System.Int32,System.Byte[],System.Byte[],QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>\[Missing &lt;param name="drawQuietZones"/&gt; documentation for "M:QRCoder.Core.PngByteQRCodeHelper.GetQRCode(System.String,System.Int32,System.Byte[],System.Byte[],QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean)"\]</dd></dl>

#### Return Value
<a href="https://learn.microsoft.com/dotnet/api/system.byte" target="_blank" rel="noopener noreferrer">Byte</a>[]  
\[Missing &lt;returns&gt; documentation for "M:QRCoder.Core.PngByteQRCodeHelper.GetQRCode(System.String,System.Int32,System.Byte[],System.Byte[],QRCoder.Core.QRCodeGenerator.ECCLevel,System.Boolean,System.Boolean,QRCoder.Core.QRCodeGenerator.EciMode,System.Int32,System.Boolean)"\]

## See Also


#### Reference
<a href="T_QRCoder_Core_PngByteQRCodeHelper.md">PngByteQRCodeHelper Class</a>  
<a href="Overload_QRCoder_Core_PngByteQRCodeHelper_GetQRCode.md">GetQRCode Overload</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  
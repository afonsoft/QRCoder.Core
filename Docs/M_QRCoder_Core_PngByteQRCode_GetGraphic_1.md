# GetGraphic(Int32, Byte[], Byte[], Boolean) Method


Creates 2-color PNG of the QR code, using 1-bit indexed color. Accepts 3-byte RGB colors for normal images and 4-byte RGBA-colors for transparent images.



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+4632349aa2a984532af965c24d83952cef07f5b3  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public byte[] GetGraphic(
	int pixelsPerModule,
	byte[] darkColorRgba,
	byte[] lightColorRgba,
	bool drawQuietZones = true
)
```
**C++**
``` C++
public:
array<unsigned char>^ GetGraphic(
	int pixelsPerModule, 
	array<unsigned char>^ darkColorRgba, 
	array<unsigned char>^ lightColorRgba, 
	bool drawQuietZones = true
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a></dt><dd>\[Missing &lt;param name="pixelsPerModule"/&gt; documentation for "M:QRCoder.Core.PngByteQRCode.GetGraphic(System.Int32,System.Byte[],System.Byte[],System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.byte" target="_blank" rel="noopener noreferrer">Byte</a>[]</dt><dd>\[Missing &lt;param name="darkColorRgba"/&gt; documentation for "M:QRCoder.Core.PngByteQRCode.GetGraphic(System.Int32,System.Byte[],System.Byte[],System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.byte" target="_blank" rel="noopener noreferrer">Byte</a>[]</dt><dd>\[Missing &lt;param name="lightColorRgba"/&gt; documentation for "M:QRCoder.Core.PngByteQRCode.GetGraphic(System.Int32,System.Byte[],System.Byte[],System.Boolean)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>\[Missing &lt;param name="drawQuietZones"/&gt; documentation for "M:QRCoder.Core.PngByteQRCode.GetGraphic(System.Int32,System.Byte[],System.Byte[],System.Boolean)"\]</dd></dl>

#### Return Value
<a href="https://learn.microsoft.com/dotnet/api/system.byte" target="_blank" rel="noopener noreferrer">Byte</a>[]  
\[Missing &lt;returns&gt; documentation for "M:QRCoder.Core.PngByteQRCode.GetGraphic(System.Int32,System.Byte[],System.Byte[],System.Boolean)"\]

## See Also


#### Reference
<a href="T_QRCoder_Core_PngByteQRCode.md">PngByteQRCode Class</a>  
<a href="Overload_QRCoder_Core_PngByteQRCode_GetGraphic.md">GetGraphic Overload</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

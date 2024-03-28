# CreateQrCode(String, QRCodeGenerator.ECCLevel, Boolean, Boolean, QRCodeGenerator.EciMode, Int32) Method


Calculates the QR code data which than can be used in one of the rendering classes to generate a graphical representation.



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+4632349aa2a984532af965c24d83952cef07f5b3  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public QRCodeData CreateQrCode(
	string plainText,
	QRCodeGenerator.ECCLevel eccLevel,
	bool forceUtf8 = false,
	bool utf8BOM = false,
	QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default,
	int requestedVersion = -1
)
```
**C++**
``` C++
public:
QRCodeData^ CreateQrCode(
	String^ plainText, 
	QRCodeGenerator.ECCLevel eccLevel, 
	bool forceUtf8 = false, 
	bool utf8BOM = false, 
	QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode::Default, 
	int requestedVersion = -1
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>The payload which shall be encoded in the QR code</dd><dt>  <a href="T_QRCoder_Core_QRCodeGenerator_ECCLevel.md">QRCodeGenerator.ECCLevel</a></dt><dd>The level of error correction data</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>Shall the generator be forced to work in UTF-8 mode?</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>Should the byte-order-mark be used?</dd><dt>  <a href="T_QRCoder_Core_QRCodeGenerator_EciMode.md">QRCodeGenerator.EciMode</a>  (Optional)</dt><dd>Which ECI mode shall be used?</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a>  (Optional)</dt><dd>Set fixed QR code target version.</dd></dl>

#### Return Value
<a href="T_QRCoder_Core_QRCodeData.md">QRCodeData</a>  
Returns the raw QR code data which can be used for rendering.

## Exceptions
<table>
<tr>
<td><a href="T_QRCoder_Core_Exceptions_DataTooLongException.md">DataTooLongException</a></td>
<td>Thrown when the payload is too big to be encoded in a QR code.</td></tr>
</table>

## See Also


#### Reference
<a href="T_QRCoder_Core_QRCodeGenerator.md">QRCodeGenerator Class</a>  
<a href="Overload_QRCoder_Core_QRCodeGenerator_CreateQrCode.md">CreateQrCode Overload</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

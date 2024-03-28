# GenerateQrCode(Byte[], QRCodeGenerator.ECCLevel) Method


Calculates the QR code data which than can be used in one of the rendering classes to generate a graphical representation.



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+4632349aa2a984532af965c24d83952cef07f5b3  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public static QRCodeData GenerateQrCode(
	byte[] binaryData,
	QRCodeGenerator.ECCLevel eccLevel
)
```
**C++**
``` C++
public:
static QRCodeData^ GenerateQrCode(
	array<unsigned char>^ binaryData, 
	QRCodeGenerator.ECCLevel eccLevel
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.byte" target="_blank" rel="noopener noreferrer">Byte</a>[]</dt><dd>A byte array which shall be encoded/stored in the QR code</dd><dt>  <a href="T_QRCoder_Core_QRCodeGenerator_ECCLevel.md">QRCodeGenerator.ECCLevel</a></dt><dd>The level of error correction data</dd></dl>

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
<a href="Overload_QRCoder_Core_QRCodeGenerator_GenerateQrCode.md">GenerateQrCode Overload</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

# PngByteQRCode Class


PngByteQRCode



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public sealed class PngByteQRCode : AbstractQRCode
```
**C++**
``` C++
public ref class PngByteQRCode sealed : public AbstractQRCode
```

<table><tr><td><strong>Inheritance</strong></td><td><a href="https://learn.microsoft.com/dotnet/api/system.object" target="_blank" rel="noopener noreferrer">Object</a>  →  <a href="T_QRCoder_Core_AbstractQRCode.md">AbstractQRCode</a>  →  PngByteQRCode</td></tr>
</table>



## Constructors
<table>
<tr>
<td><a href="M_QRCoder_Core_PngByteQRCode__ctor.md">PngByteQRCode()</a></td>
<td>Constructor without params to be used in COM Objects connections</td></tr>
<tr>
<td><a href="M_QRCoder_Core_PngByteQRCode__ctor_1.md">PngByteQRCode(QRCodeData)</a></td>
<td>Initializes a new instance of the PngByteQRCode class</td></tr>
</table>

## Methods
<table>
<tr>
<td><a href="M_QRCoder_Core_AbstractQRCode_Dispose.md">Dispose()</a></td>
<td>Dispose<br />(Inherited from <a href="T_QRCoder_Core_AbstractQRCode.md">AbstractQRCode</a>)</td></tr>
<tr>
<td><a href="https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object)" target="_blank" rel="noopener noreferrer">Equals</a></td>
<td>Determines whether the specified object is equal to the current object.<br />(Inherited from <a href="https://learn.microsoft.com/dotnet/api/system.object" target="_blank" rel="noopener noreferrer">Object</a>)</td></tr>
<tr>
<td><a href="M_QRCoder_Core_PngByteQRCode_GetGraphic.md">GetGraphic(Int32, Boolean)</a></td>
<td>Creates a black white PNG of the QR code, using 1-bit grayscale.</td></tr>
<tr>
<td><a href="M_QRCoder_Core_PngByteQRCode_GetGraphic_1.md">GetGraphic(Int32, Byte[], Byte[], Boolean)</a></td>
<td>Creates 2-color PNG of the QR code, using 1-bit indexed color. Accepts 3-byte RGB colors for normal images and 4-byte RGBA-colors for transparent images.</td></tr>
<tr>
<td><a href="https://learn.microsoft.com/dotnet/api/system.object.gethashcode" target="_blank" rel="noopener noreferrer">GetHashCode</a></td>
<td>Serves as the default hash function.<br />(Inherited from <a href="https://learn.microsoft.com/dotnet/api/system.object" target="_blank" rel="noopener noreferrer">Object</a>)</td></tr>
<tr>
<td><a href="https://learn.microsoft.com/dotnet/api/system.object.gettype" target="_blank" rel="noopener noreferrer">GetType</a></td>
<td>Gets the <a href="https://learn.microsoft.com/dotnet/api/system.type" target="_blank" rel="noopener noreferrer">Type</a> of the current instance.<br />(Inherited from <a href="https://learn.microsoft.com/dotnet/api/system.object" target="_blank" rel="noopener noreferrer">Object</a>)</td></tr>
<tr>
<td><a href="M_QRCoder_Core_AbstractQRCode_SetQRCodeData.md">SetQRCodeData</a></td>
<td>Set a QRCodeData object that will be used to generate QR code. Used in COM Objects connections<br />(Inherited from <a href="T_QRCoder_Core_AbstractQRCode.md">AbstractQRCode</a>)</td></tr>
<tr>
<td><a href="https://learn.microsoft.com/dotnet/api/system.object.tostring" target="_blank" rel="noopener noreferrer">ToString</a></td>
<td>Returns a string that represents the current object.<br />(Inherited from <a href="https://learn.microsoft.com/dotnet/api/system.object" target="_blank" rel="noopener noreferrer">Object</a>)</td></tr>
</table>

## See Also


#### Reference
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

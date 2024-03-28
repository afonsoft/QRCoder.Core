# SvgQRCode Class


SvgQRCode



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public class SvgQRCode : AbstractQRCode
```
**C++**
``` C++
public ref class SvgQRCode : public AbstractQRCode
```

<table><tr><td><strong>Inheritance</strong></td><td><a href="https://learn.microsoft.com/dotnet/api/system.object" target="_blank" rel="noopener noreferrer">Object</a>  →  <a href="T_QRCoder_Core_AbstractQRCode.md">AbstractQRCode</a>  →  SvgQRCode</td></tr>
</table>



## Constructors
<table>
<tr>
<td><a href="M_QRCoder_Core_SvgQRCode__ctor.md">SvgQRCode()</a></td>
<td>Constructor without params to be used in COM Objects connections</td></tr>
<tr>
<td><a href="M_QRCoder_Core_SvgQRCode__ctor_1.md">SvgQRCode(QRCodeData)</a></td>
<td>Initializes a new instance of the SvgQRCode class</td></tr>
</table>

## Properties
<table>
<tr>
<td><a href="P_QRCoder_Core_AbstractQRCode_QrCodeData.md">QrCodeData</a></td>
<td>QRCodeData<br />(Inherited from <a href="T_QRCoder_Core_AbstractQRCode.md">AbstractQRCode</a>)</td></tr>
</table>

## Methods
<table>
<tr>
<td><a href="M_QRCoder_Core_AbstractQRCode_Dispose.md">Dispose()</a></td>
<td>Dispose<br />(Inherited from <a href="T_QRCoder_Core_AbstractQRCode.md">AbstractQRCode</a>)</td></tr>
<tr>
<td><a href="M_QRCoder_Core_AbstractQRCode_Dispose_1.md">Dispose(Boolean)</a></td>
<td><br />(Inherited from <a href="T_QRCoder_Core_AbstractQRCode.md">AbstractQRCode</a>)</td></tr>
<tr>
<td><a href="https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object)" target="_blank" rel="noopener noreferrer">Equals</a></td>
<td>Determines whether the specified object is equal to the current object.<br />(Inherited from <a href="https://learn.microsoft.com/dotnet/api/system.object" target="_blank" rel="noopener noreferrer">Object</a>)</td></tr>
<tr>
<td><a href="M_QRCoder_Core_AbstractQRCode_Finalize.md">Finalize</a></td>
<td><br />(Inherited from <a href="T_QRCoder_Core_AbstractQRCode.md">AbstractQRCode</a>)</td></tr>
<tr>
<td><a href="M_QRCoder_Core_SvgQRCode_GetGraphic_3.md">GetGraphic(Int32)</a></td>
<td>Returns a QR code as SVG string</td></tr>
<tr>
<td><a href="M_QRCoder_Core_SvgQRCode_GetGraphic.md">GetGraphic(Size, Boolean, SvgQRCode.SizingMode, SvgQRCode.SvgLogo)</a></td>
<td>Returns a QR code as SVG string with optional quietzone and logo</td></tr>
<tr>
<td><a href="M_QRCoder_Core_SvgQRCode_GetGraphic_4.md">GetGraphic(Int32, Color, Color, Boolean, SvgQRCode.SizingMode, SvgQRCode.SvgLogo)</a></td>
<td>Returns a QR code as SVG string with custom colors, optional quietzone and logo</td></tr>
<tr>
<td><a href="M_QRCoder_Core_SvgQRCode_GetGraphic_5.md">GetGraphic(Int32, String, String, Boolean, SvgQRCode.SizingMode, SvgQRCode.SvgLogo)</a></td>
<td>Returns a QR code as SVG string with custom colors (in HEX syntax), optional quietzone and logo</td></tr>
<tr>
<td><a href="M_QRCoder_Core_SvgQRCode_GetGraphic_1.md">GetGraphic(Size, Color, Color, Boolean, SvgQRCode.SizingMode, SvgQRCode.SvgLogo)</a></td>
<td>Returns a QR code as SVG string with custom colors and optional quietzone and logo</td></tr>
<tr>
<td><a href="M_QRCoder_Core_SvgQRCode_GetGraphic_2.md">GetGraphic(Size, String, String, Boolean, SvgQRCode.SizingMode, SvgQRCode.SvgLogo)</a></td>
<td>Returns a QR code as SVG string with custom colors (in HEX syntax), optional quietzone and logo</td></tr>
<tr>
<td><a href="https://learn.microsoft.com/dotnet/api/system.object.gethashcode" target="_blank" rel="noopener noreferrer">GetHashCode</a></td>
<td>Serves as the default hash function.<br />(Inherited from <a href="https://learn.microsoft.com/dotnet/api/system.object" target="_blank" rel="noopener noreferrer">Object</a>)</td></tr>
<tr>
<td><a href="https://learn.microsoft.com/dotnet/api/system.object.gettype" target="_blank" rel="noopener noreferrer">GetType</a></td>
<td>Gets the <a href="https://learn.microsoft.com/dotnet/api/system.type" target="_blank" rel="noopener noreferrer">Type</a> of the current instance.<br />(Inherited from <a href="https://learn.microsoft.com/dotnet/api/system.object" target="_blank" rel="noopener noreferrer">Object</a>)</td></tr>
<tr>
<td><a href="https://learn.microsoft.com/dotnet/api/system.object.memberwiseclone" target="_blank" rel="noopener noreferrer">MemberwiseClone</a></td>
<td>Creates a shallow copy of the current <a href="https://learn.microsoft.com/dotnet/api/system.object" target="_blank" rel="noopener noreferrer">Object</a>.<br />(Inherited from <a href="https://learn.microsoft.com/dotnet/api/system.object" target="_blank" rel="noopener noreferrer">Object</a>)</td></tr>
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

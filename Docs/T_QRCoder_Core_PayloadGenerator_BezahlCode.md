# PayloadGenerator.BezahlCode Class


\[Missing &lt;summary&gt; documentation for "T:QRCoder.Core.PayloadGenerator.BezahlCode"\]



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public class BezahlCode : PayloadGenerator.Payload
```
**C++**
``` C++
public ref class BezahlCode : public PayloadGenerator.Payload
```

<table><tr><td><strong>Inheritance</strong></td><td><a href="https://learn.microsoft.com/dotnet/api/system.object" target="_blank" rel="noopener noreferrer">Object</a>  →  <a href="T_QRCoder_Core_PayloadGenerator_Payload.md">PayloadGenerator.Payload</a>  →  PayloadGenerator.BezahlCode</td></tr>
</table>



## Constructors
<table>
<tr>
<td><a href="M_QRCoder_Core_PayloadGenerator_BezahlCode__ctor_3.md">PayloadGenerator.BezahlCode(PayloadGenerator.BezahlCode.AuthorityType, String, String, String, String, String, String)</a></td>
<td>Constructor for contact data</td></tr>
<tr>
<td><a href="M_QRCoder_Core_PayloadGenerator_BezahlCode__ctor.md">PayloadGenerator.BezahlCode(PayloadGenerator.BezahlCode.AuthorityType, String, String, String, Decimal, String, Int32, Nullable(DateTime), Nullable(DateTime), String, Int32, PayloadGenerator.BezahlCode.Currency, Nullable(DateTime))</a></td>
<td>Constructor for non-SEPA payments</td></tr>
<tr>
<td><a href="M_QRCoder_Core_PayloadGenerator_BezahlCode__ctor_1.md">PayloadGenerator.BezahlCode(PayloadGenerator.BezahlCode.AuthorityType, String, String, String, Decimal, String, Int32, Nullable(DateTime), Nullable(DateTime), String, String, Nullable(DateTime), String, String, PayloadGenerator.BezahlCode.Currency, Nullable(DateTime))</a></td>
<td>Constructor for SEPA payments</td></tr>
<tr>
<td><a href="M_QRCoder_Core_PayloadGenerator_BezahlCode__ctor_2.md">PayloadGenerator.BezahlCode(PayloadGenerator.BezahlCode.AuthorityType, String, String, String, String, String, Decimal, String, Int32, Nullable(DateTime), Nullable(DateTime), String, String, Nullable(DateTime), String, Int32, String, PayloadGenerator.BezahlCode.Currency, Nullable(DateTime), Int32)</a></td>
<td>Generic constructor. Please use specific (non-SEPA or SEPA) constructor</td></tr>
</table>

## Properties
<table>
<tr>
<td><a href="P_QRCoder_Core_PayloadGenerator_Payload_EccLevel.md">EccLevel</a></td>
<td>ECCLevel<br />(Inherited from <a href="T_QRCoder_Core_PayloadGenerator_Payload.md">PayloadGenerator.Payload</a>)</td></tr>
<tr>
<td><a href="P_QRCoder_Core_PayloadGenerator_Payload_EciMode.md">EciMode</a></td>
<td>EciMode<br />(Inherited from <a href="T_QRCoder_Core_PayloadGenerator_Payload.md">PayloadGenerator.Payload</a>)</td></tr>
<tr>
<td><a href="P_QRCoder_Core_PayloadGenerator_Payload_Version.md">Version</a></td>
<td>Version<br />(Inherited from <a href="T_QRCoder_Core_PayloadGenerator_Payload.md">PayloadGenerator.Payload</a>)</td></tr>
</table>

## Methods
<table>
<tr>
<td><a href="https://learn.microsoft.com/dotnet/api/system.object.equals#system-object-equals(system-object)" target="_blank" rel="noopener noreferrer">Equals</a></td>
<td>Determines whether the specified object is equal to the current object.<br />(Inherited from <a href="https://learn.microsoft.com/dotnet/api/system.object" target="_blank" rel="noopener noreferrer">Object</a>)</td></tr>
<tr>
<td><a href="https://learn.microsoft.com/dotnet/api/system.object.finalize" target="_blank" rel="noopener noreferrer">Finalize</a></td>
<td>Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.<br />(Inherited from <a href="https://learn.microsoft.com/dotnet/api/system.object" target="_blank" rel="noopener noreferrer">Object</a>)</td></tr>
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
<td><a href="M_QRCoder_Core_PayloadGenerator_BezahlCode_ToString.md">ToString</a></td>
<td><br />(Overrides <a href="M_QRCoder_Core_PayloadGenerator_Payload_ToString.md">PayloadGenerator.Payload.ToString()</a>)</td></tr>
</table>

## See Also


#### Reference
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

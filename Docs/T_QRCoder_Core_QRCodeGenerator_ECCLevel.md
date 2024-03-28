# QRCodeGenerator.ECCLevel Enumeration


Error correction level. These define the tolerance levels for how much of the code can be lost before the code cannot be recovered.



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+4632349aa2a984532af965c24d83952cef07f5b3  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public enum ECCLevel
```
**C++**
``` C++
public enum class ECCLevel
```



## Members
<table>
<tr>
<td>L</td>
<td>0</td>
<td>7% may be lost before recovery is not possible</td></tr>
<tr>
<td>M</td>
<td>1</td>
<td>15% may be lost before recovery is not possible</td></tr>
<tr>
<td>Q</td>
<td>2</td>
<td>25% may be lost before recovery is not possible</td></tr>
<tr>
<td>H</td>
<td>3</td>
<td>30% may be lost before recovery is not possible</td></tr>
</table>

## See Also


#### Reference
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

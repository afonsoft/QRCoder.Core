# PayloadGenerator.BezahlCode.AuthorityType Enumeration


Operation modes of the BezahlCode



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+4632349aa2a984532af965c24d83952cef07f5b3  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public enum AuthorityType
```
**C++**
``` C++
public enum class AuthorityType
```



## Members
<table>
<tr>
<td>singlepayment</td>
<td>0</td>
<td>Single payment (Überweisung)<br /><strong>Obsolete.</strong></td></tr>
<tr>
<td>singlepaymentsepa</td>
<td>1</td>
<td>Single SEPA payment (SEPA-Überweisung)</td></tr>
<tr>
<td>singledirectdebit</td>
<td>2</td>
<td>Single debit (Lastschrift)<br /><strong>Obsolete.</strong></td></tr>
<tr>
<td>singledirectdebitsepa</td>
<td>3</td>
<td>Single SEPA debit (SEPA-Lastschrift)</td></tr>
<tr>
<td>periodicsinglepayment</td>
<td>4</td>
<td>Periodic payment (Dauerauftrag)<br /><strong>Obsolete.</strong></td></tr>
<tr>
<td>periodicsinglepaymentsepa</td>
<td>5</td>
<td>Periodic SEPA payment (SEPA-Dauerauftrag)</td></tr>
<tr>
<td>contact</td>
<td>6</td>
<td>Contact data</td></tr>
<tr>
<td>contact_v2</td>
<td>7</td>
<td>Contact data V2</td></tr>
</table>

## See Also


#### Reference
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

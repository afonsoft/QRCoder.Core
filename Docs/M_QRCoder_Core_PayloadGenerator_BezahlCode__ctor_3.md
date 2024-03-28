# PayloadGenerator.BezahlCode(PayloadGenerator.BezahlCode.AuthorityType, String, String, String, String, String, String) Constructor


Constructor for contact data



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public BezahlCode(
	PayloadGenerator.BezahlCode.AuthorityType authority,
	string name,
	string account = "",
	string bnc = "",
	string iban = "",
	string bic = "",
	string reason = ""
)
```
**C++**
``` C++
public:
BezahlCode(
	PayloadGenerator.BezahlCode.AuthorityType authority, 
	String^ name, 
	String^ account = L"", 
	String^ bnc = L"", 
	String^ iban = L"", 
	String^ bic = L"", 
	String^ reason = L""
)
```



#### Parameters
<dl><dt>  <a href="T_QRCoder_Core_PayloadGenerator_BezahlCode_AuthorityType.md">PayloadGenerator.BezahlCode.AuthorityType</a></dt><dd>Type of the bank transfer</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Name of the receiver (Empfänger)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Bank account (Kontonummer)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Bank institute (Bankleitzahl)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>IBAN</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>BIC</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Reason (Verwendungszweck)</dd></dl>

## See Also


#### Reference
<a href="T_QRCoder_Core_PayloadGenerator_BezahlCode.md">PayloadGenerator.BezahlCode Class</a>  
<a href="Overload_QRCoder_Core_PayloadGenerator_BezahlCode__ctor.md">PayloadGenerator.BezahlCode Overload</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

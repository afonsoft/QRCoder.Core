# PayloadGenerator.Girocode Constructor


Generates the payload for a Girocode (QR-Code with credit transfer information). Attention: When using Girocode payload, QR code must be generated with ECC level M!



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public Girocode(
	string iban,
	string bic,
	string name,
	decimal amount,
	string remittanceInformation = "",
	PayloadGenerator.Girocode.TypeOfRemittance typeOfRemittance = PayloadGenerator.Girocode.TypeOfRemittance.Unstructured,
	string purposeOfCreditTransfer = "",
	string messageToGirocodeUser = "",
	PayloadGenerator.Girocode.GirocodeVersion version = PayloadGenerator.Girocode.GirocodeVersion.Version1,
	PayloadGenerator.Girocode.GirocodeEncoding encoding = PayloadGenerator.Girocode.GirocodeEncoding.ISO_8859_1
)
```
**C++**
``` C++
public:
Girocode(
	String^ iban, 
	String^ bic, 
	String^ name, 
	Decimal amount, 
	String^ remittanceInformation = L"", 
	PayloadGenerator.Girocode.TypeOfRemittance typeOfRemittance = PayloadGenerator.Girocode.TypeOfRemittance::Unstructured, 
	String^ purposeOfCreditTransfer = L"", 
	String^ messageToGirocodeUser = L"", 
	PayloadGenerator.Girocode.GirocodeVersion version = PayloadGenerator.Girocode.GirocodeVersion::Version1, 
	PayloadGenerator.Girocode.GirocodeEncoding encoding = PayloadGenerator.Girocode.GirocodeEncoding::ISO_8859_1
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Account number of the Beneficiary. Only IBAN is allowed.</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>BIC of the Beneficiary Bank.</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Name of the Beneficiary.</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.decimal" target="_blank" rel="noopener noreferrer">Decimal</a></dt><dd>Amount of the Credit Transfer in Euro. (Amount must be more than 0.01 and less than 999999999.99)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Remittance Information (Purpose-/reference text). (optional)</dd><dt>  <a href="T_QRCoder_Core_PayloadGenerator_Girocode_TypeOfRemittance.md">PayloadGenerator.Girocode.TypeOfRemittance</a>  (Optional)</dt><dd>Type of remittance information. Either structured (e.g. ISO 11649 RF Creditor Reference) and max. 35 chars or unstructured and max. 140 chars.</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Purpose of the Credit Transfer (optional)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Beneficiary to originator information. (optional)</dd><dt>  <a href="T_QRCoder_Core_PayloadGenerator_Girocode_GirocodeVersion.md">PayloadGenerator.Girocode.GirocodeVersion</a>  (Optional)</dt><dd>Girocode version. Either 001 or 002. Default: 001.</dd><dt>  <a href="T_QRCoder_Core_PayloadGenerator_Girocode_GirocodeEncoding.md">PayloadGenerator.Girocode.GirocodeEncoding</a>  (Optional)</dt><dd>Encoding of the Girocode payload. Default: ISO-8859-1</dd></dl>

## See Also


#### Reference
<a href="T_QRCoder_Core_PayloadGenerator_Girocode.md">PayloadGenerator.Girocode Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

# PayloadGenerator.SwissQrCode Constructor


Generates the payload for a SwissQrCode v2.0. (Don't forget to use ECC-Level=M, EncodingMode=UTF-8 and to set the Swiss flag icon to the final QR code.)



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public SwissQrCode(
	PayloadGenerator.SwissQrCode.Iban iban,
	PayloadGenerator.SwissQrCode.Currency currency,
	PayloadGenerator.SwissQrCode.Contact creditor,
	PayloadGenerator.SwissQrCode.Reference reference,
	PayloadGenerator.SwissQrCode.AdditionalInformation additionalInformation = null,
	PayloadGenerator.SwissQrCode.Contact debitor = null,
	decimal? amount = null,
	DateTime? requestedDateOfPayment = null,
	PayloadGenerator.SwissQrCode.Contact ultimateCreditor = null,
	string alternativeProcedure1 = null,
	string alternativeProcedure2 = null
)
```
**C++**
``` C++
public:
SwissQrCode(
	PayloadGenerator.SwissQrCode.Iban^ iban, 
	PayloadGenerator.SwissQrCode.Currency currency, 
	PayloadGenerator.SwissQrCode.Contact^ creditor, 
	PayloadGenerator.SwissQrCode.Reference^ reference, 
	PayloadGenerator.SwissQrCode.AdditionalInformation^ additionalInformation = nullptr, 
	PayloadGenerator.SwissQrCode.Contact^ debitor = nullptr, 
	Nullable<Decimal> amount = nullptr, 
	Nullable<DateTime> requestedDateOfPayment = nullptr, 
	PayloadGenerator.SwissQrCode.Contact^ ultimateCreditor = nullptr, 
	String^ alternativeProcedure1 = nullptr, 
	String^ alternativeProcedure2 = nullptr
)
```



#### Parameters
<dl><dt>  <a href="T_QRCoder_Core_PayloadGenerator_SwissQrCode_Iban.md">PayloadGenerator.SwissQrCode.Iban</a></dt><dd>IBAN object</dd><dt>  <a href="T_QRCoder_Core_PayloadGenerator_SwissQrCode_Currency.md">PayloadGenerator.SwissQrCode.Currency</a></dt><dd>Currency (either EUR or CHF)</dd><dt>  <a href="T_QRCoder_Core_PayloadGenerator_SwissQrCode_Contact.md">PayloadGenerator.SwissQrCode.Contact</a></dt><dd>Creditor (payee) information</dd><dt>  <a href="T_QRCoder_Core_PayloadGenerator_SwissQrCode_Reference.md">PayloadGenerator.SwissQrCode.Reference</a></dt><dd>Reference information</dd><dt>  <a href="T_QRCoder_Core_PayloadGenerator_SwissQrCode_AdditionalInformation.md">PayloadGenerator.SwissQrCode.AdditionalInformation</a>  (Optional)</dt><dd>\[Missing &lt;param name="additionalInformation"/&gt; documentation for "M:QRCoder.Core.PayloadGenerator.SwissQrCode.#ctor(QRCoder.Core.PayloadGenerator.SwissQrCode.Iban,QRCoder.Core.PayloadGenerator.SwissQrCode.Currency,QRCoder.Core.PayloadGenerator.SwissQrCode.Contact,QRCoder.Core.PayloadGenerator.SwissQrCode.Reference,QRCoder.Core.PayloadGenerator.SwissQrCode.AdditionalInformation,QRCoder.Core.PayloadGenerator.SwissQrCode.Contact,System.Nullable{System.Decimal},System.Nullable{System.DateTime},QRCoder.Core.PayloadGenerator.SwissQrCode.Contact,System.String,System.String)"\]</dd><dt>  <a href="T_QRCoder_Core_PayloadGenerator_SwissQrCode_Contact.md">PayloadGenerator.SwissQrCode.Contact</a>  (Optional)</dt><dd>Debitor (payer) information</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.nullable-1" target="_blank" rel="noopener noreferrer">Nullable</a>(<a href="https://learn.microsoft.com/dotnet/api/system.decimal" target="_blank" rel="noopener noreferrer">Decimal</a>)  (Optional)</dt><dd>Amount</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.nullable-1" target="_blank" rel="noopener noreferrer">Nullable</a>(<a href="https://learn.microsoft.com/dotnet/api/system.datetime" target="_blank" rel="noopener noreferrer">DateTime</a>)  (Optional)</dt><dd>Requested date of debitor's payment</dd><dt>  <a href="T_QRCoder_Core_PayloadGenerator_SwissQrCode_Contact.md">PayloadGenerator.SwissQrCode.Contact</a>  (Optional)</dt><dd>Ultimate creditor information (use only in consultation with your bank - for future use only!)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Optional command for alternative processing mode - line 1</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Optional command for alternative processing mode - line 2</dd></dl>

## See Also


#### Reference
<a href="T_QRCoder_Core_PayloadGenerator_SwissQrCode.md">PayloadGenerator.SwissQrCode Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

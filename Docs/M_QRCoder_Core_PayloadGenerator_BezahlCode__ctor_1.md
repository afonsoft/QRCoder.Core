# PayloadGenerator.BezahlCode(PayloadGenerator.BezahlCode.AuthorityType, String, String, String, Decimal, String, Int32, Nullable&lt;DateTime&gt;, Nullable&lt;DateTime&gt;, String, String, Nullable&lt;DateTime&gt;, String, String, PayloadGenerator.BezahlCode.Currency, Nullable&lt;DateTime&gt;) Constructor


Constructor for SEPA payments



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public BezahlCode(
	PayloadGenerator.BezahlCode.AuthorityType authority,
	string name,
	string iban,
	string bic,
	decimal amount,
	string periodicTimeunit = "",
	int periodicTimeunitRotation = 0,
	DateTime? periodicFirstExecutionDate = null,
	DateTime? periodicLastExecutionDate = null,
	string creditorId = "",
	string mandateId = "",
	DateTime? dateOfSignature = null,
	string reason = "",
	string sepaReference = "",
	PayloadGenerator.BezahlCode.Currency currency = PayloadGenerator.BezahlCode.Currency.EUR,
	DateTime? executionDate = null
)
```
**C++**
``` C++
public:
BezahlCode(
	PayloadGenerator.BezahlCode.AuthorityType authority, 
	String^ name, 
	String^ iban, 
	String^ bic, 
	Decimal amount, 
	String^ periodicTimeunit = L"", 
	int periodicTimeunitRotation = 0, 
	Nullable<DateTime> periodicFirstExecutionDate = nullptr, 
	Nullable<DateTime> periodicLastExecutionDate = nullptr, 
	String^ creditorId = L"", 
	String^ mandateId = L"", 
	Nullable<DateTime> dateOfSignature = nullptr, 
	String^ reason = L"", 
	String^ sepaReference = L"", 
	PayloadGenerator.BezahlCode.Currency currency = PayloadGenerator.BezahlCode.Currency::EUR, 
	Nullable<DateTime> executionDate = nullptr
)
```



#### Parameters
<dl><dt>  <a href="T_QRCoder_Core_PayloadGenerator_BezahlCode_AuthorityType.md">PayloadGenerator.BezahlCode.AuthorityType</a></dt><dd>Type of the bank transfer</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Name of the receiver (Empfänger)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>IBAN</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>BIC</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.decimal" target="_blank" rel="noopener noreferrer">Decimal</a></dt><dd>Amount (Betrag)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Unit of intervall for payment ('M' = monthly, 'W' = weekly)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a>  (Optional)</dt><dd>Intervall for payment. This value is combined with 'periodicTimeunit'</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.nullable-1" target="_blank" rel="noopener noreferrer">Nullable</a>(<a href="https://learn.microsoft.com/dotnet/api/system.datetime" target="_blank" rel="noopener noreferrer">DateTime</a>)  (Optional)</dt><dd>Date of first periodic execution</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.nullable-1" target="_blank" rel="noopener noreferrer">Nullable</a>(<a href="https://learn.microsoft.com/dotnet/api/system.datetime" target="_blank" rel="noopener noreferrer">DateTime</a>)  (Optional)</dt><dd>Date of last periodic execution</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Creditor id (Gläubiger ID)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Manadate id (Mandatsreferenz)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.nullable-1" target="_blank" rel="noopener noreferrer">Nullable</a>(<a href="https://learn.microsoft.com/dotnet/api/system.datetime" target="_blank" rel="noopener noreferrer">DateTime</a>)  (Optional)</dt><dd>Signature date (Erteilungsdatum des Mandats)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Reason (Verwendungszweck)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>SEPA reference (SEPA-Referenz)</dd><dt>  <a href="T_QRCoder_Core_PayloadGenerator_BezahlCode_Currency.md">PayloadGenerator.BezahlCode.Currency</a>  (Optional)</dt><dd>Currency (Währung)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.nullable-1" target="_blank" rel="noopener noreferrer">Nullable</a>(<a href="https://learn.microsoft.com/dotnet/api/system.datetime" target="_blank" rel="noopener noreferrer">DateTime</a>)  (Optional)</dt><dd>Execution date (Ausführungsdatum)</dd></dl>

## See Also


#### Reference
<a href="T_QRCoder_Core_PayloadGenerator_BezahlCode.md">PayloadGenerator.BezahlCode Class</a>  
<a href="Overload_QRCoder_Core_PayloadGenerator_BezahlCode__ctor.md">PayloadGenerator.BezahlCode Overload</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

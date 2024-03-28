# PayloadGenerator.RussiaPaymentOrder Constructor


Generates a RussiaPaymentOrder payload



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+4632349aa2a984532af965c24d83952cef07f5b3  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public RussiaPaymentOrder(
	string name,
	string personalAcc,
	string bankName,
	string BIC,
	string correspAcc,
	PayloadGenerator.RussiaPaymentOrder.OptionalFields optionalFields = null,
	PayloadGenerator.RussiaPaymentOrder.CharacterSets characterSet = PayloadGenerator.RussiaPaymentOrder.CharacterSets.utf_8
)
```
**C++**
``` C++
public:
RussiaPaymentOrder(
	String^ name, 
	String^ personalAcc, 
	String^ bankName, 
	String^ BIC, 
	String^ correspAcc, 
	PayloadGenerator.RussiaPaymentOrder.OptionalFields^ optionalFields = nullptr, 
	PayloadGenerator.RussiaPaymentOrder.CharacterSets characterSet = PayloadGenerator.RussiaPaymentOrder.CharacterSets::utf_8
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Name of the payee (Наименование получателя платежа)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Beneficiary account number (Номер счета получателя платежа)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Name of the beneficiary's bank (Наименование банка получателя платежа)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>BIC (БИК)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Box number / account payee's bank (Номер кор./сч. банка получателя платежа)</dd><dt>  <a href="T_QRCoder_Core_PayloadGenerator_RussiaPaymentOrder_OptionalFields.md">PayloadGenerator.RussiaPaymentOrder.OptionalFields</a>  (Optional)</dt><dd>An (optional) object of additional fields</dd><dt>  <a href="T_QRCoder_Core_PayloadGenerator_RussiaPaymentOrder_CharacterSets.md">PayloadGenerator.RussiaPaymentOrder.CharacterSets</a>  (Optional)</dt><dd>Type of encoding (default UTF-8)</dd></dl>

## See Also


#### Reference
<a href="T_QRCoder_Core_PayloadGenerator_RussiaPaymentOrder.md">PayloadGenerator.RussiaPaymentOrder Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

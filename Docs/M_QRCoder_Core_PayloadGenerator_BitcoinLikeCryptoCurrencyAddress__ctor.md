# PayloadGenerator.BitcoinLikeCryptoCurrencyAddress Constructor


Generates a Bitcoin like cryptocurrency payment payload. QR Codes with this payload can open a payment app.



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public BitcoinLikeCryptoCurrencyAddress(
	PayloadGenerator.BitcoinLikeCryptoCurrencyAddress.BitcoinLikeCryptoCurrencyType currencyType,
	string address,
	double? amount,
	string label = null,
	string message = null
)
```
**C++**
``` C++
public:
BitcoinLikeCryptoCurrencyAddress(
	PayloadGenerator.BitcoinLikeCryptoCurrencyAddress.BitcoinLikeCryptoCurrencyType currencyType, 
	String^ address, 
	Nullable<double> amount, 
	String^ label = nullptr, 
	String^ message = nullptr
)
```



#### Parameters
<dl><dt>  <a href="T_QRCoder_Core_PayloadGenerator_BitcoinLikeCryptoCurrencyAddress_BitcoinLikeCryptoCurrencyType.md">PayloadGenerator.BitcoinLikeCryptoCurrencyAddress.BitcoinLikeCryptoCurrencyType</a></dt><dd>Bitcoin like cryptocurrency address of the payment receiver</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Bitcoin like cryptocurrency address of the payment receiver</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.nullable-1" target="_blank" rel="noopener noreferrer">Nullable</a>(<a href="https://learn.microsoft.com/dotnet/api/system.double" target="_blank" rel="noopener noreferrer">Double</a>)</dt><dd>Amount of coins to transfer</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Reference label</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Referece text aka message</dd></dl>

## See Also


#### Reference
<a href="T_QRCoder_Core_PayloadGenerator_BitcoinLikeCryptoCurrencyAddress.md">PayloadGenerator.BitcoinLikeCryptoCurrencyAddress Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

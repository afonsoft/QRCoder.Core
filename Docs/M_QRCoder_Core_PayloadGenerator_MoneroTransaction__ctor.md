# PayloadGenerator.MoneroTransaction Constructor


Creates a monero transaction payload



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public MoneroTransaction(
	string address,
	float? txAmount = null,
	string txPaymentId = null,
	string recipientName = null,
	string txDescription = null
)
```
**C++**
``` C++
public:
MoneroTransaction(
	String^ address, 
	Nullable<float> txAmount = nullptr, 
	String^ txPaymentId = nullptr, 
	String^ recipientName = nullptr, 
	String^ txDescription = nullptr
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Receiver's monero address</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.nullable-1" target="_blank" rel="noopener noreferrer">Nullable</a>(<a href="https://learn.microsoft.com/dotnet/api/system.single" target="_blank" rel="noopener noreferrer">Single</a>)  (Optional)</dt><dd>Amount to transfer</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Payment id</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Receipient's name</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Reference text / payment description</dd></dl>

## See Also


#### Reference
<a href="T_QRCoder_Core_PayloadGenerator_MoneroTransaction.md">PayloadGenerator.MoneroTransaction Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

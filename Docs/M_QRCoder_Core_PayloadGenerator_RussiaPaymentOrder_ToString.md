# ToString Method


Returns payload as string.



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+4632349aa2a984532af965c24d83952cef07f5b3  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public override string ToString()
```
**C++**
``` C++
public:
virtual String^ ToString() override
```



#### Return Value
<a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  
\[Missing &lt;returns&gt; documentation for "M:QRCoder.Core.PayloadGenerator.RussiaPaymentOrder.ToString"\]

## Remarks
⚠ Attention: If CharacterSets was set to windows-1251 or koi8-r you should use ToBytes() instead of ToString() and pass the bytes to CreateQrCode()!

## See Also


#### Reference
<a href="T_QRCoder_Core_PayloadGenerator_RussiaPaymentOrder.md">PayloadGenerator.RussiaPaymentOrder Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

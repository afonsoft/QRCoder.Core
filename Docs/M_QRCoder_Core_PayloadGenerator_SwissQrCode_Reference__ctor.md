# PayloadGenerator.SwissQrCode.Reference Constructor


Creates a reference object which must be passed to the SwissQrCode instance



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+4632349aa2a984532af965c24d83952cef07f5b3  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public Reference(
	PayloadGenerator.SwissQrCode.Reference.ReferenceType referenceType,
	string reference = null,
	PayloadGenerator.SwissQrCode.Reference.ReferenceTextType? referenceTextType = null
)
```
**C++**
``` C++
public:
Reference(
	PayloadGenerator.SwissQrCode.Reference.ReferenceType referenceType, 
	String^ reference = nullptr, 
	Nullable<PayloadGenerator.SwissQrCode.Reference.ReferenceTextType> referenceTextType = nullptr
)
```



#### Parameters
<dl><dt>  <a href="T_QRCoder_Core_PayloadGenerator_SwissQrCode_Reference_ReferenceType.md">PayloadGenerator.SwissQrCode.Reference.ReferenceType</a></dt><dd>Type of the reference (QRR, SCOR or NON)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Reference text</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.nullable-1" target="_blank" rel="noopener noreferrer">Nullable</a>(<a href="T_QRCoder_Core_PayloadGenerator_SwissQrCode_Reference_ReferenceTextType.md">PayloadGenerator.SwissQrCode.Reference.ReferenceTextType</a>)  (Optional)</dt><dd>Type of the reference text (QR-reference or Creditor Reference)</dd></dl>

## See Also


#### Reference
<a href="T_QRCoder_Core_PayloadGenerator_SwissQrCode_Reference.md">PayloadGenerator.SwissQrCode.Reference Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

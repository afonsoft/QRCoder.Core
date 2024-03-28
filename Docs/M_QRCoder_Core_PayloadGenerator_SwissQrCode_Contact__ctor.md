# PayloadGenerator.SwissQrCode.Contact(String, String, String, String) Constructor
<blockquote><strong>Note: This API is now obsolete.</strong></blockquote>




Contact type. Can be used for payee, ultimate payee, etc. with address in combined mode (K).



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+4632349aa2a984532af965c24d83952cef07f5b3  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
[ObsoleteAttribute("This constructor is deprecated. Use WithCombinedAddress instead.")]
public Contact(
	string name,
	string country,
	string addressLine1,
	string addressLine2
)
```
**C++**
``` C++
public:
[ObsoleteAttribute(L"This constructor is deprecated. Use WithCombinedAddress instead.")]
Contact(
	String^ name, 
	String^ country, 
	String^ addressLine1, 
	String^ addressLine2
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Last name or company (optional first name)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Two-letter country code as defined in ISO 3166-1</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Adress line 1</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Adress line 2</dd></dl>

## See Also


#### Reference
<a href="T_QRCoder_Core_PayloadGenerator_SwissQrCode_Contact.md">PayloadGenerator.SwissQrCode.Contact Class</a>  
<a href="Overload_QRCoder_Core_PayloadGenerator_SwissQrCode_Contact__ctor.md">PayloadGenerator.SwissQrCode.Contact Overload</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

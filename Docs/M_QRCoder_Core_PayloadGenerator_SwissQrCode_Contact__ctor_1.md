# PayloadGenerator.SwissQrCode.Contact(String, String, String, String, String, String) Constructor
<blockquote><strong>Note: This API is now obsolete.</strong></blockquote>




Contact type. Can be used for payee, ultimate payee, etc. with address in structured mode (S).



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
[ObsoleteAttribute("This constructor is deprecated. Use WithStructuredAddress instead.")]
public Contact(
	string name,
	string zipCode,
	string city,
	string country,
	string street = null,
	string houseNumber = null
)
```
**C++**
``` C++
public:
[ObsoleteAttribute(L"This constructor is deprecated. Use WithStructuredAddress instead.")]
Contact(
	String^ name, 
	String^ zipCode, 
	String^ city, 
	String^ country, 
	String^ street = nullptr, 
	String^ houseNumber = nullptr
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Last name or company (optional first name)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Zip-/Postcode</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>City name</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Two-letter country code as defined in ISO 3166-1</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Streetname without house number</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>House number</dd></dl>

## See Also


#### Reference
<a href="T_QRCoder_Core_PayloadGenerator_SwissQrCode_Contact.md">PayloadGenerator.SwissQrCode.Contact Class</a>  
<a href="Overload_QRCoder_Core_PayloadGenerator_SwissQrCode_Contact__ctor.md">PayloadGenerator.SwissQrCode.Contact Overload</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

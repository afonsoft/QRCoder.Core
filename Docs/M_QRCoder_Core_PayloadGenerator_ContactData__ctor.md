# PayloadGenerator.ContactData Constructor


Generates a vCard or meCard contact dataset



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public ContactData(
	PayloadGenerator.ContactData.ContactOutputType outputType,
	string firstname,
	string lastname,
	string nickname = null,
	string phone = null,
	string mobilePhone = null,
	string workPhone = null,
	string email = null,
	DateTime? birthday = null,
	string website = null,
	string street = null,
	string houseNumber = null,
	string city = null,
	string zipCode = null,
	string country = null,
	string note = null,
	string stateRegion = null,
	PayloadGenerator.ContactData.AddressOrder addressOrder = PayloadGenerator.ContactData.AddressOrder.Default,
	string org = null,
	string orgTitle = null
)
```
**C++**
``` C++
public:
ContactData(
	PayloadGenerator.ContactData.ContactOutputType outputType, 
	String^ firstname, 
	String^ lastname, 
	String^ nickname = nullptr, 
	String^ phone = nullptr, 
	String^ mobilePhone = nullptr, 
	String^ workPhone = nullptr, 
	String^ email = nullptr, 
	Nullable<DateTime> birthday = nullptr, 
	String^ website = nullptr, 
	String^ street = nullptr, 
	String^ houseNumber = nullptr, 
	String^ city = nullptr, 
	String^ zipCode = nullptr, 
	String^ country = nullptr, 
	String^ note = nullptr, 
	String^ stateRegion = nullptr, 
	PayloadGenerator.ContactData.AddressOrder addressOrder = PayloadGenerator.ContactData.AddressOrder::Default, 
	String^ org = nullptr, 
	String^ orgTitle = nullptr
)
```



#### Parameters
<dl><dt>  <a href="T_QRCoder_Core_PayloadGenerator_ContactData_ContactOutputType.md">PayloadGenerator.ContactData.ContactOutputType</a></dt><dd>Payload output type</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>The firstname</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>The lastname</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>The displayname</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Normal phone number</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Mobile phone</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Office phone number</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>E-Mail address</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.nullable-1" target="_blank" rel="noopener noreferrer">Nullable</a>(<a href="https://learn.microsoft.com/dotnet/api/system.datetime" target="_blank" rel="noopener noreferrer">DateTime</a>)  (Optional)</dt><dd>Birthday</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Website / Homepage</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Street</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Housenumber</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>City</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Zip code</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Country</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Memo text / notes</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>State or Region</dd><dt>  <a href="T_QRCoder_Core_PayloadGenerator_ContactData_AddressOrder.md">PayloadGenerator.ContactData.AddressOrder</a>  (Optional)</dt><dd>The address order format to use</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Organisation/Company</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Organisation/Company Title</dd></dl>

## See Also


#### Reference
<a href="T_QRCoder_Core_PayloadGenerator_ContactData.md">PayloadGenerator.ContactData Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

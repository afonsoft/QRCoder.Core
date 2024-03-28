# GetGraphic Method


Returns a strings that contains the resulting QR code as ASCII chars.



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public string GetGraphic(
	int repeatPerModule,
	string darkColorString = "██",
	string whiteSpaceString = "",
	bool drawQuietZones = true,
	string endOfLine = ""
)
```
**C++**
``` C++
public:
String^ GetGraphic(
	int repeatPerModule, 
	String^ darkColorString = L"██", 
	String^ whiteSpaceString = L"", 
	bool drawQuietZones = true, 
	String^ endOfLine = L""
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a></dt><dd>Number of repeated darkColorString/whiteSpaceString per module.</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>String for use as dark color modules. In case of string make sure whiteSpaceString has the same length.</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>String for use as white modules (whitespace). In case of string make sure darkColorString has the same length.</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>\[Missing &lt;param name="drawQuietZones"/&gt; documentation for "M:QRCoder.Core.AsciiQRCode.GetGraphic(System.Int32,System.String,System.String,System.Boolean,System.String)"\]</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>End of line separator. (Default: \n)</dd></dl>

#### Return Value
<a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  
\[Missing &lt;returns&gt; documentation for "M:QRCoder.Core.AsciiQRCode.GetGraphic(System.Int32,System.String,System.String,System.Boolean,System.String)"\]

## See Also


#### Reference
<a href="T_QRCoder_Core_AsciiQRCode.md">AsciiQRCode Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

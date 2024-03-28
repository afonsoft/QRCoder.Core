# GetLineByLineGraphic Method


Returns an array of strings that contains each line of the resulting QR code as ASCII chars.



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public string[] GetLineByLineGraphic(
	int repeatPerModule,
	string darkColorString = "██",
	string whiteSpaceString = "",
	bool drawQuietZones = true
)
```
**C++**
``` C++
public:
array<String^>^ GetLineByLineGraphic(
	int repeatPerModule, 
	String^ darkColorString = L"██", 
	String^ whiteSpaceString = L"", 
	bool drawQuietZones = true
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.int32" target="_blank" rel="noopener noreferrer">Int32</a></dt><dd>Number of repeated darkColorString/whiteSpaceString per module.</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>String for use as dark color modules. In case of string make sure whiteSpaceString has the same length.</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>String for use as white modules (whitespace). In case of string make sure darkColorString has the same length.</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>\[Missing &lt;param name="drawQuietZones"/&gt; documentation for "M:QRCoder.Core.AsciiQRCode.GetLineByLineGraphic(System.Int32,System.String,System.String,System.Boolean)"\]</dd></dl>

#### Return Value
<a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>[]  
\[Missing &lt;returns&gt; documentation for "M:QRCoder.Core.AsciiQRCode.GetLineByLineGraphic(System.Int32,System.String,System.String,System.Boolean)"\]

## See Also


#### Reference
<a href="T_QRCoder_Core_AsciiQRCode.md">AsciiQRCode Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

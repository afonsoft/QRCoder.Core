# PayloadGenerator.WhatsAppMessage(String, String) Constructor


Let's you compose a WhatApp message and send it the receiver number.



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public WhatsAppMessage(
	string number,
	string message
)
```
**C++**
``` C++
public:
WhatsAppMessage(
	String^ number, 
	String^ message
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Receiver phone number where the number is a full phone number in international format. Omit any zeroes, brackets, or dashes when adding the phone number in international format. Use: 1XXXXXXXXXX | Don't use: +001-(XXX)XXXXXXX</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>The message</dd></dl>

## See Also


#### Reference
<a href="T_QRCoder_Core_PayloadGenerator_WhatsAppMessage.md">PayloadGenerator.WhatsAppMessage Class</a>  
<a href="Overload_QRCoder_Core_PayloadGenerator_WhatsAppMessage__ctor.md">PayloadGenerator.WhatsAppMessage Overload</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

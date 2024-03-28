# PayloadGenerator.Mail Constructor


Creates an email payload with subject and message/text



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public Mail(
	string mailReceiver = null,
	string subject = null,
	string message = null,
	PayloadGenerator.Mail.MailEncoding encoding = PayloadGenerator.Mail.MailEncoding.MAILTO
)
```
**C++**
``` C++
public:
Mail(
	String^ mailReceiver = nullptr, 
	String^ subject = nullptr, 
	String^ message = nullptr, 
	PayloadGenerator.Mail.MailEncoding encoding = PayloadGenerator.Mail.MailEncoding::MAILTO
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Receiver's email address</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Subject line of the email</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a>  (Optional)</dt><dd>Message content of the email</dd><dt>  <a href="T_QRCoder_Core_PayloadGenerator_Mail_MailEncoding.md">PayloadGenerator.Mail.MailEncoding</a>  (Optional)</dt><dd>Payload encoding type. Choose dependent on your QR Code scanner app.</dd></dl>

## See Also


#### Reference
<a href="T_QRCoder_Core_PayloadGenerator_Mail.md">PayloadGenerator.Mail Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

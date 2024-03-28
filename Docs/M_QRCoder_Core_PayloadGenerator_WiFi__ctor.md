# PayloadGenerator.WiFi Constructor


Generates a WiFi payload. Scanned by a QR Code scanner app, the device will connect to the WiFi.



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+4632349aa2a984532af965c24d83952cef07f5b3  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public WiFi(
	string ssid,
	string password,
	PayloadGenerator.WiFi.Authentication authenticationMode,
	bool isHiddenSSID = false,
	bool escapeHexStrings = true
)
```
**C++**
``` C++
public:
WiFi(
	String^ ssid, 
	String^ password, 
	PayloadGenerator.WiFi.Authentication authenticationMode, 
	bool isHiddenSSID = false, 
	bool escapeHexStrings = true
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>SSID of the WiFi network</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Password of the WiFi network</dd><dt>  <a href="T_QRCoder_Core_PayloadGenerator_WiFi_Authentication.md">PayloadGenerator.WiFi.Authentication</a></dt><dd>Authentification mode (WEP, WPA, WPA2)</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>Set flag, if the WiFi network hides its SSID</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a>  (Optional)</dt><dd>Set flag, if ssid/password is delivered as HEX string. Note: May not be supported on iOS devices.</dd></dl>

## See Also


#### Reference
<a href="T_QRCoder_Core_PayloadGenerator_WiFi.md">PayloadGenerator.WiFi Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

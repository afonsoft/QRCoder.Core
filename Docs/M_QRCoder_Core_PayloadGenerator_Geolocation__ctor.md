# PayloadGenerator.Geolocation Constructor


Generates a geo location payload. Supports raw location (GEO encoding) or Google Maps link (GoogleMaps encoding)



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+4632349aa2a984532af965c24d83952cef07f5b3  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public Geolocation(
	string latitude,
	string longitude,
	PayloadGenerator.Geolocation.GeolocationEncoding encoding = PayloadGenerator.Geolocation.GeolocationEncoding.GEO
)
```
**C++**
``` C++
public:
Geolocation(
	String^ latitude, 
	String^ longitude, 
	PayloadGenerator.Geolocation.GeolocationEncoding encoding = PayloadGenerator.Geolocation.GeolocationEncoding::GEO
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Latitude with . as splitter</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Longitude with . as splitter</dd><dt>  <a href="T_QRCoder_Core_PayloadGenerator_Geolocation_GeolocationEncoding.md">PayloadGenerator.Geolocation.GeolocationEncoding</a>  (Optional)</dt><dd>Encoding type - GEO or GoogleMaps</dd></dl>

## See Also


#### Reference
<a href="T_QRCoder_Core_PayloadGenerator_Geolocation.md">PayloadGenerator.Geolocation Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

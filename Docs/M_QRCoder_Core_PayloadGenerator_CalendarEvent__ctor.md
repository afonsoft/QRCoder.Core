# PayloadGenerator.CalendarEvent Constructor


Generates a calender entry/event payload.



## Definition
**Namespace:** <a href="N_QRCoder_Core.md">QRCoder.Core</a>  
**Assembly:** QRCoder.Core (in QRCoder.Core.dll) Version: 1.0.2+100b048b01076590efe500a3be242a5faeb43294  
**XMLNS for XAML:** Not mapped to an xmlns.

**C#**
``` C#
public CalendarEvent(
	string subject,
	string description,
	string location,
	DateTime start,
	DateTime end,
	bool allDayEvent,
	PayloadGenerator.CalendarEvent.EventEncoding encoding = PayloadGenerator.CalendarEvent.EventEncoding.Universal
)
```
**C++**
``` C++
public:
CalendarEvent(
	String^ subject, 
	String^ description, 
	String^ location, 
	DateTime start, 
	DateTime end, 
	bool allDayEvent, 
	PayloadGenerator.CalendarEvent.EventEncoding encoding = PayloadGenerator.CalendarEvent.EventEncoding::Universal
)
```



#### Parameters
<dl><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Subject/title of the calender event</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Description of the event</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.string" target="_blank" rel="noopener noreferrer">String</a></dt><dd>Location (lat:long or address) of the event</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.datetime" target="_blank" rel="noopener noreferrer">DateTime</a></dt><dd>Start time of the event</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.datetime" target="_blank" rel="noopener noreferrer">DateTime</a></dt><dd>End time of the event</dd><dt>  <a href="https://learn.microsoft.com/dotnet/api/system.boolean" target="_blank" rel="noopener noreferrer">Boolean</a></dt><dd>Is it a full day event?</dd><dt>  <a href="T_QRCoder_Core_PayloadGenerator_CalendarEvent_EventEncoding.md">PayloadGenerator.CalendarEvent.EventEncoding</a>  (Optional)</dt><dd>Type of encoding (universal or iCal)</dd></dl>

## See Also


#### Reference
<a href="T_QRCoder_Core_PayloadGenerator_CalendarEvent.md">PayloadGenerator.CalendarEvent Class</a>  
<a href="N_QRCoder_Core.md">QRCoder.Core Namespace</a>  

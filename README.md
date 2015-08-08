# dotNetSlApi
Sl api wrapper for .net

```C#
var client = new SlApi.RealtimeInformation();
client.ApiToken = "your key";
var result = client.RealtimeDepartures(new RealtimeDeparturesRequest
{
  SiteId = 9501,
  TimeWindow = 2,
});
```

# Nuget package 
https://www.nuget.org/packages/SlApi



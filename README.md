# dotNetSlApi
Sl api wrapper for .net

```C#
var client = new SlApi.RealtimeInformationClient();
client.ApiToken = "your key";
var result = client.RealtimeDepartures(new RealtimeDeparturesRequest
{
  SiteId = 9501,
  TimeWindow = 2,
});
```

# Nuget package 
https://www.nuget.org/packages/SlApi


# Trafiklab project page
https://www.trafiklab.se/projekt/dotnetslapi


# License

This work is licensed under the Creative Commons Attribution-ShareAlike 4.0 International License. To view a copy of this license, visit http://creativecommons.org/licenses/by-sa/4.0/.
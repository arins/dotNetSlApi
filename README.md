



# dotNetSlApi
SL Stockholms lokaltrafik (stockholm public transport) api wrapper for .NET. This API wrapper makes it easier to user SL API. If you have an account at Trafiklab (https://www.trafiklab.se/) you can use this API Wrapper.

# Build Status
Current status of the build and unit tests on the master branch.

[![Build status](https://ci.appveyor.com/api/projects/status/oxfg3v4y4biux5wt?svg=true)](https://ci.appveyor.com/project/arins43491/dotnetslapi)

#Example

Realtime information example
```C#
var client = new SlApi.RealtimeInformationClient();
client.ApiToken = "your key";
var result = client.RealtimeDepartures(new RealtimeDeparturesRequest
{
  SiteId = 9501,
  TimeWindow = 2,
});
```
Search places and trip
```C#
var search = new PlaceSearchClient {ApiToken = "key"};
var travel = new TravelPlannerClient {ApiToken = "key"};

var result = search.Search(new PlaceSearchRequest
{
  MaxResults = 10,
  SearchString = "Solna",
  StationsOnly = false
});

var solna = result.ResponseData[0].SiteId;
result = search.Search(new PlaceSearchRequest
{
  MaxResults = 10,
  SearchString = "t-centralen",
  StationsOnly = false
});

var tcentralen = result.ResponseData[0].SiteId;
var resultFromSearch = travel.Trip(new TripRequest
{
  DateTime = DateTime.Now,
  DestId = tcentralen.ToString(),
  OriginId = solna.ToString()
});
```

# Nuget package 
Download the package via nuget
https://www.nuget.org/packages/SlApi


# Trafiklab project page
https://www.trafiklab.se/projekt/dotnetslapi


# License

This work is licensed under the Creative Commons Attribution-ShareAlike 4.0 International License. To view a copy of this license, visit http://creativecommons.org/licenses/by-sa/4.0/.


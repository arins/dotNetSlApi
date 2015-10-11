using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace SlApi
{
    public interface ISlApiClientFactory
    {
        INearbyStopsClient GetNearbyStopsClient(string endpoint = null);

        IPlaceSearchClient GetPlaceSearchClient(string endpoint = null);

        IRealtimeInformationClient GetRealtimeInformationClient(string endpoint = null);

        IStopsAndRoutesClient GetStopsAndRoutesClient(string endpoint = null);

        ITrafficDeviationInformationClient GetTrafficDeviationInformationClient(string endpoint = null);

        ITrafficInformationClient GetTrafficInformationClient(string endpoint = null);

        ITravelPlannerClient GetTravelPlannerClient(string endpoint = null);
    }
}

﻿using System.Threading.Tasks;
using SlApi.Models.StopsAndRoutes.Response;

namespace SlApi
{
    public interface IStopsAndRoutesClient
    {

        bool EnableDebugInformationInException { get; set; }
        bool GzipEnabled
        {
            get; set;
        }
        JourneyPatternPointOnLines JourneyPaternPointOnLine();
        Task<JourneyPatternPointOnLines> JourneyPaternPointOnLineAsync();
        Lines Lines();
        Task<Lines> LinesAsync();
        Sites Sites();
        Task<Sites> SitesAsync();
        StopPoints StopPoints();
        Task<StopPoints> StopPointsAsync();
        TransportModes TransportModes();
        Task<TransportModes> TransportModesAsync();
    }
}
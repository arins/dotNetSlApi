using System.Threading.Tasks;
using SlApi.General.Models.StopsAndRoutes.Response;

namespace SlApi.General
{
    public interface IStopsAndRoutesClient
    {
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
namespace SlApi.Models.StopsAndRoutes.Response
{
    public class SiteDataResponse : BaseResponse
    {
        public StopsAndRoutesBaseResponse<Site> ResponseData { get; set; }
    }
}
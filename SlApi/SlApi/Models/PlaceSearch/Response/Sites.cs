using System;

namespace SlApi.Models.PlaceSearch.Response
{
    [Serializable]
    public class Sites : BaseResponse
    {
        public Site[] ResponseData { get; set; } 
    }
}

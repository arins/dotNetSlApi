using System;

namespace SlApi.Models.RealtimeInformation.Response
{
    [Serializable]
    public class DepartureResponse : BaseResponse
    {
        public Departure ResponseData { get; set; }
    }
}

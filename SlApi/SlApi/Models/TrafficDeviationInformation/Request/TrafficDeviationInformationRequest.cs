using System;
using SlApi.Core;

namespace SlApi.Models.TrafficDeviationInformation.Request
{
    public class TrafficDeviationInformationRequest : TrafficDeviationInformationRawRequest, IConvertableToArgument
    {
        

        /// <summary>
        /// Startdatum för aktuell giltighetsperiod. 
        /// </summary>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Slutdatum för aktuell giltighetsperiod.
        /// </summary>
        public DateTime? ToDate { get; set; }

        public Arguments GetArgument()
        {
            var result = new Arguments();
            if (TransportMode.HasValue)
            {
                result.Add("TransportMode", TransportMode.Value.ToTrafficDeviationInformationString());
            }
            if (!string.IsNullOrEmpty(LineNumber))
            {
                result.Add("LineNumber", LineNumber);
            }
            if (SiteId.HasValue)
            {
                result.Add("SiteId",SiteId.Value.ToString());
            }
            if (FromDate.HasValue && ToDate.HasValue)
            {
                result.Add("FromDate", FromDate.Value.ToString("yyyy-MM-dd"));
                result.Add("ToDate", ToDate.Value.ToString("yyyy-MM-dd"));
            }
            if (FromDate.HasValue ^ ToDate.HasValue)
            {
                throw new ArgumentException("if any of the parameters FromDate or ToDate is set then both must be set");
            }
            return result;
        }
    }
}
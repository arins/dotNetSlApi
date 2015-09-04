using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Models.StopsAndRoutes.Response
{
    public class TransportMode
    {
        public DefaultTransportModeCode DefaultTransportModeCode { get; set; }
        public string DefaultTransportMode { get; set; }
        public StopAreaTypeCode StopAreaTypeCode { get; set; }
        public DateTime LastModifiedUtcDateTime { get; set; }
        public DateTime ExistsFromDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Models.StopsAndRoutes.Response
{
    public class StopsAndRoutesBaseResponse<T>
    {

        public string Version { get; set; }

        public string Type { get; set; }

        public T[] Result { get; set; }
    }
}

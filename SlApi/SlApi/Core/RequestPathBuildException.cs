using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Core
{
    [Serializable]
    public class RequestPathBuildException : Exception
    {
        public RequestPathBuildException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Core
{
    public interface IConvertableToArgument
    {
        /// <summary>
        /// Create an Argument obect which conains all the parameters to be create for sending in to picture life api
        /// </summary>
        /// <returns></returns>
        Arguments GetArgument();
    }
}

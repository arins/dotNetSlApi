using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Core
{
    [Serializable]
    public class Arguments : Dictionary<string, string>
    {
        public Arguments()
        {
        }

        protected Arguments(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        internal static bool AnyArguments(Arguments arguments)
        {
            return arguments != null && arguments.Any();
        }

        /// <summary>
        /// Creates an querystring from the enrties ex
        /// {"testkey1": "testval1", "testkey2": "testval2"} gives
        /// "testkey1=testval1&testkey2=testval2&
        /// </summary>
        /// <param name="sb">stringbuilder to build upon</param>
        /// <returns>return query string with ending &</returns>
        public StringBuilder BuildAndAppendQueryString(StringBuilder sb = null)
        {
            if (sb == null)
            {
                sb = new StringBuilder();
            }
            foreach (var keyValuePair in this)
            {

                sb.Append(keyValuePair.Key);
                sb.Append("=");
                sb.Append(keyValuePair.Value);
                sb.Append("&");
            }
            return sb;
        }
    }
}

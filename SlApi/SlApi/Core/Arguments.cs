using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SlApi.Core
{
    
    public class Arguments : Dictionary<string, string>
    {
        internal Arguments()
        {
        }

        

        /// <summary>
        /// Creates an querystring from the enrties ex
        /// {"testkey1": "testval1", "testkey2": "testval2"} gives
        /// "testkey1=testval1&testkey2=testval2&
        /// </summary>
        /// <param name="sb">stringbuilder to build upon</param>
        /// <returns>return query string with ending &</returns>
        internal StringBuilder BuildAndAppendQueryString(StringBuilder sb = null)
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

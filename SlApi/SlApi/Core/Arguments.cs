using System.Collections.Generic;
using System.Text;

namespace SlApi.Core
{
    
    public class Arguments : Dictionary<string, Argument>
    {
        internal Arguments()
        {
            
        }

        public void Add(string key, string value)
        {
            Add(key, new Argument(value));
        }


        /// <summary>
        /// Creates an querystring from the enrties ex
        /// {"testkey1": "testval1", "testkey2": "testval2"} gives
        /// "testkey1=testval1&testkey2=testval2&
        /// each parameter is url encoded
        /// </summary>
        /// <param name="urlHelper"></param>
        /// <param name="sb">stringbuilder to build upon</param>
        /// <returns>return query string with ending &</returns>
        internal StringBuilder BuildAndAppendQueryString(IUrlHelper urlHelper, StringBuilder sb = null)
        {
            if (sb == null)
            {
                sb = new StringBuilder();
            }
            foreach (var keyValuePair in this)
            {

                sb.Append(keyValuePair.Key);
                sb.Append("=");
                sb.Append(keyValuePair.Value.UrlEncode ?
                    urlHelper.UrlEncoder(keyValuePair.Value.Value) :
                    keyValuePair.Value.Value);
                sb.Append("&");
            }
            return sb;
        }
    }
}

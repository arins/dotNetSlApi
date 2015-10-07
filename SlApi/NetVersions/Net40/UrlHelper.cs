
using SlApi.Core;

namespace SlApi
{
    //todo make this internal
    public class UrlHelper : IUrlHelper
    {
        public string UrlEncoder(string value)
        {
            return value;
            //return WebUtility.UrlEncode(value);
        }
    }
}
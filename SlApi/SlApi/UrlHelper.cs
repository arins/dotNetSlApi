using SlApi.General.Core;
using System.Net;

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
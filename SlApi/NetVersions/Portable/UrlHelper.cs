using System.Net;
using SlApi.Core;

namespace SlApi
{
    internal class UrlHelper : IUrlHelper
    {
        public string UrlEncoder(string value)
        {
            return WebUtility.UrlEncode(value);
        }
    }
}

using System.Windows.Browser;
using SlApi.Core;

namespace SlApi
{
    internal class UrlHelper : IUrlHelper
    {
        public string UrlEncoder(string value)
        {
            return HttpUtility.UrlEncode(value);
        }
    }
}
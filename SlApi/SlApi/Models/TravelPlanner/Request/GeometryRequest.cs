using System;
using SlApi.Core;

namespace SlApi.Models.TravelPlanner.Request
{
    public class GeometryRequest : IConvertableToArgument
    {
        public string Ref { get; set; }
        public Arguments GetArgument()
        {
            var result = new Arguments();
            if (!string.IsNullOrEmpty(Ref))
            {
                result.Add("ref", new Argument(Ref) {UrlEncode = false});
            }
            else
            {
                throw new ArgumentException("Ref must be set");
            }
            return result;
        }
    }
}
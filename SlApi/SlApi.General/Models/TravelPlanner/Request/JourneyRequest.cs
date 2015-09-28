using System;
using SlApi.General.Core;

namespace SlApi.General.Models.TravelPlanner.Request
{
    public class JourneyRequest : IConvertableToArgument
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
                throw new ArgumentException("ref can not be null or empty");
            }
            return result;
        }
    }
}
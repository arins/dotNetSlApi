using System;
using SlApi.Core;

namespace SlApi.Models.TravelPlanner.Request
{
    public class JourneyRequest : IConvertableToArgument
    {
        public string Ref { get; set; }
        public Arguments GetArgument()
        {
            var result = new Arguments();
            if (!string.IsNullOrEmpty(Ref))
            {
                result.Add("ref", Ref);
            }
            else
            {
                throw new ArgumentException("ref can not be null or empty");
            }
            return result;
        }
    }
}
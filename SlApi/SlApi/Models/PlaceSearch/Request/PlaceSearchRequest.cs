using System;
using SlApi.Core;

namespace SlApi.Models.PlaceSearch.Request
{
    /// <summary>
    /// Place search parametrar
    /// </summary>
    public class PlaceSearchRequest : IConvertableToArgument
    {
        /// <summary>
        /// Söksträngen.
        /// </summary>
        public string SearchString { get; set; }
        /// <summary>
        /// Om ”True” returneras endast hållplatser. True = default.
        /// </summary>
        public bool? StationsOnly { get; set; }

        /// <summary>
        /// Maximalt antal resultat som önskas. 10 är default, det går inte att få mer än 50.
        /// </summary>
        public int? MaxResults { get; set; }


        public Arguments GetArgument()
        {
            var result = new Arguments();
            if (!string.IsNullOrEmpty(SearchString))
            {
                result.Add("SearchString", SearchString);
            }
            else
            {
                throw new ArgumentException("search string can not be null or empty!");
            }

            if (StationsOnly.HasValue)
            {
                result.Add("StationsOnly", StationsOnly.Value.ToString().ToLower());
            }

            if (MaxResults.HasValue)
            {
                result.Add("MaxResults", MaxResults.Value.ToString());
            }
            return result;
        }
    }
}

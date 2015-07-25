using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlApi.Core;

namespace SlApi.Models.Request
{
    public class SearchRequest : IConvertableToArgument
    {
        
        public string SearchString { get; set; }
        public bool StationsOnly { get; set; }
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

            result.Add("StationsOnly", StationsOnly.ToString().ToLower());

            if (MaxResults.HasValue)
            {
                result.Add("MaxResults", MaxResults.Value.ToString());
            }
            return result;
        }
    }
}

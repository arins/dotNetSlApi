using System;

namespace SlApi.General.Core
{
    
    public class RequestPathBuildException : Exception
    {
        public RequestPathBuildException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

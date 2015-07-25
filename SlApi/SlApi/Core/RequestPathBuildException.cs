using System;

namespace SlApi.Core
{
    [Serializable]
    public class RequestPathBuildException : Exception
    {
        public RequestPathBuildException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

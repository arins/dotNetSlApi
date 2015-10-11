namespace SlApi.Models
{
    public enum ErrorCode
    {
        /// <summary>
        /// Unknown service method/Ogiltigt anrop
        /// </summary>
        R0001 = 0,
        /// <summary>
        /// Invalid or missing request parameters/Felaktiga eller saknade inparametrar
        /// </summary>
        R0002 = 1,
        /// <summary>
        /// Internal communication error/Internt kommunikationsfel
        /// </summary>
        R0007 = 2,

    }
}
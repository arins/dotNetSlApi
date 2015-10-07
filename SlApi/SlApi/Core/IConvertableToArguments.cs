namespace SlApi.Core
{
    public interface IConvertableToArgument
    {
        /// <summary>
        /// Create an Argument obect which conains all the parameters to be create for sending in to picture life api
        /// </summary>
        /// <returns></returns>
        Arguments GetArgument();
    }
}

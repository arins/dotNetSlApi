using System.Threading.Tasks;

namespace SlApi.Core
{
    public interface IHttpClient
    {
        IHttpRequester Requester { get; set; }
        string ApiToken { get; set; }
        TOut DoRequest<TOut>(string path, Arguments arguments = null) where TOut : new();
        Task<TOut> DoRequestAsync<TOut>(string path, Arguments arguments = null) where TOut : new();
        TOut DoRequest<TOut>(string path, IConvertableToArgument arguments) where TOut : new();
        Task<TOut> DoRequestAsync<TOut>(string path, IConvertableToArgument arguments) where TOut : new();


    }
}

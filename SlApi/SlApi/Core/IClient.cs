﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Core
{
    public interface IClient
    {
        IHttpRequester Requester { get; set; }
        string ApiToken { get; set; }
        TOut DoRequest<TOut>(string path, Arguments arguments = null) where TOut : new();
        Task<TOut> DoRequestAsync<TOut>(string path, Arguments arguments = null) where TOut : new();
        TOut DoRequest<TOut>(string path, IConvertableToArgument arguments) where TOut : new();
        Task<TOut> DoRequestAsync<TOut>(string path, IConvertableToArgument arguments) where TOut : new();


    }
}

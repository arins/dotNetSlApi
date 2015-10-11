using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlApi.Core
{
    public interface ISlApiCallback
    {
        void OnError(string response, Exception exception);
    }
}

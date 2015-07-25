﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlApi.Core
{
    public class BaseService
    {
         internal IClient Client { get; set; }


         internal BaseService(IClient client)
        {
            Client = client;
        }

         public string ApiToken
        {
            get
            {
                if (Client.ApiToken != null)
                {
                    return Client.ApiToken.Clone() as string;
                }
                return null;

            }
            set
            {

                Client.ApiToken = value;
            }
        }
    }
}
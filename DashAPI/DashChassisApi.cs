using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashAPI.Interfaces;
using OAuth2.Infrastructure;
using RestSharp;
using RestSharp.Authenticators;

namespace DashAPI
{
    public class DashChassisApi : IDashChassisApi
    {
        private IRestClient _client;

        public DashChassisApi(string accessToken)
        {
            _client = new RestClient();
            _client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(accessToken, "Bearer");
        }




    }
}

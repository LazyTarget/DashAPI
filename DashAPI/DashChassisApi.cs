using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DashAPI.Interfaces;
using DashAPI.Models;
using OAuth2.Client;
using OAuth2.Infrastructure;
using RestSharp;
using RestSharp.Authenticators;

namespace DashAPI
{
    public class DashChassisApi : IDashChassisApi
    {
        private readonly IRestClient _client;

        public DashChassisApi(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new ArgumentNullException(nameof(accessToken));

            _client = new RestClient();
            _client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(accessToken, "Bearer");
        }

        protected virtual IRestRequest CreateRequest(Endpoint endpoint, Method method)
        {
            var request = new RestRequest(endpoint.Uri, method);
            return request;
        }



        protected virtual void BeforeRequest(IRestClient client, IRestRequest request)
        {

        }

        private IRestResponse<T> Send<T>(IRestRequest request)
            where T : new()
        {
            try
            {
                BeforeRequest(_client, request);

                var response = _client.Execute<T>(request);
                if (response.Content.IsEmpty() ||
                    (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created))
                {
                    throw new UnexpectedResponseException(response);
                }
                if (response.ErrorException != null)
                {
                    throw response.ErrorException;
                }

                AfterRequest(_client, response);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected virtual void AfterRequest(IRestClient client, IRestResponse response)
        {

        }


        /// <summary>
        /// Requires the "user" scope.
        /// </summary>
        /// <returns></returns>
        public User GetUser()
        {
            var endpoint = Endpoints.UserEndpoint;
            var request = CreateRequest(endpoint, Method.GET);
            var response = Send<User>(request);
            var result = response.Data;
            return result;
        }




        public static class Endpoints
        {
            public static Endpoint UserEndpoint
            {
                get
                {
                    return new Endpoint
                    {
                        BaseUri = "https://dash.by",
                        Resource = "/api/chassis/v1/user",
                    };
                }
            }

            public static Endpoint TripsEndpoint
            {
                get
                {
                    return new Endpoint
                    {
                        BaseUri = "https://dash.by",
                        Resource = "/api/chassis/v1/trips",
                    };
                }
            }

            public static Endpoint RoutesEndpoint
            {
                get
                {
                    return new Endpoint
                    {
                        BaseUri = "https://dash.by",
                        Resource = "/api/chassis/v1/routes",
                    };
                }
            }

            public static Endpoint StatsEndpoint
            {
                get
                {
                    return new Endpoint
                    {
                        BaseUri = "https://dash.by",
                        Resource = "/api/chassis/v1/stats",
                    };
                }
            }

            public static Endpoint BumperStickersEndpoint
            {
                get
                {
                    return new Endpoint
                    {
                        BaseUri = "https://dash.by",
                        Resource = "/api/chassis/v1/bumperstickers",
                    };
                }
            }
        }
    }
}

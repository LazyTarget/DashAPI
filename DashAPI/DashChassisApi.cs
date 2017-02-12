using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DashAPI.Helpers;
using DashAPI.Interfaces;
using DashAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OAuth2.Client;
using OAuth2.Infrastructure;
using RestSharp;
using RestSharp.Authenticators;

namespace DashAPI
{
    public class DashChassisApi : IDashChassisApi
    {
        private readonly string _accessToken;
        private readonly IRestClient _client;
        private readonly JsonNetSerializer _jsonNetSerializer;

        public DashChassisApi(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new ArgumentNullException(nameof(accessToken));

            _accessToken = accessToken;
            _client = CreateClient(Endpoints.UserEndpoint.BaseUri);
        }

        private void RegisterHandlers(IRestClient client)
        {
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new StringEnumConverter());

            var serializer = JsonSerializer.Create(jsonSettings);
            var jsonHandler = new JsonNetSerializer(serializer);
            client.AddHandler("application/json", jsonHandler);
            client.AddHandler("text/json", jsonHandler);
            client.AddHandler("text/x-json", jsonHandler);
            client.AddHandler("text/javascript", jsonHandler);
            client.AddHandler("*+json", jsonHandler);
        }

        protected IRestClient CreateClient(string baseUri)
        {
            var client = new RestClient(baseUri);
            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(_accessToken, "Bearer");
            RegisterHandlers(client);
            return client;
        }

        protected virtual IRestRequest CreateRequest(Endpoint endpoint, Method method)
        {
            var request = new RestRequest(endpoint.Resource, method);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = _jsonNetSerializer;
            return request;
        }



        protected virtual void BeforeRequest(IRestClient client, IRestRequest request)
        {

        }

        protected virtual IRestResponse<T> Send<T>(IRestClient client, IRestRequest request)
            where T : new()
        {
            try
            {
                BeforeRequest(client, request);

                var response = client.Execute<T>(request);
                if (response.Content.IsEmpty() ||
                    (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created))
                {
                    throw new UnexpectedResponseException(response);
                }
                if (response.ErrorException != null)
                {
                    throw response.ErrorException;
                }

                AfterRequest(client, response);
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
            var response = Send<User>(_client, request);
            var result = response.Data;
            return result;
        }


        public IEnumerable<Trip> GetTrips(DateTime? startTime = null, DateTime? endTime = null, bool? paged = null)
        {
            var result = GetTrips(startTime, endTime, paged, false);
            return result;
        }


        public IEnumerable<Trip> GetTrips(DateTime? startTime, DateTime? endTime, bool? paged, bool queryAll)
        {
            var endpoint = Endpoints.TripsEndpoint;
            var request = CreateRequest(endpoint, Method.GET);
            if (startTime.HasValue)
                request.AddQueryParameter("startTime", startTime.Value.ToUnixTime().ToString());
            if (endTime.HasValue)
                request.AddQueryParameter("endTime", endTime.Value.ToUnixTime().ToString());
            if (paged.HasValue)
                request.AddQueryParameter("paged", paged.Value.ToString());

            IRestClient client = _client;
            var shouldGetNext = true;
            while (shouldGetNext)
            {
                var response = Send<PageResult<Trip>>(client, request);
                var pageResult = response.Data;
                if (pageResult != null)
                {
                    if (pageResult.Result != null)
                    {
                        // Yield return result
                        foreach (var trip in pageResult.Result)
                        {
                            yield return trip;
                        }
                    }


                    if (!string.IsNullOrWhiteSpace(pageResult.NextUrl) && queryAll)
                    {
                        client = CreateClient(pageResult.NextUrl);
                        request.Resource = "";
                    }
                    else
                    {
                        // No more pages...
                        shouldGetNext = false;
                    }
                }
                else
                {
                    // Empty page...
                    shouldGetNext = false;
                }
            }
        }

        public IEnumerable<RoutePoint> GetRoute(string tripId)
        {
            throw new NotImplementedException();
        }

        public Stats GetStats(DateTime? startTime = null, DateTime? endTime = null, bool? paged = null)
        {
            var endpoint = Endpoints.StatsEndpoint;
            var request = CreateRequest(endpoint, Method.GET);
            if (startTime.HasValue)
                request.AddQueryParameter("startTime", startTime.Value.ToUnixTime().ToString());
            if (endTime.HasValue)
                request.AddQueryParameter("endTime", endTime.Value.ToUnixTime().ToString());
            if (paged.HasValue)
                request.AddQueryParameter("paged", paged.Value.ToString());

            var response = Send<Stats>(_client, request);
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

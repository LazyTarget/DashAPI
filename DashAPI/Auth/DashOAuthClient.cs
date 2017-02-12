using Newtonsoft.Json.Linq;
using OAuth2.Client;
using OAuth2.Configuration;
using OAuth2.Infrastructure;
using OAuth2.Models;
using RestSharp.Authenticators;

namespace DashAPI.Auth
{
    public class DashOAuthClient : OAuth2Client
    {
        private readonly IRequestFactory _factory;

        public DashOAuthClient(IRequestFactory factory, IClientConfiguration configuration)
            : base(factory, configuration)
        {
            _factory = factory;
        }

        public override string Name => "Dash";


        protected override Endpoint AccessCodeServiceEndpoint
        {
            get
            {
                return new Endpoint
                {
                    BaseUri = "https://dash.by",
                    Resource = "/api/auth/authorize",
                };
            }
        }

        protected override Endpoint AccessTokenServiceEndpoint
        {
            get
            {
                return new Endpoint
                {
                    BaseUri = "https://dash.by",
                    Resource = "/api/auth/token",
                };
            }
        }

        protected override Endpoint UserInfoServiceEndpoint
        {
            get
            {
                return new Endpoint
                {
                    BaseUri = "https://dash.by",
                    Resource = "/api/v1/person/detailed",
                };
            }
        }


        public override string GetLoginLinkUri(string state = null)
        {
            var result = base.GetLoginLinkUri(state);
            return result;
        }



        protected override void BeforeGetAccessToken(BeforeAfterRequestArgs args)
        {
            base.BeforeGetAccessToken(args);
        }

        protected override string ParseTokenResponse(string content, string key)
        {
            var result = base.ParseTokenResponse(content, key);
            return result;
        }

        protected override void AfterGetAccessToken(BeforeAfterRequestArgs args)
        {
            base.AfterGetAccessToken(args);
        }



        protected override void BeforeGetUserInfo(BeforeAfterRequestArgs args)
        {
            base.BeforeGetUserInfo(args);
        }

        protected override UserInfo ParseUserInfo(string content)
        {
            var obj = JObject.Parse(content);

            var userInfo = new UserInfo
            {
                ProviderName = this.Name,

                Id = obj?.SelectToken("person.id")?.ToString(),
                FirstName = obj?.SelectToken("person.firstName")?.ToString(),
                LastName = obj?.SelectToken("person.lastName")?.ToString(),
                Email = obj?.SelectToken("person.email")?.ToString(),
                AvatarUri =
                {
                    Normal = obj?.SelectToken("person.imgUrl")?.ToString()
                }
            };
            return userInfo;
        }

        protected override UserInfo GetUserInfo()
        {
            var client = _factory.CreateClient(UserInfoServiceEndpoint);
            //client.Authenticator = new OAuth2UriQueryParameterAuthenticator(AccessToken);
            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(AccessToken, "Bearer");
            var request = _factory.CreateRequest(UserInfoServiceEndpoint);

            BeforeGetUserInfo(new BeforeAfterRequestArgs
            {
                Client = client,
                Request = request,
                Configuration = Configuration
            });

            var response = client.ExecuteAndVerify(request);

            var result = ParseUserInfo(response.Content);
            result.ProviderName = Name;

            return result;
        }

    }
}

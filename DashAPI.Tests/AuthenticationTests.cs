using System;
using DashAPI.Auth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OAuth2.Configuration;
using OAuth2.Infrastructure;

namespace DashAPI.Tests
{
    [TestClass]
    public class AuthenticationTests
    {
        [TestMethod]
        public void GetLoginLink()
        {
            IRequestFactory factory = new RequestFactory();
            IClientConfiguration configuration = new RuntimeClientConfiguration
            {
                IsEnabled = true,
                ClientId = "MDNkZGRjYTYtMmI1OC00N2UwLThiMDctZjExNGQ0ZmZmNWZl",
                ClientSecret = "ODY2YzIzMDMtZDllMi00NzdhLWJkOTAtOTc5YjhmMjI3NmNm",
                ClientTypeName = nameof(DashOAuthClient),
                Scope = "user trips".Replace(" ", "%20"),
                RedirectUri = "http://www.xhaus.com/headers",
            };
            var oauthClient = new DashOAuthClient(factory, configuration);
            var loginLinkUri = oauthClient.GetLoginLinkUri();
            Assert.IsNotNull(loginLinkUri);
        }
    }
}

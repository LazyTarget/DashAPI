using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DashAPI.Tests
{
    [TestClass]
    public class DashChassisApiTests
    {
        [TestMethod]
        public void GetUser()
        {
            var accessToken = System.Configuration.ConfigurationManager.AppSettings.Get("AccessToken");
            var dashApi = new DashChassisApi(accessToken);
            var user = dashApi.GetUser();

            Assert.IsNotNull(user);
            Assert.AreEqual("cbbf17fd-d0ca-4f69-8c9e-e7216a8b2769", user.Id);
            //Assert.IsNotNull(user.CurrentVehicle);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DashAPI.Tests
{
    [TestClass]
    public class DashChassisApiTests
    {
        [TestMethod]
        public void GetUser()
        {
            var accessToken = "gKfK556-r0llM-SKiSqozN7gYHd6G1mwtvKO2eVzao0mssfaH16YARAm61k0C1aGsNjoQevMe2U-7eDWO6t7UzLJGxKJx41lJ53tIyb0k9OWUpq9m9WH4A";
            var dashApi = new DashChassisApi(accessToken);
            var user = dashApi.GetUser();

            Assert.IsNotNull(user);
            Assert.AreEqual("cbbf17fd-d0ca-4f69-8c9e-e7216a8b2769", user.Id);
            //Assert.IsNotNull(user.CurrentVehicle);
        }
    }
}
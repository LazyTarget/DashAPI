using System;
using System.ComponentModel;
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
            Assert.IsNotNull(user.CurrentVehicle);
            Assert.IsNotNull(user.Vehicles);
            Assert.IsTrue(user.Vehicles.Length > 0);
        }
        

        [TestMethod]
        public void GetStats()
        {
            var accessToken = System.Configuration.ConfigurationManager.AppSettings.Get("AccessToken");
            var dashApi = new DashChassisApi(accessToken);

            var now = DateTime.UtcNow;
            var startTime = now.Date.AddDays(-now.Day + 1);
            var endTime = startTime.AddMonths(1);
            var stats = dashApi.GetStats(startTime, endTime);

            Assert.IsNotNull(stats);
            Assert.AreEqual(startTime, stats.TimeStart);
            Assert.AreEqual(endTime, stats.TimeEnd);
        }

    }
}
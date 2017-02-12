using System;
using System.Collections.Generic;
using DashAPI.Models;

namespace DashAPI.Interfaces
{
    public interface IDashChassisApi
    {
        User GetUser();
        IEnumerable<Trip> GetTrips(DateTime? startTime = null, DateTime? endTime = null, bool? paged = null);
        IEnumerable<RoutePoint> GetRoute(string tripId);
        Stats GetStats(DateTime? startTime = null, DateTime? endTime = null, bool? paged = null);
    }
}

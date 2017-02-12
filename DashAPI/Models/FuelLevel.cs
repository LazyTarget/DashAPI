using System;

namespace DashAPI.Models
{
    public class FuelLevel
    {
        public string VehicleId { get; set; }
        public double Level { get; set; }
        public DateTime Time { get; set; }
    }
}
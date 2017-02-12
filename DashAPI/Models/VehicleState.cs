using System;

namespace DashAPI.Models
{
    public class VehicleState
    {
        public string VehicleId { get; set; }
        public string State { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime TimeRecorded { get; set; }
    }
}
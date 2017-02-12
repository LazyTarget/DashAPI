using System;
using Newtonsoft.Json;

namespace DashAPI.Models
{
    public class VehicleState
    {
        public string VehicleId { get; set; }
        public string State { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [JsonProperty("date")]
        public DateTime TimeCaptured { get; set; }
    }
}
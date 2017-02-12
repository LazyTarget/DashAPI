using System;
using Newtonsoft.Json;

namespace DashAPI.Models
{
    public class FuelLevel
    {
        public string VehicleId { get; set; }
        public double Level { get; set; }
        [JsonProperty("dateRecorded")]
        public DateTime TimeRecorded { get; set; }
    }
}
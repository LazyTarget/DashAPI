using System;
using DashAPI.Helpers;
using Newtonsoft.Json;

namespace DashAPI.Models
{
    public class Stats
    {
        [JsonProperty("dateStart")]
        public DateTime TimeStart { get; set; }

        [JsonProperty("dateEnd")]
        public DateTime TimeEnd { get; set; }
        public double AverageFuelEfficiency { get; set; }
        public double AverageSpeed { get; set; }
        public double DistanceDriven { get; set; }
        
        [JsonConverter(typeof(TimeSpanJsonConverter), "m")]
        public TimeSpan TimeDriven { get; set; }
        public double FuelConsumed { get; set; }
    }
}
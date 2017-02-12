using System;

namespace DashAPI.Models
{
    public class Stats
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public double AverageFuelEfficiency { get; set; }
        public double AverageSpeed { get; set; }
        public double DistanceDriven { get; set; }
        public TimeSpan TimeDriven { get; set; }
        public double FuelConsumed { get; set; }
    }
}
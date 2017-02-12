using System;

namespace DashAPI.Models
{
    public class Trip
    {
        public string Id { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string VehicleId { get; set; }
        public string StartAddress { get; set; }
        public string EndAddress { get; set; }
        public double StartLatitude { get; set; }
        public double EndLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLongitude { get; set; }
        public string StartMapImageUrl { get; set; }
        public string EndMapImageUrl { get; set; }
        public double Score { get; set; }
        public Stats Stats { get; set; }
        public double StartTemperature { get; set; }
        public double EndTemperature { get; set; }
        public string StartWeatherConditions { get; set; }
        public string EndWeatherConditions { get; set; }
        public string StartWeatherConditionsImageUrl { get; set; }
        public string EndWeatherConditionsImageUrl { get; set; }
        public Alert[] Alerts { get; set; }
    }
}
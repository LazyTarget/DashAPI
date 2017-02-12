namespace DashAPI.Models
{
    public class MeasurmentUnit
    {
        public DistanceUnit Distance { get; set; }
        public TemperatureUnit Temperature { get; set; }
        public VolumeUnit Volume { get; set; }
        public FuelEfficiencyUnit FuelEfficiency { get; set; }
    }
}
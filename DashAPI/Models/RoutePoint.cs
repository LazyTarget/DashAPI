namespace DashAPI.Models
{
    public class RoutePoint
    {
        public string VehicleId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Speed { get; set; }
        public double FuelEfficiency { get; set; }
        public Alert[] Alerts { get; set; }
    }
}
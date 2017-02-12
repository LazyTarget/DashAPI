namespace DashAPI.Models
{
    public class Vehicle
    {
        public string Id { get; set; }
        public string Vin { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Name { get; set; }
        public double Odometer { get; set; }
        public float EngineDisplacementLiters { get; set; }
        public double CityFuelEfficiency { get; set; }
        public double HighwayFuelEfficiency { get; set; }
        public double TankSize { get; set; }
        public FuelType FuelType { get; set; }
        public string VehicleProfileImageUrl { get; set; }
        public string MakeLogoImageUrl { get; set; }
    }
}

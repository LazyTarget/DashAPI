namespace DashAPI.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string UserProfileImageUrl { get; set; }
        public MeasurmentUnit PreferredUnits { get; set; }
        public Vehicle CurrentVehicle { get; set; }
        public Vehicle[] Vehicles { get; set; }
    }
}
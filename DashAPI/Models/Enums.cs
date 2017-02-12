namespace DashAPI.Models
{
    public enum DistanceUnit
    {
        None,
        Miles,
        Kilometers,
    }

    public enum TemperatureUnit
    {
        None,
        Fahrenheit,
        Celsius,
    }

    public enum VolumeUnit
    {
        None,
        USGallon,
        ImperialGallon,
        Liter,
    }

    public enum FuelEfficiencyUnit
    {
        None,
        MilesPerGallon,
        MilesPerImperialGallon,
        KilometersPerLiter,
        LiterPer100Kilometer,
    }

    public enum FuelType
    {
        None,
        Diesel,
        Regular,
        Plus,
        Premium,
        Electric,
        Other,
    }

    public enum AlertType
    {
        None,
        EngineLight,
        HardBrake,
        HardAcceleration,
        Speed,
    }
}
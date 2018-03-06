public interface ITruck
{
    double FuelQuantity { get; set; }
    double FuelConsumptionPerKm { get; set; }

    void Drive(double distance);
    void Refuel(double liters);
}


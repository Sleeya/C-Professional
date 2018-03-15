using System.Collections.Generic;

public class CarFactory
{
    public static Car CreateCar(List<string> args)
    {
        int horsePower = int.Parse(args[2]);
        double fuelAmount = double.Parse(args[3]);
        Tyre tyre = TyreFactory.CreateTyre(args);

        return new Car(horsePower, fuelAmount, tyre);
    }
}

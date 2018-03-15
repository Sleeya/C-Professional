using System;
using System.Collections.Generic;
using System.Linq;

public class DriverFactory
{
    public static Driver CreateDriver(List<string> args)
    {
        string type = args[0];

        if (type == "Aggressive")
        {
            string name = args[1];
            Car car = CarFactory.CreateCar(args);

            return new AggressiveDriver(name, car);

        }

        if (type == "Endurance")
        {
            string name = args[1];
            Car car = CarFactory.CreateCar(args);

            return new EnduranceDriver(name, car);
        }

        throw new ArgumentException();
    }
}

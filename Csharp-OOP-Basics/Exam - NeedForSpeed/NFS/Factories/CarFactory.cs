using System;
using System.Collections.Generic;

public class CarFactory
{
    public static Car GenerateCar(string type, string brand, string model, int year, int horsePower, int acceleration, int suspension, int durability)
    {
        
      switch (type)
        {
            case "Performance":
                return new PerformanceCar(brand,model,year,horsePower,acceleration,suspension,durability);
            case "Show":
                return new ShowCar(brand,model,year,horsePower,acceleration,suspension,durability);
        }

        throw new ArgumentException();
    }
}

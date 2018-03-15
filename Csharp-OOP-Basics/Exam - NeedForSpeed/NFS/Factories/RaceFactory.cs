using System;
using System.Collections.Generic;

public class RaceFactory
{
    public static Race GenerateRace(string type, int length, string route, int pricePool, int goldTimeOrLaps = 0)
    {
        switch (type)
        {
            case "Casual":
                return new CasualRace(length, route, pricePool);
            case "Drag":
                return new DragRace(length, route, pricePool);
            case "Drift":
                return new DriftRace(length, route, pricePool);
            case "TimeLimit":
                return new TimeLimitRace(length, route, pricePool, goldTimeOrLaps);
            case "Circuit":
                return new CircuitRace(length, route, pricePool, goldTimeOrLaps);
        }

        throw new ArgumentException();
    }
}

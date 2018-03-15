using System;
using System.Collections.Generic;

public class TyreFactory
{
    public static Tyre CreateTyre(List<string> args)
    {
        string tyreType = args[4];
        double tyreHardness = double.Parse(args[5]);

        if (tyreType == "Ultrasoft")
        {
            int grip = int.Parse(args[6]);
            return new UltrasoftTyre(tyreHardness, grip);
        }

        if (tyreType == "Hard")
        {
            return new HardTyre(tyreHardness);
        }

        throw new ArgumentException();
    }
}

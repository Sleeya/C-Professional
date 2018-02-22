using System;


class Program
{
    static void Main(string[] args)
    {
        var lenght = decimal.Parse(Console.ReadLine());
        var width = decimal.Parse(Console.ReadLine());
        var height = decimal.Parse(Console.ReadLine());

        try
        {
            Box currentBox = new Box(lenght, width, height);
            currentBox.SurfaceArea();
            currentBox.LateralSurfaceArea();
            currentBox.Volume();
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            
        }

        
    }
}


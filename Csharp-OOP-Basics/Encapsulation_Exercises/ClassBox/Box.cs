using System;
using System.Collections.Generic;
using System.Text;


class Box
{
    private decimal length;
    private decimal width;
    private decimal height;

    public Box(decimal Length, decimal Width, decimal Height)
    {
        length = Length;
        width = Width;
        height = Height;
    }

    public void SurfaceArea()
    {
        Console.WriteLine($"Surface Area - {((2*length*width)+(2*length*height)+(2*width*height)):f2}");
    }

    public void LateralSurfaceArea()
    {
        Console.WriteLine($"Lateral Surface Area - {((2*length * height) + (2*height*width)):f2}");
    }

    public void Volume()
    {
        Console.WriteLine($"Volume - {(length * width * height):f2}");
    }
}


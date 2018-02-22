using System;
using System.Collections.Generic;
using System.Text;


public class Box
{
    private const int MIN_SIDE = 0;
    private decimal length;
    private decimal width;
    private decimal height;

    public decimal Length
    {
        get { return this.Length = length;}
        private set {
            if (value<=MIN_SIDE)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }

            this.length = value;
        }
    }

    public decimal Width
    {
        get { return this.Width = width; }
        private set
        {
            if (value <= MIN_SIDE)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }

            this.width = value;
        }
    }

    public decimal Height
    {
        get { return this.Height = height; }
        private set
        {
            if (value <= MIN_SIDE)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }

            this.height = value;
        }
    }

    public Box(decimal Length, decimal Width, decimal Height)
    {
        this.Length = Length;
        this.Width = Width;
        this.Height = Height;
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


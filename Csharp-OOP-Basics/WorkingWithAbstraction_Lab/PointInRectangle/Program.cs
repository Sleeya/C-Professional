using System;
using System.Linq;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Point topLeft = new Point(input[0], input[1]);
        Point bottomRight = new Point(input[2], input[3]);

        Rectangle rectangle = new Rectangle(topLeft, bottomRight);

        int numberOfPoints = int.Parse(Console.ReadLine());
        NewMethod(rectangle, numberOfPoints);

    }

    private static void NewMethod(Rectangle rectangle, int numberOfPoints)
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Point currentPoint = new Point(command[0], command[1]);

            if (rectangle.ContainsPoint(currentPoint))
            {
                Console.WriteLine($"True");
            }
            else
            {
                Console.WriteLine($"False");
            }
        }
    }
}


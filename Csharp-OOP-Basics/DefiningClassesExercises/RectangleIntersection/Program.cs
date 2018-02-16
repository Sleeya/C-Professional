using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        var input = Console.ReadLine().Split().ToArray();

        int numberOfRectangles = int.Parse(input[0]);
        int intersectionChecks = int.Parse(input[1]);

        List<Rectangle> rectangles = new List<Rectangle>();
        for (int i = 0; i < numberOfRectangles; i++)
        {
            var tokens = Console.ReadLine().Split().ToArray();

            Rectangle currentRectangle = new Rectangle();

            currentRectangle.Id = tokens[0];
            currentRectangle.Width = int.Parse(tokens[1]);
            currentRectangle.Height = int.Parse(tokens[2]);
            currentRectangle.Horizontal = int.Parse(tokens[3]);
            currentRectangle.Vertical = int.Parse(tokens[4]);

            rectangles.Add(currentRectangle);
        }

        for (int i = 0; i < intersectionChecks; i++)
        {
            var pair = Console.ReadLine().Split().ToArray();
            var firstRectangle = rectangles.Find(x => x.Id == pair[0]);
            var secondRectangle = rectangles.Find(x => x.Id == pair[1]);

            bool check = RectanglesIntersect(firstRectangle, secondRectangle);

            if (check)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }

    public static bool RectanglesIntersect(Rectangle rectangle, Rectangle rectangleTwo)
    {

        if (Math.Abs(rectangle.Horizontal) < Math.Abs(rectangleTwo.Horizontal + rectangleTwo.Width))
        {
            if (Math.Abs(rectangle.Horizontal + rectangle.Width) >= Math.Abs(rectangleTwo.Horizontal))
            {
                if (rectangle.Vertical < Math.Abs((rectangleTwo.Vertical - rectangleTwo.Height)))
                {
                    if (Math.Abs(rectangle.Vertical + rectangle.Height) >= Math.Abs(rectangleTwo.Vertical))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}


using System;


class Program
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());

        for (int starCount = 0; starCount < size; starCount++)
        {
            PrintRow(size,starCount);
        }

        for (int starCount = size; starCount >= 0; starCount--)
        {
            PrintRow(size, starCount);
        }
    }

    private static void PrintRow(int size, int starCount)
    {
        for (int i = 0; i < size-starCount; i++)
        {
            Console.Write(" ");
        }

        for (int col = 0; col < starCount; col++)
        {
            Console.Write("* ");
        }

        Console.WriteLine();
    }
}

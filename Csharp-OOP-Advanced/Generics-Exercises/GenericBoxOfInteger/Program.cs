using System;

public class Program
{
    static void Main(string[] args)
    {
        int numerOfStrings = int.Parse(Console.ReadLine());

        for (int i = 0; i < numerOfStrings; i++)
        {
            int input = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>(input);
            Console.WriteLine(box);
        }
    }
}


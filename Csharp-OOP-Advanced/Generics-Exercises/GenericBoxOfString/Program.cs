using System;

public class Program
{
    static void Main(string[] args)
    {
        int numerOfStrings = int.Parse(Console.ReadLine());

        for (int i = 0; i < numerOfStrings; i++)
        {
            string input = Console.ReadLine();

            Box<string> box = new Box<string>(input);
            Console.WriteLine(box);
        }
    }
}


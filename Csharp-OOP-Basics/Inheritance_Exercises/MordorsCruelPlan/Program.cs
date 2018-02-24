using System;
using System.Linq;

class Program
{
    public const int CRAM = 2;
    public const int LEMBAS = 3;
    public const int APPLE = 1;
    public const int MELON = 1;
    public const int HONEYCAKE = 5;
    public const int MUSHROOMS = -10;
    public const int OTHERFOOD = -1;


    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(" ").ToArray();
        long mood = 0;

        foreach (var food in input)
        {
            switch (food.ToLower())
            {
                case "cram":
                    mood += CRAM;
                    break;
                case "lembas":
                    mood += LEMBAS;
                    break;
                case "apple":
                    mood += APPLE;
                    break;
                case "melon":
                    mood += MELON;
                    break;
                case "honeycake":
                    mood += HONEYCAKE;
                    break;
                case "mushrooms":
                    mood += MUSHROOMS;
                    break;
                default:
                    mood += OTHERFOOD;
                    break;
            }
        }

        Console.WriteLine(mood);
        if (mood >= 15)
        {
            Console.WriteLine("JavaScript");
        }
        else if (mood >= 1 && mood < 15)
        {
            Console.WriteLine("Happy");
        }
        else if (mood >= -5 && mood <= 0)
        {
            Console.WriteLine("Sad");
        }
        else
        {
            Console.WriteLine("Angry");
        }
    }
}


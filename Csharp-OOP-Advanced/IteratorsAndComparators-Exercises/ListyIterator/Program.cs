using System;
using System.Linq;
using System.Reflection;

public class Program
{
    static void Main(string[] args)
    {
        var createInput = Console.ReadLine().Split();
        ListyIterator<string> items = new ListyIterator<string>(createInput.Skip(1).ToList());

        string input;
        while ((input = Console.ReadLine()) != "END")
        {

            try
            {
                switch (input)
                {
                    case "Move":
                        Console.WriteLine(items.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(items.HasNext());
                        break;
                    case "Print":
                        items.Print();
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(" ", items));
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}


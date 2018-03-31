using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        MyStack<string> stack = new MyStack<string>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var command = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.TrimEnd(',')).ToArray();
            var commandType = command[0];
            try
            {

                switch (commandType)
                {
                    case "Push":
                        stack.Push(command.Skip(1).ToArray());
                        break;
                    case "Pop":
                        stack.Pop();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

        foreach (var element in stack)
        {
            Console.WriteLine(element);
        }

        foreach (var element in stack)
        {
            Console.WriteLine(element);
        }
    }
}

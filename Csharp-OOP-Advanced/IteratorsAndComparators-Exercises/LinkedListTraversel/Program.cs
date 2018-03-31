using System;

public class Program
{
    static void Main(string[] args)
    {
        MyLinkedList<int> list = new MyLinkedList<int>();
        int numberOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            var input = Console.ReadLine().Split();
            var inputType = input[0];

            switch (inputType)
            {
                case "Add":
                    int numberToAdd = int.Parse(input[1]);
                    list.Add(numberToAdd);
                    break;
                case "Remove":
                    int numberToRemove = int.Parse(input[1]);
                    list.Remove(numberToRemove);
                    break;
            }
        }

        Console.WriteLine(list.Count());
        Console.WriteLine(string.Join(" ",list));
    }
}


using System;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        CustomList<string> list = new CustomList<string>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var parsedInput = input.Split();
            var inputType = parsedInput[0];

            string output = string.Empty;
            switch (inputType)
            {
                case "Add":
                    list.Add(parsedInput[1]);
                    break;
                case "Remove":
                    list.Remove(int.Parse(parsedInput[1]));
                    break;
                case "Contains":
                    output = list.Constains(parsedInput[1]).ToString();
                    break;
                case "Swap":
                    list.Swap(int.Parse(parsedInput[1]), int.Parse(parsedInput[2]));
                    break;
                case "Greater":
                    output = list.CountGreaterThan(parsedInput[1]).ToString();
                    break;
                case "Max":
                    output = list.Max();
                    break;
                case "Min":
                    output = list.Min();
                    break;
                case "Print":
                    StringBuilder builder = new StringBuilder();

                    foreach (var item in list)
                    {
                        builder.AppendLine(item.ToString());
                    }

                    output = builder.ToString().Trim();
                    break;
                case "Sort":
                    list.Sort();
                    break;
            }

            if (output != string.Empty)
            {
                Console.WriteLine(output);
            }

        }
    }
}


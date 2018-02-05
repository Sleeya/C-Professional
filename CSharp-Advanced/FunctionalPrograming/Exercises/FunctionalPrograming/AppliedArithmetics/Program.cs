using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            Func<List<int>, string, List<int>> action = Action;

            string command = String.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command != "print")
                {
                    numbers = Action(numbers, command);
                }
                else
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    
                }
                
            }
        }

        private static List<int> Action(List<int> ints, string assignment)
        {
            switch (assignment)
            {
                case "add":
                    for (int i = 0; i < ints.Count; i++)
                    {
                        ints[i]++;
                    }

                    break;
                case "multiply":
                    for (int i = 0; i < ints.Count; i++)
                    {
                        ints[i] *= 2;
                    }
                    break;
                case "subtract":
                    for (int i = 0; i < ints.Count; i++)
                    {
                        ints[i]--;
                    }
                    break;
               
            }

            return ints;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            var people = new Dictionary<string, int>(numberOfPeople);

            for (int i = 0; i < numberOfPeople; i++)
            {
                var input = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                people.Add(input[0], int.Parse(input[1]));
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var filter = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, age);

            Action<KeyValuePair<string, int>> printer = CreatePrinter(filter);

            PrintFilteredStudent(people, tester, printer);

        }

        private static void PrintFilteredStudent(Dictionary<string, int> people, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in people)
            {
                if (tester(person.Value))
                {
                    printer(person);
                }
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string filter)
        {
            switch (filter)
            {
                case "name":
                    return person => Console.WriteLine(person.Key);
                case "name age":
                    return person => Console.WriteLine($"{person.Key} - {person.Value}");
                case "age":
                    return person => Console.WriteLine($"{person.Value}");
                default: return null;
            }
        }

        private static Func<int, bool> CreateTester(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return x => x < age;
                case "older":
                    return x => x >= age;
                default: return null;
            }
        }
    }
}

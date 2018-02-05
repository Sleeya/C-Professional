using System;
using System.Collections.Generic;
using System.Linq;


namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string,int,bool> isMatch = IsMatch;

            Action<List<string>,int, Func<string, int, bool>> filterNames = FilterNames;

            filterNames(names, number, isMatch);
        }

        private static void FilterNames(List<string> list, int num, Func<string, int, bool> func)
        {
            foreach (var name in list)
            {
                if (func(name,num))
                {
                    Console.WriteLine(name);
                    Environment.Exit(0);
                }
            }
        }

        private static bool IsMatch(string name, int number)
        {
            var sum = 0;
            foreach (var ch in name)
            {
                sum += ch;
            }

            if (sum >= number)
            {
                return true;
            }

            return false;
        }
    }
}

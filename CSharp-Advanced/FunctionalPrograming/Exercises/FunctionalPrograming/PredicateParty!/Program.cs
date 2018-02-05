using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            Func<List<string>, string, string, string, List<string>> gameOn = GameOn;

            var command = new string[3];

            while ((command = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray())[0] != "Party!" && people.Count > 0)
            {
                string action = command[0];
                string criteria = command[1];
                string secondaryCriteria = command[2];

                people = gameOn(people, action, criteria, secondaryCriteria);
            }

            if (people.Count <= 0)
            {
                Console.WriteLine($"Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
        }

        private static List<string> GameOn(List<string> list, string action, string criteria, string secondaryCriteria)
        {
            int listLength = list.Count;
            switch (action)
            {
                case "Double":
                    switch (criteria)
                    {
                        case "StartsWith":
                            for (int i = 0; i < listLength; i++)
                            {
                                if (list[i].StartsWith(secondaryCriteria))
                                {
                                    list.Insert(i+1,list[i]);
                                    i++;
                                    listLength++;
                                }
                            }
                            
                            return list;
                        case "EndsWith":
                            for (int i = 0; i < listLength; i++)
                            {
                                if (list[i].EndsWith(secondaryCriteria))
                                {
                                    list.Insert(i + 1, list[i]);
                                    i++;
                                    listLength++;
                                }
                            }

                            return list;
                        case "Length":
                            for (int i = 0; i < listLength; i++)
                            {
                                if (list[i].Length == int.Parse(secondaryCriteria))
                                {
                                    list.Insert(i + 1, list[i]);
                                    i++;
                                    listLength++;
                                }
                            }

                            return list;
                    }

                    return null;
                case "Remove":
                    switch (criteria)
                    {
                        case "StartsWith":
                            return list.Where(x => !x.StartsWith(secondaryCriteria)).ToList();
                        case "EndsWith":
                            return list.Where(x => !x.EndsWith(secondaryCriteria)).ToList();
                        case "Length":
                            return list.Where(x => x.Length != int.Parse(secondaryCriteria)).ToList();
                    }

                    return null;
            }

            return null;
        }
    }
}

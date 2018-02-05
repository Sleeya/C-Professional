using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
          


            string[] reserve = new string[3];
            List<string> filters = new List<string>();
            while ((reserve = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToArray())[0] != "Print")
            {
                switch (reserve[0])
                {
                    case "Add filter":
                        filters.Add($"{reserve[1]};{reserve[2]}");
                        break;
                    case "Remove filter":
                        filters.Remove($"{reserve[1]};{reserve[2]}");
                        break;
                }
            }

            foreach (var filter in filters)
            {
                var splitFilter = filter.Split(new string[] {";"}, StringSplitOptions.RemoveEmptyEntries).ToList();
                switch (splitFilter[0])
                {
                    case "Starts with":
                        people = people.Where(x => !x.StartsWith(splitFilter[1])).ToList();
                        break;
                    case "Ends with":
                       people =  people.Where(x => !x.EndsWith(splitFilter[1])).ToList();
                        break;
                    case "Length":
                       people =  people.Where(x => x.Length != int.Parse(splitFilter[1])).ToList();
                        break;
                    case "Contains":
                       people = people.Where(x => !x.Contains(splitFilter[1])).ToList();
                        break;
                }
            }

            Console.WriteLine(string.Join(" ",people));
        }



    }
}

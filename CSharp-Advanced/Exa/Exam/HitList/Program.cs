using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> people = new Dictionary<string, Dictionary<string, string>>();

            int targetInfoIndex = int.Parse(Console.ReadLine());
            string[] command;
            while ((command=Console.ReadLine().Split(new string[]{"="},StringSplitOptions.RemoveEmptyEntries).ToArray())[0] != "end transmissions")
            {
                string person = command[0];

                if (!people.ContainsKey(person))
                {
                    people.Add(person,new Dictionary<string, string>());
                }
                
                string[] details = command[1].Split(new string[] {";"}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int i = 0; i < details.Length; i++)
                {
                    string[] tokens = details[i].Split(new string[] {":"}, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    string detailKey = tokens[0];
                    string detailValue = tokens[1].Substring(0, tokens[1].Length);

                    if (!people[person].ContainsKey(detailKey))
                    {
                        people[person].Add(detailKey,detailValue);
                    }
                    else
                    {
                        people[person][detailKey] = detailValue;
                    }
                }
            }

            var killCommand = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)[1];
            Console.WriteLine($"Info on {killCommand}:");
            people[killCommand] = people[killCommand].OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            int num = 0;
            foreach (var detail in people[killCommand])
            {
                Console.WriteLine($"---{detail.Key}: {detail.Value}");
                num += detail.Key.Length;
                num += detail.Value.Length;
            }

            if (num >= targetInfoIndex)
            {
                Console.WriteLine($"Info index: {num}");
                Console.WriteLine($"Proceed");
            }
            else
            {
                Console.WriteLine($"Info index: {num}");
                Console.WriteLine($"Need {Math.Abs(num-targetInfoIndex)} more info.");
            }
        }
    }
}

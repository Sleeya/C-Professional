using System;
using System.Collections.Generic;
using System.Linq;

namespace InfernoIII
{
    class Program
    {
        static void Main(string[] args)
        {
            var gems = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<string> filters = new List<string>();

            string[] filter = new string[3];
            while ((filter = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                       .ToArray())[0] != "Forge")
            {
                switch (filter[0])
                {
                    case "Exclude":
                        filters.Add(filter[1] + ";" + filter[2]);
                        break;
                    case "Reverse":
                        filters.Remove(filter[1] + ";" + filter[2]);
                        break;
                }
            }

            Action<List<int>, string, int,List<int>> match = Match;
            List<int> excludeIndexes = new List<int>();
            foreach (var fil in filters)
            {
                var splitFilter = fil.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                match(gems, splitFilter[0], int.Parse(splitFilter[1]),excludeIndexes);

            }

            int counter = 0;
            foreach (var gem in gems)
            {
                if (!excludeIndexes.Contains(counter))
                {
                    Console.Write(gem + " ");
                }

                counter++;
            }
            
        }

        private static void Match(List<int> ints, string type, int sum, List<int> excludes)
        {
            var sumLeft = 0;
            var sumRight = 0;

            switch (type)
            {
                case "Sum Left":
                    for (int i = 0; i < ints.Count; i++)
                    {
                        if (i == 0)
                        {
                            sumLeft = 0;
                        }
                        else
                        {
                            sumLeft = ints[i - 1];
                        }
                        if (sumLeft + ints[i] == sum)
                        {
                            excludes.Add(i);
                        }
                    }
                    break;
                case "Sum Right":
                    for (int i = 0; i < ints.Count; i++)
                    {
                        if (i == ints.Count - 1)
                        {
                            sumRight = 0;
                        }
                        else
                        {
                            sumRight = ints[i + 1];
                        }
                        if (sumRight + ints[i] == sum)
                        {
                            excludes.Add(i);
                        }
                    }
                    break;
                case "Sum Left Right":
                    for (int i = 0; i < ints.Count; i++)
                    {
                        if (i == 0)
                        {
                            sumLeft = 0;


                        }
                        else
                        {
                            sumLeft = ints[i - 1];

                        }
                        if (i == ints.Count - 1)
                        {
                            sumRight = 0;
                        }
                        else
                        {
                            sumRight = ints[i + 1];

                        }

                        if (sumLeft + ints[i] + sumRight == sum)
                        {
                            excludes.Add(i);
                        }
                    }
                    break;

            }
        }


    }
}

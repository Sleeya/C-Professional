using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());

            var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            long currentCapacity = 0;
            Dictionary<string, Dictionary<string, long>> loot = new Dictionary<string, Dictionary<string, long>>();



            long goldSum = 0;
            long gemSum = 0;
            long cashSum = 0;
            for (int item = 0; item < input.Count; item+=2)
            {
                if (input[item].ToLower() == "gold")
                {
                    long goldAmount = long.Parse(input[item + 1]);

                    if (currentCapacity + goldAmount <= capacity)
                    {
                        goldSum += goldAmount;

                        if (!loot.ContainsKey("<Gold>"))
                        {
                            loot.Add("<Gold>", new Dictionary<string, long>());
                        }

                        if (!loot["<Gold>"].ContainsKey(input[item]))
                        {
                            loot["<Gold>"].Add(input[item], goldAmount);
                        }
                        else
                        {
                            loot["<Gold>"][input[item]] += goldAmount;
                        }

                        currentCapacity += goldAmount;

                    }
                }
                else if (input[item].ToLower().EndsWith("gem") && input[item].Length >= 4)
                {
                    long gemAmount = long.Parse(input[item + 1]);

                    if (currentCapacity + gemAmount <= capacity)
                    {
                        gemSum += gemAmount;
                        if (gemSum <= goldSum)
                        {
                            if (!loot.ContainsKey("<Gem>"))
                            {
                                loot.Add("<Gem>", new Dictionary<string, long>());
                            }

                            if (!loot["<Gem>"].ContainsKey(input[item]))
                            {
                                loot["<Gem>"].Add(input[item], gemAmount);
                            }
                            else
                            {
                                loot["<Gem>"][input[item]] += gemAmount;
                            }

                            currentCapacity += gemAmount;
                        }
                        else
                        {
                            gemSum -= gemAmount;
                        }
                    }
                    
                }
                else if (input[item].Length == 3)
                {
                    long cashAmount = long.Parse(input[item + 1]);
                    cashSum += cashAmount;
                    if (cashSum <= gemSum)
                    {
                        if (currentCapacity + cashAmount <= capacity)
                        {
                            if (!loot.ContainsKey("<Cash>"))
                            {
                                loot.Add("<Cash>", new Dictionary<string, long>());
                            }

                            if (!loot["<Cash>"].ContainsKey(input[item]))
                            {
                                loot["<Cash>"].Add(input[item], cashAmount);
                            }
                            else
                            {
                                loot["<Cash>"][input[item]] += cashAmount;
                            }

                            currentCapacity += cashAmount;
                        }
                    }
                    else
                    {
                        cashSum -= cashAmount;
                    }
                }
            }

        
        loot = loot.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(x => x.Key, y => y.Value);

                foreach (var itemType in loot)
                {
                    Console.WriteLine($"{itemType.Key} ${itemType.Value.Values.Sum()}");
                    foreach (var item in itemType.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                    {
                        Console.WriteLine($"##{item.Key} - {item.Value}");
                    }
}
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

public class Potato
{
    static void Main(string[] args)
    {
        long input = long.Parse(Console.ReadLine());
        string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var loot = new Dictionary<string, Dictionary<string, long>>();

        InsertItems(input, safe, loot);

        PrintLoot(loot);
    }

    private static void InsertItems(long input, string[] safe, Dictionary<string, Dictionary<string, long>> loot)
    {
        long gold = 0;
        long gems = 0;
        long cash = 0;

        for (int i = 0; i < safe.Length; i += 2)
        {
            string itemName = safe[i];
            long itemCount = long.Parse(safe[i + 1]);

            string confirmedItem = string.Empty;

            if (itemName.Length == 3)
            {
                confirmedItem = "Cash";
            }
            else if (itemName.ToLower().EndsWith("gem"))
            {
                confirmedItem = "Gem";
            }
            else if (itemName.ToLower() == "gold")
            {
                confirmedItem = "Gold";
            }

            if (confirmedItem == "")
            {
                continue;
            }
            else if (input < loot.Values.Select(x => x.Values.Sum()).Sum() + itemCount)
            {
                continue;
            }

            switch (confirmedItem)
            {
                case "Gem":
                    if (!loot.ContainsKey(confirmedItem))
                    {
                        if (loot.ContainsKey("Gold"))
                        {
                            if (itemCount > loot["Gold"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (loot[confirmedItem].Values.Sum() + itemCount > loot["Gold"].Values.Sum())
                    {
                        continue;
                    }
                    break;
                case "Cash":
                    if (!loot.ContainsKey(confirmedItem))
                    {
                        if (loot.ContainsKey("Gem"))
                        {
                            if (itemCount > loot["Gem"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (loot[confirmedItem].Values.Sum() + itemCount > loot["Gem"].Values.Sum())
                    {
                        continue;
                    }
                    break;
            }

            AssignItems(loot, ref gold, ref gems, ref cash, itemName, itemCount, confirmedItem);
        }
    }

    private static void AssignItems(Dictionary<string, Dictionary<string, long>> loot, ref long gold, ref long gems, ref long cash, string itemName, long itemCount, string confirmedItem)
    {
        if (!loot.ContainsKey(confirmedItem))
        {
            loot[confirmedItem] = new Dictionary<string, long>();
        }

        if (!loot[confirmedItem].ContainsKey(itemName))
        {
            loot[confirmedItem][itemName] = 0;
        }

        loot[confirmedItem][itemName] += itemCount;
        if (confirmedItem == "Gold")
        {
            gold += itemCount;
        }
        else if (confirmedItem == "Gem")
        {
            gems += itemCount;
        }
        else if (confirmedItem == "Cash")
        {
            cash += itemCount;
        }
    }

    private static void PrintLoot(Dictionary<string, Dictionary<string, long>> loot)
    {
        foreach (var x in loot)
        {
            Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
            foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
            {
                Console.WriteLine($"##{item2.Key} - {item2.Value}");
            }
        }
    }
}

using System;
using System.Collections.Generic;

public class ItemFactory
{
    public static Item CreateItem(string itemName)
    {
        
        switch (itemName)
        {
            case "ArmorRepairKit":
                return new ArmorRepairKit();
            case "HealthPotion":
                return new HealthPotion();
            case "PoisonPotion":
                return new PoisonPotion();
        }

        throw new ArgumentException($"Invalid item \"{itemName}\"!");
    }
}

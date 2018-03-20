using System;
using System.Collections.Generic;

public class CharacterFactory
{
    public static Character CreateCharacter(string faction, string charType, string name)
    {
        var currentFaction = new Faction(faction);
        switch (charType)
        {
            case "Warrior":
                return new Warrior(name, currentFaction);
            case "Cleric":
                return new Cleric(name, currentFaction);
        }

        throw new ArgumentException($"Invalid character type \"{charType}\"!");
    }
}

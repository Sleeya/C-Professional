using System;

public class CharacterFactory
{
    public static Character CreateCharacter(string faction, string charType, string name)
    {
        if (!Enum.TryParse<Faction>(faction, out var parsedFaction))
        {
            throw new ArgumentException($"Invalid faction \"{faction}\"!");
        }
       
        switch (charType)
        {
            case "Warrior":
                return new Warrior(name, parsedFaction);
            case "Cleric":
                return new Cleric(name, parsedFaction);
            default:
                throw new ArgumentException($"Invalid character type \"{charType}\"!");
        }
    }
}

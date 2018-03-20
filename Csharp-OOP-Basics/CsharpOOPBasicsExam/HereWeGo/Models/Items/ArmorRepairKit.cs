using System;

public class ArmorRepairKit:Item
{
    public ArmorRepairKit()
    {
        base.Weight = 10;
    }

    public override void AffectCharacter(Character character)
    {
        if (character.IsAlive == false)
        {
            throw new ArgumentException("Must be alive to perform this action!");
        }

        character.Armor = character.BaseArmor;
    }
}

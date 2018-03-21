using System;

public class ArmorRepairKit:Item
{
    public ArmorRepairKit():base(10)
    {
       
    }

    public override void AffectCharacter(Character character)
    {
        character.ValidateCharacter();

        character.Armor = character.BaseArmor;
    }
}

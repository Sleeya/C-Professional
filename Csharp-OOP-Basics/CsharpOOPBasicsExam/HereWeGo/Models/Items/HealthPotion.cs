using System;

public class HealthPotion:Item
{
    public HealthPotion():base(5)
    {
       
    }

    public override void AffectCharacter(Character character)
    {
        character.ValidateCharacter();

        character.Health += 20;
    }
}

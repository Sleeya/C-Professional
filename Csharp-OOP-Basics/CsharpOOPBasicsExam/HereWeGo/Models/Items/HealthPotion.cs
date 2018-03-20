using System;

public class HealthPotion:Item
{
    public HealthPotion()
    {
        base.Weight = 5;
    }

    public override void AffectCharacter(Character character)
    {
        if (character.IsAlive == false)
        {
            throw new ArgumentException("Must be alive to perform this action!");
        }

        character.Health += 20;
    }
}

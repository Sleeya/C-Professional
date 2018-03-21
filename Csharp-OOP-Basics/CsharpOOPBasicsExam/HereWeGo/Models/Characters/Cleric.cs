using System;

public class Cleric : Character, IHealable
{
    public Cleric(string name, Faction faction)
        : base(name, health: 50, armor: 25, abilityPoints: 40, bag: new Backpack(), faction: faction)
    {
        base.RestHealMultiplier = 0.5;
    }

    public void Heal(Character character)
    {
        this.ValidateCharacter();
        character.ValidateCharacter();

        if (this.Faction != character.Faction)
        {
            throw new InvalidOperationException("Cannot heal enemy character!");
        }

        character.Health += this.AbilityPoints;
    }
}

using System;

public class Warrior : Character, IAttackable
{
    public Warrior(string name, Faction faction)
        : base(name, health: 100, armor: 50, abilityPoints: 40, bag: new Satchel(), faction: faction)
    {
    }

    public void Attack(Character character)
    {
        this.ValidateCharacter();
        character.ValidateCharacter();

        if (this.Name == character.Name)
        {
            throw new InvalidOperationException("Cannot attack self!");
        }

        if (this.Faction == character.Faction)
        {
            throw new ArgumentException($"Friendly fire! Both characters are from {character.Faction} faction!");
        }
        character.TakeDamage(this.AbilityPoints);

    }
}

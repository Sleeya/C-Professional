using System;

public class Warrior:Character,IAttackable
{
    public Warrior(string name, Faction faction, double health = 100, double armor = 50, double abilityPoints = 40, Bag bag = null)
        : base(name, health, armor, abilityPoints, bag, faction)
    {
        base.BaseHealth = 100;
        base.BaseArmor = 50;
        base.Armor = 50;
        base.Bag = new Satchel(20);

    }

    public void Attack(Character character)
    {
        if (this.IsAlive && character.IsAlive)
        {
            if (this.Name == character.Name)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (this.Faction == character.Faction)
            {
                throw  new ArgumentException($"Friendly fire! Both characters are from {character.Faction} faction!");
            }
            character.TakeDamage(this.AbilityPoints);
        }
    }
}

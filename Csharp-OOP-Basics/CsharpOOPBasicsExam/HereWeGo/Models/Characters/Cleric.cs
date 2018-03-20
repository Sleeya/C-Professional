using System;

public class Cleric:Character,IHealable
{
    public Cleric(string name,  Faction faction,double health = 50, double armor = 25, double abilityPoints = 40, Bag bag = null) 
        : base(name, health, armor, abilityPoints, bag, faction)
    {
        base.BaseHealth = 50;
        base.BaseArmor = 25;
        base.Armor = 25;
        base.AbilityPoints = 40;
        base.Bag = new Backpack(100);
        base.RestHealMultiplier = 0.5;
    }

    public void Heal(Character character)
    {
        if (this.IsAlive && character.IsAlive)
        {
            if (this.Faction.Value != character.Faction.Value)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}

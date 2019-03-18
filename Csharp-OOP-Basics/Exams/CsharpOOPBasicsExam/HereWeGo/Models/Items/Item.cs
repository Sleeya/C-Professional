using System;

public abstract class Item
{
    private int weight;

    protected Item(int weight)
    {
        this.Weight = weight;
    }

    public int Weight
    {
        get => this.weight;
        protected set => this.weight = value;
    }

    public virtual void AffectCharacter(Character character)
    {
        if (character.IsAlive == false)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
    }


}

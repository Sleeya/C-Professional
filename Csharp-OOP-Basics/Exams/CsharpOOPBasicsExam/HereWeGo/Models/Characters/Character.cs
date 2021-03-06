﻿using System;
using System.Collections.Generic;

public abstract class Character
{
    private string name;
    private double baseHealth;
    private double health;
    private double baseArmor;
    private double armor;
    private double abilityPoints;
    private Bag bag;
    private Faction faction;
    private bool isAlive = true;
    private double restHealMultiplier = 0.2;

    protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
    {
        this.Name = name;

        this.BaseHealth = health;
        this.Health = health;

        this.BaseArmor = armor;
        this.Armor = armor;

        this.AbilityPoints = abilityPoints;
        this.Bag = bag;
        this.faction = faction;
    }

    public string Name
    {
        get => this.name;
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }

            this.name = value;
        }

    }

    public double BaseHealth
    {
        get => this.baseHealth;
        protected set => this.baseHealth = value;
    }

    public double Health
    {
        get => this.health;
        set
        {
            if (value < 0)
            {
                this.health = 0;
            }
            else if (value > 100)
            {
                this.health = 100;
            }
            else
            {
                this.health = value;
            }
        }
    }

    public double BaseArmor
    {
        get => this.baseArmor;
        protected set => this.baseArmor = value;
    }

    public double Armor
    {
        get => this.armor;
        set
        {
            if (value < 0)
            {
                this.armor = 0;
            }
            else if (value > this.BaseArmor)
            {
                this.armor = this.BaseArmor;
            }
            else
            {
                this.armor = value;
            }
        }
    }

    public double AbilityPoints
    {
        get => this.abilityPoints;
        protected set => this.abilityPoints = value;
    }

    public Bag Bag
    {
        get => this.bag;
        protected set => this.bag = value;
    }

    public bool IsAlive
    {
        get => this.isAlive;
        set => this.isAlive = value;
    }

    public double RestHealMultiplier
    {
        get => this.restHealMultiplier;
        protected set => this.restHealMultiplier = value;
    }

    public Faction Faction
    {
        get => this.faction;
        
    }



    public void TakeDamage(double hitPoints)
    {
        ValidateCharacter();
        double difference = this.Armor - hitPoints;
        this.Armor -= hitPoints;
        if (difference < 0)
        {
            this.Health -= Math.Abs(difference);
            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }


    }

    public void Rest()
    {
        ValidateCharacter();
        if (this.GetType().Name == "Cleric")
        {
            if (this.health + (this.BaseHealth * this.RestHealMultiplier) > 50)
            {
                this.health = 50;
            }

        }
        else
        {
            this.Health += (this.BaseHealth * this.RestHealMultiplier);
        }

    }

    public void UseItem(Item item)
    {
        ValidateCharacter();
        item.AffectCharacter(this);

    }

    public void UseItemOn(Item item, Character character)
    {
        ValidateCharacter();
        character.ValidateCharacter();

        item.AffectCharacter(character);
    }

    public void GiveCharacterItem(Item item, Character character)
    {
        ValidateCharacter();
        character.ValidateCharacter();

        character.Bag.AddItem(item);
    }

    public void ReceiveItem(Item item)
    {
        ValidateCharacter();
        this.Bag.AddItem(item);
    }

    public void ValidateCharacter()
    {
        if (!this.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
    }
}

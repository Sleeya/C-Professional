using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

public abstract class Bag
{
    private int capacity = 100;
    private int load;
    private IReadOnlyCollection<Item> items;

    protected Bag(int capacity)
    {
        this.Capacity = capacity;
        this.Items = new List<Item>();
        this.Load = Items.Sum(x => x.Weight);
       

    }

    public int Capacity
    {
        get => this.capacity;
        protected set => this.capacity = value;
    }

    public int Load
    {
        get => this.load;
        protected set => this.load = value;
    }

    public IReadOnlyCollection<Item> Items
    {
        get => this.items;
        protected set => this.items = value;
    }

    public void AddItem(Item item)
    {
        if (this.Load + item.Weight > this.Capacity)
        {
            throw  new InvalidOperationException("Bag is full!");
        }
        ((List<Item>)this.Items).Add(item);
    }

    public Item GetItem(string name)
    {
        if (this.Items.Count == 0)
        {
            throw new InvalidOperationException("Bag is empty!");
        }

        if (!this.Items.Any(x=>x.GetType().Name==name))
        {
           throw new ArgumentException($"No item with name {name} in bag!");
        }

        Item item = this.Items.FirstOrDefault(x => x.GetType().Name == name);
        ((List<Item>) this.Items).Remove(item);
        return item;
    }



}

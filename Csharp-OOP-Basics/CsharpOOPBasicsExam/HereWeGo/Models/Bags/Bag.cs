using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

public abstract class Bag
{
    private int capacity = 100;
    private int Load => this.items.Sum(x => x.Weight);
    private List<Item> items;

    protected Bag(int capacity)
    {
        this.Capacity = capacity;
        this.items = new List<Item>();

    }

    public int Capacity
    {
        get => this.capacity;
        protected set => this.capacity = value;
    }

    public IReadOnlyCollection<Item> Items
    {
        get => this.items.AsReadOnly();
    }

    public void AddItem(Item item)
    {
        if (this.Load + item.Weight > this.Capacity)
        {
            throw new InvalidOperationException("Bag is full!");
        }
        this.items.Add(item);
    }

    public Item GetItem(string name)
    {
        if (this.Items.Count == 0)
        {
            throw new InvalidOperationException("Bag is empty!");
        }

        if (!this.Items.Any(x => x.GetType().Name == name))
        {
            throw new ArgumentException($"No item with name {name} in bag!");
        }

        Item item = this.Items.FirstOrDefault(x => x.GetType().Name == name);
        this.items.Remove(item);
        return item;
    }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Pizza
{
    private string name;
    private List<Topping> toppings;
    private Dough dough;

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length>15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            name = value;
        }
    }

    private Dough Dough
    {
        get => this.dough;
        set => this.dough = value;

    }

    public Pizza(string name,Dough dough)
    {
        Name = name;
        Dough = dough;
        toppings = new List<Topping>();
    }

    public void AddToppings(Topping topping)
    {
        if (toppings.Count>10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        toppings.Add(topping);
    }

    public double CalcTotalCalories()
    {
        return Dough.Calories + toppings.Sum(x => x.Calories);
    }
}

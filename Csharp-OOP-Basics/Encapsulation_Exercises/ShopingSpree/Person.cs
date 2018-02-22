using System;
using System.Collections.Generic;
using System.Text;


class Person
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            name = value;
        }
    }

    private decimal money;

    public decimal Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            money = value;
        }
    }

    private List<Product> bagOfProducts;

    public IReadOnlyCollection<Product> BagOfProducts
    {
        get { return bagOfProducts.AsReadOnly(); }
    }

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        bagOfProducts = new List<Product>();
    }

    public void BuyProduct(Product product)
    {
        if (Money < product.Cost)
        {
            Console.WriteLine($"{Name} can't afford {product.Name}");
            
        }
        else
        {
            Console.WriteLine($"{Name} bought {product.Name}");
            Money -= product.Cost;
            bagOfProducts.Add(product);
        }
    }

}


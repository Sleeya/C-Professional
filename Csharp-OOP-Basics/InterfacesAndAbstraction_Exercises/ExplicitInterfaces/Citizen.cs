using System;

public class Citizen : IPerson, IResident
{


    private string name;
    private string country;
    private int age;

    public Citizen(string name, string country, int age)
    {
        Name = name;
        Country = country;
        Age = age;
    }

    public string Country
    {
        get => this.country;
        set => this.country = value;
    }


    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public int Age
    {
        get => this.age;
        set => this.age = value;
    }

    void IResident.GetName()
    {
        Console.WriteLine($"Mr/Ms/Mrs {this.name}");
    }

    void IPerson.GetName()
    {
        Console.WriteLine($"{this.name}");
    }
}



public class Citizen : IPerson
{
    private string name;
    private int age;

    public Citizen(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public int Age
    {
        get => this.age;
        set => this.age = value;
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }
}


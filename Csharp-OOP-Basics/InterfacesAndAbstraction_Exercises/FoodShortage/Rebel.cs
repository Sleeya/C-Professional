public class Rebel:IBuyer
{
    private string name;
    private int age;
    private string group;
    private int food;

    public Rebel(string name, int age, string group)
    {
        Name = name;
        Age = age;
        Group = group;
        Food = 0;
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

    public string Group
    {
        get => this.group;
        set => this.group = value;
    }

    public int Food
    {
        get => this.food;
        set => this.food = value;
    }

    public void BuyFood()
    {
        Food += 5;
    }

}


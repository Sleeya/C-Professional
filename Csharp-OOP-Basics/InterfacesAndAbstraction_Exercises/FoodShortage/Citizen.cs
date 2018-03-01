public class Citizen:IBuyer
{
    private string name;
    private int age;
    private string id;
    private string birthday;
    private int food;

    public Citizen(string name,int age,string id,string birthday)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthday = birthday;
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

    public string Id
    {
        get => this.id;
        set => this.id = value;
    }

    public string Birthday
    {
        get => this.birthday;
        set => birthday = value;
    }

    public int Food
    {
        get => this.food;
        set => this.food = value;
    }

    public void BuyFood()
    {
        Food += 10;
    }
}

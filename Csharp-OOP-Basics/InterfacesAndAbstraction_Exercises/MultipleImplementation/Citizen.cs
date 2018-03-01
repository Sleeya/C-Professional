

public class Citizen : IPerson,IBirthable,IIdentifiable
{
    private string name;
    private int age;
    private string id;
    private string birthdate;

    public Citizen(string name, int age,string id,string birthdate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthdate;
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

    public string Birthdate
    {
        get => this.birthdate;
        set => this.birthdate = value;
    }
    public string Name
    {
        get => this.name;
        set => this.name = value;
    }
}


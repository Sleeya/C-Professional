public class Citizen:IIdentifiable,IBirthable
{
    private string name;
    private int age;
    private string id;
    private string birthday;

    public Citizen(string name,int age,string id,string birthday)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthday = birthday;
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

}

public class Citizen:IIdentifiable
{
    private string name;
    private int age;
    private string id;

    public Citizen(string name,int age,string id)
    {
        Name = name;
        Age = age;
        Id = id;
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

}

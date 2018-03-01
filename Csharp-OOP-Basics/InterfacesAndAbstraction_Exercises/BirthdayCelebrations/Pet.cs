public class Pet:IBirthable 
{
    private string name;
    private string birthday;

    public Pet(string name,string birthday)
    {
        Name = name;
        Birthday = birthday;
    }

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public string Birthday
    {
        get => this.birthday;
        set => this.birthday = value;
    }
}

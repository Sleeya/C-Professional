public abstract class Soldier:ISoldier
{
    private string id;
    private string firstName;
    private string lastName;

    public Soldier(string id,string firstName,string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Id
    {
        get => this.id;
        set => this.id = value;
    }

    public string FirstName
    {
        get => this.firstName;
        set => this.firstName = value;
    }

    public string LastName
    {
        get => this.lastName;
        set => this.lastName = value;
    }

    
}


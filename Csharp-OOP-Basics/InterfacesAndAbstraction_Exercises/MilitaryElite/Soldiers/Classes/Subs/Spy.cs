using System.Text;

public class Spy : Soldier, ISpy
{
    private int codeNumber;

    public Spy(string id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
    {
        CodeNumber = codeNumber;
    }

    public int CodeNumber
    {
        get => this.codeNumber;
        set => this.codeNumber = value;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Name: {FirstName} {LastName} Id: {Id}");
        builder.AppendLine($"Code Number: {CodeNumber}");

        return builder.ToString().Trim();
    }
}

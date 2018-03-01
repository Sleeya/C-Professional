using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    private List<string> repairs;

    public Engineer(string id, string firstName, string lastName, double salary, string corps, List<string> repairs) : base(id, firstName, lastName, salary, corps)
    {
        Repairs = repairs;
    }

    public List<string> Repairs
    {
        get => this.repairs;
        set => this.repairs = value;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
        builder.AppendLine($"Corps: {Corps}");
        builder.AppendLine($"Repairs:");
        foreach (var repair in Repairs)
        {
            builder.AppendLine($"  {repair}");
        }

        return builder.ToString().Trim();
    }
}


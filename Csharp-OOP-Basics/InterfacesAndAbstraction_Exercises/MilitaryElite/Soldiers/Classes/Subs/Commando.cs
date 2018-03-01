using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    private List<string> missions;

    public Commando(string id, string firstName, string lastName, double salary, string corps, List<string> missions) : base(id, firstName, lastName, salary, corps)
    {
        Missions = missions;
    }

    public List<string> Missions
    {
        get => this.missions;
        set => this.missions = value;
    }


    public void CompleteMission()
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
        builder.AppendLine($"Corps: {Corps}");
        builder.AppendLine($"Missions:");
        foreach (var mission in Missions)
        {
            builder.AppendLine($"  {mission}");
        }

        return builder.ToString().Trim();
    }
}


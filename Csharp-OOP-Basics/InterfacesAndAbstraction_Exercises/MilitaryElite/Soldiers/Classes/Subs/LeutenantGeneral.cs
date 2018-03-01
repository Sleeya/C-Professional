using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral:Private,ILeutenantGeneral
{
    private List<Private> privates;

    public LeutenantGeneral(string id, string firstName, string lastName,double salary) : base(id, firstName, lastName, salary)
    {
        Privates = new List<Private>();
    }

    public List<Private> Privates
    {
        get => this.privates;
        set => this.privates = value;
    }
    
    public void AddPrivates(Private privatee)
    {
        Privates.Add(privatee);
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
        builder.AppendLine($"Privates:");
        foreach (var privatee in Privates)
        {
            builder.AppendLine($"  {privatee}");
        }

        return builder.ToString().Trim();
    }
}

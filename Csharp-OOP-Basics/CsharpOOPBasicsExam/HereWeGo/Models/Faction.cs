using System;

public class Faction
{
    private string value;

    public Faction(string value)
    {
        this.Value = value;
    }

    public string Value
    {
        get => this.value;
        set
        {
            if (value != "CSharp" && value != "Java")
            {
                
                throw new ArgumentException($"Invalid faction \"{value}\"!");
            }
            this.value = value;
        }
    }
}

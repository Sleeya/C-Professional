using System;

public abstract class SpecialisedSoldier:Private,ISpecialistSoldier
{
    private string corps;

    public string Corps
    {
        get => this.corps;
        set {
            if (value != "Airforces" && value != "Marines")
            {
                throw new ArgumentException("Invalid!");
            }

            corps = value;
        }
    }

    public SpecialisedSoldier(string id, string firstName, string lastName, double salary,string corps) : base(id, firstName, lastName, salary)
    {
        Corps = corps;
    }


}

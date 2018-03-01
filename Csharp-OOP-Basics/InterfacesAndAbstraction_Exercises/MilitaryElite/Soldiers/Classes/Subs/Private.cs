public class Private:Soldier,IPrivate
{
    private double salary;

    public Private(string id, string firstName, string lastName,double salary) : base(id, firstName, lastName)
    {
        Salary = salary;
    }

    public double Salary
    {
        get=>this.salary;
        set=>this.salary=value;
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}";
    }
}

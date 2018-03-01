using System.Text;

public class Ferrari:ICar
{
    public string Model { get; }
    public string Name { get; set; }

    public Ferrari(string name)
    {
        Name = name;
        Model = "488-Spider";
    }

    public string Brakes()
    {
        return "Brakes!";
    }

    public string GasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{Model}/{Brakes()}/{GasPedal()}/{Name}";
    }
}

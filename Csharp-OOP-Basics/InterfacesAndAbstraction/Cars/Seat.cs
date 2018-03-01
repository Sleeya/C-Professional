
using System.Text;

public class Seat : ICar
{
    public string Model { get; set; }
    public string Color { get; set; }
    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaak!";
    }

    public Seat(string model,string color)
    {
        this.Model = model;
        this.Color = color;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"{Color} {GetType()} {Model}");
        builder.AppendLine($"{Start()}");
        builder.AppendLine($"{Stop()}");

        return builder.ToString().Trim();
    }
}


public class Robot:IIdentifiable
{
    private string model;
    private string id;

    public Robot(string model,string id)
    {
        Model = model;
        Id = id;
    }

    public string Model
    {
        get => this.model;
        set => this.model = value;
    }

    public string Id
    {
        get => this.id;
        set => this.id = value;
    }
}

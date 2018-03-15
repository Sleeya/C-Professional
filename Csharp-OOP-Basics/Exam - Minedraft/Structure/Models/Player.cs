public abstract class Player
{
    private string id;

    protected Player(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get => this.id;
        private set => this.id = value;
    }
}
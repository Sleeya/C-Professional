public class ThreeTuple<T1,T2,T3>
{
    private T1 itemOne;
    private T2 itemTwo;
    private T3 itemThree;

    public ThreeTuple(T1 itemOne,T2 itemTwo,T3 itemThree)
    {
        this.ItemOne = itemOne;
        this.ItemTwo = itemTwo;
        this.ItemThree = itemThree;
    }

    public T1 ItemOne
    {
        get => this.itemOne;
        set => this.itemOne = value;
    }

    public T2 ItemTwo
    {
        get => this.itemTwo;
        set => this.itemTwo = value;
    }

    public T3 ItemThree
    {
        get => this.itemThree;
        set => this.itemThree = value;
    }

    public override string ToString()
    {
        return $"{this.itemOne} -> {this.itemTwo} -> {this.itemThree}";
    }
}

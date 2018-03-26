public class MyTuple<T1,T2>
{
    private T1 itemOne;
    private T2 itemTwo;

    public MyTuple(T1 itemOne,T2 itemTwo)
    {
        this.itemOne = itemOne;
        this.itemTwo = itemTwo;
    }

    public override string ToString()
    {
        return $"{this.itemOne} -> {this.itemTwo}";
    }
}

using System.Collections.Generic;

public class StackOfStrings
{
    private List<string> data = new List<string>();

    public void Push(string item)
    {
        data.Add(item);
    }

    public string Pop()
    {
        string item = data[data.Count - 1];
        data.Remove(item);
        return item;
    }

    public string Peek()
    {
        return data[data.Count - 1];
    }

    public bool IsEmpty()
    {
        return data.Count == 0;
    }


}


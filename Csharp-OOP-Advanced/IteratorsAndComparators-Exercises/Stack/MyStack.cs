using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MyStack<T>:IEnumerable<T>
{
    private List<T> data;

    public MyStack()
    {
        this.data = new List<T>();
    }

    public void Push(params T[] elements)
    {
        foreach (var element in elements)
        {
            this.data.Add(element);
        }
    }

    public void Pop()
    {
        if (this.data.Count== 0)
        {
            throw new InvalidOperationException("No elements");
        }
        this.data.RemoveAt(data.Count-1);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = data.Count-1; i >= 0; i--)
        {
            yield return data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

public class MyLinkedList<T> : IEnumerable<T>
{
    private LinkedList<T> data;

    public MyLinkedList()
    {
        this.data = new LinkedList<T>();
    }

    public void Add(T element)
    {
        this.data.AddLast(element);

    }

    public bool Remove(T element)
    {
        if (this.data.Contains(element))
        {
            this.data.Remove(element);
            return true;
        }

        return false;
    }

    public int Count()
    {
        return this.data.Count;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in this.data)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

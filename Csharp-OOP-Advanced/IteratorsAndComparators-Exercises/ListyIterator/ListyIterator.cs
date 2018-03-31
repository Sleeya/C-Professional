using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T>:IEnumerable<T>
{
    private List<T> data;
    private int index;
    public ListyIterator(ICollection<T> data)
    {
        this.data = new List<T>(data);
    }

    public bool Move()
    {
        if (index + 1 <= data.Count - 1)
        {
            index++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        return index + 1 <= data.Count - 1;
    }

    public void Print()
    {
        if (this.data.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(this.data[this.index]);
    }

   

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < data.Count; i++)
        {
            yield return data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

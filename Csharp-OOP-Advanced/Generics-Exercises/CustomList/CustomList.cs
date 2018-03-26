using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

public class CustomList<T> : IEnumerable where T:IComparable<T>
{
    private List<T> data;

    public CustomList()
    {
        this.data= new List<T>();
    }

    public void Add(T elemenet)
    {
        this.data.Add(elemenet);
    }

    public void Remove(int index)
    {
        this.data.RemoveAt(index);
    }

    public bool Constains(T element)
    {
        return this.data.Contains(element);
    }

    public void Swap(int indexOne, int indexTwo)
    {
        T temp = this.data[indexOne];
        this.data[indexOne] = this.data[indexTwo];
        this.data[indexTwo] = temp;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;

        foreach (var item in data)
        {
            if (item.CompareTo(element) > 0)
            {
                count++;
            }
        }

        return count;
    }

    public T Max()
    {
        return this.data.Max();
    }

    public T Min()
    {
        return this.data.Min();
    }

    public void Sort()
    {
       this.data =  this.data.OrderBy(x => x).ToList();
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < this.data.Count; i++)
        {
            yield return this.data[i];
        }
    }
}

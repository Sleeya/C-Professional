using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Database
{
    private const int Capacity = 16;
    private int freeCellIndex;


    private int[] ints;

    public Database()
    {
        this.ints = new int[Capacity];
        this.freeCellIndex = 0;
    }

    public Database(params int[] nums) : this()
    {
        if (nums.Length > Capacity)
        {
            throw new InvalidOperationException("Constructor cannot take more than 16 arguments.");
        }
        if (nums != null)
        {
            foreach (var num in nums)
            {
                this.Add(num);
            }
        }

    }

    public void Add(int num)
    {
        if (freeCellIndex == ints.Length)
        {
            throw new InvalidOperationException("Cannot add more elements.");
        }
        this.ints[freeCellIndex] = num;
        freeCellIndex++;
    }

    public void Remove()
    {
        if (freeCellIndex == 0)
        {
            throw new InvalidOperationException("Cannot remove element from empty database.");
        }
        this.ints[ints.Length - 1] = 0;
        freeCellIndex--;
    }

    public int[] Fetch()
    {
        return this.ints.Take(this.freeCellIndex).ToArray();
    }


}


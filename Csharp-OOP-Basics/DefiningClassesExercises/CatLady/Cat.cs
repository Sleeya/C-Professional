using System;
using System.Collections.Generic;
using System.Text;


class Cat
{
    private string breed;
    private string name;
    private int earSize;
    private decimal furLenght;
    private decimal decibelsOfMeows;

    public string Breed
    {
        get { return this.breed; }
        set { this.breed = value; }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    public int EarSize
    {
        get { return this.earSize; }
        set { this.earSize = value; }
    }
    public decimal FurLength
    {
        get { return this.furLenght; }
        set { this.furLenght = value; }
    }
    public decimal DecibelsOfMeows
    {
        get { return this.decibelsOfMeows; }
        set { this.decibelsOfMeows = value; }
    }

}


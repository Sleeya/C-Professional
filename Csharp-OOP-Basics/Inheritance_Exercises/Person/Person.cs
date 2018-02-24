using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;
    internal int age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public virtual string Name
    {
        get => this.name;
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length < 3)
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }
            name = value;
        }
    }

    public virtual int Age
    {
        get => this.age;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }

            age = value;
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
            this.Name,
            this.Age));

        return stringBuilder.ToString();

    }
}


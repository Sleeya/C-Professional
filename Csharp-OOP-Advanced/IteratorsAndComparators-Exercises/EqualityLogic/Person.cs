using System;

public class Person:IComparable<Person>
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; set; }

    public int Age { get; set; }

    public int CompareTo(Person other)
    {
        int result = this.Name.CompareTo(other.Name);
        if (result==0)
        {
            result = this.Age.CompareTo(other.Age);
        }

        return result;
    }

    public override bool Equals(object obj)
    {
        return this.Name.Equals(((Person)obj).Name) && this.Age.Equals(((Person)obj).Age);
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode() + this.Age.GetHashCode();
    }
}

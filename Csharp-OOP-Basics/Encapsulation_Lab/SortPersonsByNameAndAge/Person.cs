using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public string FirstName
    {
        get { return this.firstName; }
    }

    public string LastName
    {
        get { return this.lastName; }
    }

    public int Age
    {
        get { return this.age; }
    }

    public decimal Salary
    {
        get { return this.salary; }
    }
    public Person(string FirstName, string LastName, int Age,decimal Salary)
    {
        firstName = FirstName;
        lastName = LastName;
        age = Age;
        salary = Salary;
    }

    public void IncreaseSalary(decimal bonus)
    {
        if (age>= 30)
        {
            salary = salary + salary * (bonus / 100);
        }
        else
        {
            salary = salary + salary * (bonus / 200);
        }
        
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} receives {Salary:f2} leva.";
    }

    
}

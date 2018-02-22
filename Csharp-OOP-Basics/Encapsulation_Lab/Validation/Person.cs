using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


public class Person
{
    private const decimal MIN_SALARY = 460;
    private const int MIN_LENGTH = 3;
    private const int MIN_AGE = 0;

    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (value.Length < MIN_LENGTH)
            {
                throw new ArgumentException($"First name cannot contain fewer than {MIN_LENGTH} symbols!");
            }

            firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (value.Length < MIN_LENGTH)
            {
                throw new ArgumentException($"Last name cannot contain fewer than {MIN_LENGTH} symbols!");
            }

            lastName = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value <= MIN_AGE)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }

            age = value;
        }
    }

    public decimal Salary
    {
        get { return this.salary; }
        set
        {
            if (value < MIN_SALARY)
            {
                throw new ArgumentException($"Salary cannot be less than {MIN_SALARY} leva!");
            }

            salary = value;
        }
    }
    public Person(string FirstName, string LastName, int Age, decimal Salary)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Age = Age;
        this.Salary = Salary;
    }

    public void IncreaseSalary(decimal bonus)
    {
        if (age >= 30)
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

using System;
using System.Collections.Generic;
using System.Text;


public class Worker : Human
{
    private double weekSalary;
    private double workHoursPerDay;
    

    public Worker(string firstName,string lastName,double weekSalary, double workHoursPerDay) : base(firstName,lastName)
    {
        WeekSalary = weekSalary;
        WorkhoursPerDay = workHoursPerDay;
    }

    public double WeekSalary
    {
        get => this.weekSalary;
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
            }

            weekSalary = value;
        }

    }

    public double WorkhoursPerDay
    {
        get => this.workHoursPerDay;
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
            }

            workHoursPerDay = value;
        }
    }

    public double CalcMoneyPerHour()
    {
        return WeekSalary / (WorkhoursPerDay * 5);
    }
    public override string ToString()
    {
        return $"First Name: {base.FirstName}\r\nLast Name: {base.LastName}" +
               $"\r\nWeek Salary: {WeekSalary:f2}\r\nHours per day: {WorkhoursPerDay:f2}\r\nSalary per hour: {CalcMoneyPerHour():f2}".TrimEnd();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Student:Human
{
    private string facultyNumber;

    public Student(string firstName,string lastName, string facultyNumber):base(firstName,lastName)
    {
        FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get => this.facultyNumber;
        set
        {
            if (IsValidNumber(value))
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            facultyNumber = value;
        }
    }

    private bool IsValidNumber(string value)
    {
        return string.IsNullOrEmpty(value) || value.Length < 5 || value.Length > 10 || value.Any(x=>!Char.IsLetterOrDigit(x));
    }



    public override string ToString()
    {
        return $"First Name: {base.FirstName}\r\nLast Name: {base.LastName}\r\nFaculty number: {this.FacultyNumber}".TrimEnd();
    }
}


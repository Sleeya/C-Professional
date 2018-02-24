using System;
using System.Collections.Generic;
using System.Text;


public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName,string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName
    {
        get => this.firstName;
        set
        {
            if (Char.IsLower(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: firstName");
            }

            if (value.Length <= 3)
            {
                throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
            }

           
            
            firstName = value;
        }
    }

    public string LastName
    {
        get => this.lastName;

        set
        {
            if (Char.IsLower(value[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: lastName");
            }
            if (value.Length < 3)
            {
                throw new ArgumentException($"Expected length at least 3 symbols! Argument: lastName");
            }
            
           

            lastName = value;
        }
    }

    
}


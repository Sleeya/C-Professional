using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            var input = command.Split();

            people.Add(new Person(input[0], int.Parse(input[1]), input[2]));
        }

        int indexOfPersonToCompare = int.Parse(Console.ReadLine());

        Person comparedPerson = people[indexOfPersonToCompare - 1];

        int numberOfEqualPeople = 1;
        int numberOfNotEqualPeople = 0;
        foreach (var person in people)
        {
            if (person != comparedPerson)
            {
                int result = comparedPerson.CompareTo(person);
                if (result == 0)
                {
                    numberOfEqualPeople++;
                }
                else
                {
                    numberOfNotEqualPeople++;
                }
            }
        }

        if (numberOfEqualPeople == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{numberOfEqualPeople} {numberOfNotEqualPeople} {people.Count}");
        }
    }
}


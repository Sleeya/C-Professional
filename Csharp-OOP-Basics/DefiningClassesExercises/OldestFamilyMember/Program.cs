using System;

class Program
{
    static void Main(string[] args)
    {

        int numberOfpeople = int.Parse(Console.ReadLine());

        Family currentFamily = new Family();
        for (int i = 0; i < numberOfpeople; i++)
        {
            Person currentPerson = new Person();
            string[] person = Console.ReadLine().Split();
            currentPerson.Name = person[0];
            currentPerson.Age = int.Parse(person[1]);
            currentFamily.AddMember(currentPerson);
        }

       Person oldestPerson = currentFamily.GetOldestMember();

        Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");


    }
}


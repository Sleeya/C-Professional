using System;

public class Program
{
    static void Main(string[] args)
    {

        var personDetails = Console.ReadLine().Split();
        string personName = personDetails[0] + " " + personDetails[1];
        string personAdress = personDetails[2];
        MyTuple<string, string> personTuple = new MyTuple<string, string>(personName, personAdress);
        

        var drunkInput = Console.ReadLine().Split();
        string name = drunkInput[0];
        int beer = int.Parse(drunkInput[1]);
        MyTuple<string, int> drunkTuple = new MyTuple<string, int>(name, beer);

        var nums = Console.ReadLine().Split();
        int numOne = int.Parse(nums[0]);
        double numTwo = double.Parse(nums[1]);
        MyTuple<int, double> numTuple = new MyTuple<int, double>(numOne, numTwo);


        Console.WriteLine(personTuple);
        Console.WriteLine(drunkTuple);
        Console.WriteLine(numTuple);


    }
}


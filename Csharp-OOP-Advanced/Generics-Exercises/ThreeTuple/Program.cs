using System;

public class Program
{
    static void Main(string[] args)
    {
        var personDetails = Console.ReadLine().Split();
        string personName = personDetails[0] + " " + personDetails[1];
        string personAdress = personDetails[2];
        string town = personDetails[3];
        ThreeTuple<string, string,string> personTuple = new ThreeTuple<string, string,string>(personName, personAdress,town);


        var drunkInput = Console.ReadLine().Split();
        string name = drunkInput[0];
        int beer = int.Parse(drunkInput[1]);
        bool drunkOrNot = drunkInput[2] == "drunk";
      
        ThreeTuple<string, int,bool> drunkTuple = new ThreeTuple<string, int, bool>(name, beer,drunkOrNot);

        var bankBalance = Console.ReadLine().Split();
        string accountName = bankBalance[0];
        double accountBalance = double.Parse(bankBalance[1]);
        string bankName = bankBalance[2];

        ThreeTuple<string, double,string> numTuple = new ThreeTuple<string, double,string>(accountName, accountBalance, bankName);


        Console.WriteLine(personTuple);
        Console.WriteLine(drunkTuple);
        Console.WriteLine(numTuple);
    }
}

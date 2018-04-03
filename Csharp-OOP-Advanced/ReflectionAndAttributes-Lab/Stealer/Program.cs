using System;

public class Program
{
    static void Main(string[] args)
    {
        Spy spy = new Spy();
        Console.WriteLine(spy.CollectGettersAndSetters("Hacker"));
       
    }
}


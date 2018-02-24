using System;
using System.Collections.Generic;
using System.Text;

public class Tomcat : Cat
{
    public Tomcat(string name, int age, string gender):base(name,age,gender)
    {

    }

    

    public override void ProduceSound()
    {
        Console.WriteLine("MEOW");
    }
}


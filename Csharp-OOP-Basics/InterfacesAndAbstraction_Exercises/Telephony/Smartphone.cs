using System;
using System.Linq;

public class Smartphone:IAbleToCall,IBrowseable
{
    private string[] callNumbers;
    private string[] websites;

    public Smartphone(string[] callNumbers,string[] websites)
    {
        CallNumbers = callNumbers;
        Websites = websites;
    }

    public string[] CallNumbers
    {
        get => this.callNumbers;
        set => this.callNumbers = value;
    }

    public string[] Websites
    {
        get => this.websites;
        set => this.websites=value;
    }

    public void Call()
    {
        foreach (var callNumber in CallNumbers)
        {
            if (callNumber.Any(Char.IsLetter))
            {
                Console.WriteLine($"Invalid number!");
            }
            else
            {
                Console.WriteLine($"Calling... {callNumber}");
            }
          
        }
    }

    public void Browse()
    {
        foreach (var website in Websites)
        {
            if (website.Any(Char.IsDigit))
            {
                Console.WriteLine($"Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {website}!");
            }
            
        }
    }
}


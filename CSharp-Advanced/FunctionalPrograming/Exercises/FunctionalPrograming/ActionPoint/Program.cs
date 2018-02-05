using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string> printName = x => Console.WriteLine(x);

            foreach (var name in input)
            {
                printName(name);
            }



        }
    }
}

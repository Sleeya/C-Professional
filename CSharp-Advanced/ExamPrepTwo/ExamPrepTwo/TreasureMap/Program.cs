using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TreasureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string pattern = @"((?<hash>#)|!)[^#!]*?(?<![A-Za-z0-9])(?<streetName>[A-Za-z]{4})(?![A-Za-z0-9])[^#!]*(?<!\d)(?<streetNumber>\d{3})-(?<password>\d{4}|\d{6})(?!\d)[^#!]*?(?(hash)!|#)";

            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                MatchCollection matches = Regex.Matches(Console.ReadLine(), pattern);

                int matchStartIndex = matches.Count / 2;
                
                Console.WriteLine($"Go to str. {matches[matchStartIndex].Groups["streetName"].Value} {matches[matchStartIndex].Groups["streetNumber"].Value}. Secret pass: {matches[matchStartIndex].Groups["password"].Value}.");
               

                

            }
        }
    }
}

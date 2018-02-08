using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text.RegularExpressions;


namespace Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"[A-Za-z]+<(\d+)REGEH(\d+)>[A-Za-z]+";

            MatchCollection matches = Regex.Matches(input, pattern);
            List<int> indexes = new List<int>();
          
            foreach (Match match in matches)
            {
               indexes.Add(int.Parse(match.Groups[1].Value)+indexes.LastOrDefault());
                indexes.Add(int.Parse(match.Groups[2].Value)+indexes.Last());
            }

            foreach (var index in indexes)
            {
                Console.Write(input[index%input.Length]);
            }
        }
    }
}

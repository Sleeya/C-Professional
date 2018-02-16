using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CryptoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOflines = int.Parse(Console.ReadLine());
            string line = string.Empty;
            for (int i = 0; i < numberOflines; i++)
            {
                string currentLine = Console.ReadLine();
                line += currentLine;
            }

            string pattern = @"(?:{|\[).*?(\d{3,}).*?(?<=}|\])";
            char[] alphabet = "abcdefghijklmnopqrstuvxyzABCDEFGHIJKLMNOPQRSTUVWXYS1234567890".ToCharArray();
            MatchCollection matches = Regex.Matches(line, pattern);

            foreach (Match match in matches)
            {
                string currentMatch = match.Groups[0].ToString();
                if (currentMatch.StartsWith("[") && currentMatch.EndsWith("]") || currentMatch.StartsWith("{") && currentMatch.EndsWith("}"))
                {
                    if (match.Groups[0].ToString().Any(x=>alphabet.Contains(x)))
                    {
                        if (match.Groups[1].Length % 3 == 0)
                        {
                            string digits = match.Groups[1].ToString();
                            for (int i = 0; i < match.Groups[1].Length; i+=3)
                            {
                                int currentDigit = int.Parse(digits.Substring(i,3));
                                Console.Write((char)(currentDigit-match.Length));
                            }
                        }
                    }
                }
            }
        }
    }
}

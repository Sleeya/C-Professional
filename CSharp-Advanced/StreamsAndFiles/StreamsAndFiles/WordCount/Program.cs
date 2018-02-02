using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> results = new Dictionary<string, int>();

            using (StreamReader wordReader = new StreamReader("words.txt"))
            {
                using (StreamReader textReader = new StreamReader("text.txt"))
                {
                    using (StreamWriter writer = new StreamWriter("result.txt"))
                    {
                        string line = textReader.ReadToEnd().ToLower();
                        string word = wordReader.ReadLine();

                        while (word != null)
                        {
                            string matchPattern = $@"\b{word}\b";

                            MatchCollection matches = Regex.Matches(line, matchPattern);

                            results.Add(word, matches.Count);

                            word = wordReader.ReadLine();
                        }

                        foreach (var result in results.OrderByDescending(x=>x.Value))
                        {
                            writer.WriteLine($"{result.Key}-{result.Value}");
                        }

                    }
                }
            }
        }
    }
}


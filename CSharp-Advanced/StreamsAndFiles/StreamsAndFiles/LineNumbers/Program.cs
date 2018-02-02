using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    string line = reader.ReadLine();
                    int counter = 1;
                    while (line != null)
                    {
                        writer.WriteLine($"Line {counter}:{line}");
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}

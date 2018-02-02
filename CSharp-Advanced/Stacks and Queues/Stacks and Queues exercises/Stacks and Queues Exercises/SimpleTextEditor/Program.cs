using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> oldVersion = new Stack<string>();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ').ToArray();
                int action = int.Parse(command[0]);
                if (action==1)
                {
                    oldVersion.Push(text.ToString());
                    string inputText = command[1];
                    text.Append(inputText);
                }
                else if (action==2)
                {
                    oldVersion.Push(text.ToString());
                    int numberOfErases = int.Parse(command[1]);
                    text.Remove(text.Length - numberOfErases, numberOfErases);
                }
                else if (action==3)
                {
                    int indexToPrint = int.Parse(command[1]);
                    Console.WriteLine(text[indexToPrint-1]);
                }
                else if (action==4)
                {
                    text.Clear();
                    text.Append(oldVersion.Pop());
                }
            }
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;


namespace numberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> firstPlayer = new Queue<string>(Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

            Queue<string> secondPlayer = new Queue<string>(Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            int turns = 0;

            while (true)
            {
                 var loot = new Dictionary<int,string>();

                int numOne = int.Parse(firstPlayer.Peek().Substring(0, firstPlayer.Peek().Length - 1));
                 int numTwo = int.Parse(secondPlayer.Peek().Substring(0, secondPlayer.Peek().Length - 1));

                loot.Add(numOne,firstPlayer.Peek().Substring(firstPlayer.Peek().Length-1));
                loot.Add(numOne, secondPlayer.Peek().Substring(secondPlayer.Peek().Length - 1));
                firstPlayer.Dequeue();
                secondPlayer.Dequeue();
                if (numOne > numTwo)
                {
                    loot = loot.OrderByDescending(x => x.Key).ToDictionary(x=>x.Key,y=>y.Value);
                    foreach (var card in loot)
                    {
                        Console.WriteLine(card.Key+card.Value);
                    }
                }
                else if (numTwo > numOne)
                {
                    
                }
            }

        }
    }
}

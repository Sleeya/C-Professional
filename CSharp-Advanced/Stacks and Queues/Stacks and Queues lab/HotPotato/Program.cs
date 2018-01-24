using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> players = new Queue<string>(Console.ReadLine().Split(' '));

            int burnToss = int.Parse(Console.ReadLine());

            while (players.Count>1)
            {
                for (int i = 1; i <= burnToss; i++)
                {
                    if (i!=burnToss)
                    {
                        string currentPlayer = players.Dequeue();
                        players.Enqueue(currentPlayer);
                    }
                    else
                    {
                        Console.WriteLine($"Removed {players.Dequeue()}");
                    }
                }
            }
            Console.WriteLine($"Last is {players.Dequeue()}");
        }
    }
}

using System;
using System.Linq;

namespace TheHeiganDance
{
    class Program
    {
        private static int[,] matrix;
        private static int player;
        private static double boss;
        private static int[] playerPosition;
        private static int matrixRow;
        private static int matrixCol;
        static void Main(string[] args)
        {

            matrix = new int[15, 15];
            matrixRow = 15;
            matrixCol = 15;
            player = 18500;
            boss = 3000000;
            playerPosition = new int[2];
            playerPosition[0] = 7;
            playerPosition[1] = 7;

            double damage = double.Parse(Console.ReadLine());

            while (player >= 0 && boss >= 0)
            {
                string[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string spell = input[0];
                int impactRow = int.Parse(input[1]);
                int impactColumn = int.Parse(input[2]);

                boss -= damage;

                bool hasMoved = false;
                int playerRow = playerPosition[0];
                int playerCol = playerPosition[1];
                if (impactRow != playerRow && impactColumn != playerCol)
                {
                    if (playerRow+1>=0 && )
                    {
                        
                    }
                }

            }

        }


    }
}

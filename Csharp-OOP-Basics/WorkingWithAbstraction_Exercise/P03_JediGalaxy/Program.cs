using System;
using System.Linq;


class Program
{
    static void Main()
    {
        int[] dimensions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int[,] matrix = InitializeMatrix(dimensions);

        string command;
        long sumOfStars = 0;
        while ((command = Console.ReadLine()) != "Let the Force be with you")
        {
            sumOfStars = CalculateStars(matrix, command, sumOfStars);

        }

        Console.WriteLine(sumOfStars);

    }

    private static long CalculateStars(int[,] matrix, string command, long sum)
    {
        int[] ivoRowAndCol = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int xE = evil[0];
        int yE = evil[1];

        while (xE >= 0 && yE >= 0)
        {
            if (xE >= 0 && xE < matrix.GetLength(0) && yE >= 0 && yE < matrix.GetLength(1))
            {
                matrix[xE, yE] = 0;
            }
            xE--;
            yE--;
        }

        int ivoRow = ivoRowAndCol[0];
        int ivoCol = ivoRowAndCol[1];

        while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
        {
            if (ivoRow >= 0 && ivoRow < matrix.GetLength(0) && ivoCol >= 0 && ivoCol < matrix.GetLength(1))
            {
                sum += matrix[ivoRow, ivoCol];
            }

            ivoCol++;
            ivoRow--;
        }

        return sum;
    }

    private static int[,] InitializeMatrix(int[] dimensions)
    {
        int x = dimensions[0];
        int y = dimensions[1];

        int[,] matrix = new int[x, y];

        int value = 0;
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                matrix[i, j] = value++;
            }
        }

        return matrix;
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

namespace PoisonousPlant
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPlants = int.Parse(Console.ReadLine());

            Queue<long> numbers = new Queue<long>(Console.ReadLine().Split(' ').Select(long.Parse));
            Queue<long> tempQue = new Queue<long>();
           
            
            for (int j = 0; j < numberOfPlants*numberOfPlants; j++)
            {
                Queue<int> indexesToDelete = new Queue<int>();
                int checks = numbers.Count;
                
                for (int i = 0; i < checks; i++)
                {
                    long temp = numbers.Dequeue();
                    tempQue.Enqueue(temp);
                    if (i == checks-1)
                    {
                        break;
                    }
                    if (numbers.Peek()>temp)
                    {
                       
                        indexesToDelete.Enqueue(i+1);
                    }
                    
                }
                if (indexesToDelete.Count==0)
                {
                    Console.WriteLine(j);
                    Environment.Exit(0);
                }
                int plantsToReCheck = tempQue.Count;
                for (int i = 0; i < plantsToReCheck; i++)
                {
                    if (!indexesToDelete.Contains(i))
                    {
                        numbers.Enqueue(tempQue.Dequeue());
                    }
                    else
                    {
                        tempQue.Dequeue();
                    }
                }
                
            }
        }
    }
}

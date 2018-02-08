using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[]{", "},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            long maxLength = 0;


            for (int step = 1; step < input.Count; step++)
            {
                
                for (int stepIndex = 0; stepIndex < input.Count; stepIndex++)
                {
                    int currentLenght = 1;
                    int currentIndex = stepIndex ;
                    int nextIndex = (currentIndex + step) % input.Count;
                    while (input[currentIndex] < input[nextIndex])
                    {
                        currentLenght++;
                        currentIndex = nextIndex;
                        nextIndex = (currentIndex + step) % input.Count;

                    }

                    if (currentLenght>maxLength)
                    {
                        maxLength = currentLenght;
                    }


                }
            }

            Console.WriteLine(maxLength);
            
        }
    }
}

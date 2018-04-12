using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleSortTest
{
    public class Buble
    {
        private int[] numbers;

        public Buble(params int[] numbers)
        {
            this.numbers = numbers;
        }

        public string Sort()
        {
            var needsSorting = true;
            while (needsSorting)
            {
                bool hasSorted = false;
                for (int i = 0; i < numbers.Length-1; i++)
                {
                    if (numbers[i]> numbers[i+1])
                    {
                        var temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;
                        hasSorted = true;
                    }
                }

                if (!hasSorted)
                {
                    needsSorting = false;
                }
            }

            return string.Join(" ", numbers);
        }
    }
}

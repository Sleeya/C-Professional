using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorTest
{
    public class ListIterator
    {
        private List<string> items;
        private int internalIndexPosition = 0;
        public ListIterator(params string[] items)
        {
            ValidateItems(items);
            this.items = new List<string>(items);
        }

        public bool Move()
        {
            if (internalIndexPosition + 1 > this.items.Count-1)
            {
                return false;
            }

            internalIndexPosition++;

            return true;
        }

        public bool HasNext()
        {
            if (internalIndexPosition == this.items.Count -1)
            {
                return false;
            }

            return true;
        }

        public void Print()
        {
            if (this.items.Count ==0)
            {
                throw new InvalidOperationException("Cannot print items off empty collection.");
            }

            Console.WriteLine(this.items[internalIndexPosition]);
           
        }

        private void ValidateItems(string[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}

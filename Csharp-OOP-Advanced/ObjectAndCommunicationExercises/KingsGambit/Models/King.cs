using System;
using System.Collections.Generic;
using System.Text;
using KingsGambit.Contracts;


namespace KingsGambit
{
    public class King :IKing,IAttackable
    {
        public event EventHandler UnderAttack;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void RespondUnderAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            this.UnderAttack?.Invoke(this, new EventArgs());
        }

      
    }
}

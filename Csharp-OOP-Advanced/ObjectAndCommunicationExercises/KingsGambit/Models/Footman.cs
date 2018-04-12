using System;
using System.Collections.Generic;
using System.Text;

namespace KingsGambit
{
    public class Footman : ISoldier
    {
        public Footman(string name)
        {
            this.Name = name;
            this.HitPoints = 2;
        }

        public string Name { get; set; }

        public int HitPoints { get; set; }

        public void RespondToKingUnderAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}

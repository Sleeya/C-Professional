using System;
using System.Collections.Generic;
using System.Text;

namespace KingsGambit
{
    public class RoyalGuard :ISoldier
    {
        public RoyalGuard(string name)
        {
            this.Name = name;
            this.HitPoints = 3;
        }

        public string Name { get; set; }

        public int HitPoints { get; set; }

        public void RespondToKingUnderAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }

      
    }
}

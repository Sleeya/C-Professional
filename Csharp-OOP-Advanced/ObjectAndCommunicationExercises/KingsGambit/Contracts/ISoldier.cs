using System;
using System.Collections.Generic;
using System.Text;

namespace KingsGambit
{
    public interface ISoldier
    {
        void RespondToKingUnderAttack(object obj, EventArgs args);

        string Name { get; set; }

        int HitPoints { get; set; }
    }
}

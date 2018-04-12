using System;
using System.Collections.Generic;
using System.Text;

namespace KingsGambit.Contracts
{
    public interface IKing
    {
        string Name { get; set; }

        event EventHandler UnderAttack;
    }
}

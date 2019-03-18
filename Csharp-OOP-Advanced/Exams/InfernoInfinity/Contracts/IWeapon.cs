using System;
using System.Collections.Generic;
using System.Text;
using InfernoInfinity.Models.Gems;

namespace InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        int MinDmg { get; }

        int MaxDmg { get; }

        int NumberOfSockets { get; }

        string Name { get; }

        void AddGem(int index, IGem gem);

        void RemoveGem(int index);
    }
}

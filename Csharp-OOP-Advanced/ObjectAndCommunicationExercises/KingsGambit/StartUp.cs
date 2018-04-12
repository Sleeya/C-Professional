using System;
using System.Collections.Generic;
using System.Linq;
using KingsGambit.Contracts;

namespace KingsGambit
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();

            string kingName = Console.ReadLine();
            string[] royalGuardsNames = Console.ReadLine().Split();
            string[] footmanNames = Console.ReadLine().Split();

            var king = new King(kingName);

            for (int i = 0; i < royalGuardsNames.Length; i++)
            {
                var royalGuard = new RoyalGuard(royalGuardsNames[i]);
                soldiers.Add(royalGuard);
                king.UnderAttack += royalGuard.RespondToKingUnderAttack;
            }

            for (int i = 0; i < footmanNames.Length; i++)
            {
                var footman = new Footman(footmanNames[i]);
                soldiers.Add(footman);
                king.UnderAttack += footman.RespondToKingUnderAttack;
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var tokens = command.Split();
                var action = tokens[0];

                switch (action)
                {
                    case "Attack":
                        king.RespondUnderAttack();
                        break;
                    case "Kill":
                        var nameToKill = tokens[1];
                        var soldier = soldiers.FirstOrDefault(x => x.Name == nameToKill);
                        soldier.HitPoints--;
                        if (soldier.HitPoints==0)
                        {
                            king.UnderAttack -= soldier.RespondToKingUnderAttack;
                            soldiers.Remove(soldier);
                        }
                        break;
                }
            }
        }
    }
}

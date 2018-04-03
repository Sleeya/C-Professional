using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository) : base(data)
        {
            this.repository = repository;
        }

        public override string Execute()
        {
            string unitType = Data[1];
            
            try
            {
                this.repository.RemoveUnit(unitType);
            }
            catch (Exception e)
            {
                return e.Message;
            }


            return $"{unitType} retired!";
        }
    }
}

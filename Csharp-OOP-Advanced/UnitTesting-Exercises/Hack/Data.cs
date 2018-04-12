using System;
using System.Collections.Generic;
using System.Text;

namespace Hack
{
    public class Data
    {
        private double absData;
        private double roundedData;

        public Data(double number)
        {
            this.AbsData = number;
            this.RoundedData = number;
        }

        public double AbsData
        {
            get => this.absData;
            set => this.absData = Math.Abs(value);
        }

        public double RoundedData
        {
            get => this.roundedData;
            set => this.roundedData = Math.Floor(value);
        }
    }
}

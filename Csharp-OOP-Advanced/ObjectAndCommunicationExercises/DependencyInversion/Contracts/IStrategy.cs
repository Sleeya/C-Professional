using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversion.Contracts
{
    public interface IStrategy
    {
        int Calculate(int firstOperand, int secondOperand);
    }
}

using DependencyInversion.Contracts;

namespace DependencyInversion.Strategies
{
    public class DivisionStrategy:IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}

using DependencyInversion.Contracts;

namespace DependencyInversion.Strategies
{
	public class SubtractionStrategy:IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}

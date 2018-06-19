using DependencyInversion.Contracts;

namespace DependencyInversion.Strategies
{
	public class AdditionStrategy:IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}

namespace DependencyInversion.OperandModels
{
	public class AdditionStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}

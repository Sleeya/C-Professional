namespace DependencyInversion.OperandModels
{
	public class SubtractionStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}

using DependencyInversion.OperandModels;

namespace DependencyInversion
{
    public class PrimitiveCalculator
    {
        private bool isAddition;
        private bool isMultiplication;
        private AdditionStrategy additionStrategy;
        private SubtractionStrategy subtractionStrategy;
        private MultiplicationStrategy multiplicationStrategy;
        private DivisionStrategy divisionStrategy;

        public PrimitiveCalculator()
        {
            this.additionStrategy = new AdditionStrategy();
            this.subtractionStrategy = new SubtractionStrategy();
            this.divisionStrategy = new DivisionStrategy();
            this.multiplicationStrategy = new MultiplicationStrategy();
            this.isAddition = true;
            this.isMultiplication = false;
        }

        public void changeStrategy(char @operator)
        {
            switch (@operator)
            {
                case '+':
                    this.isAddition = true;
                    this.isMultiplication = false;
                    break;
                case '-':
                    this.isAddition = false;
                    this.isMultiplication = true;
                    break;
                case '*':
                    this.isAddition = true;
                    this.isMultiplication = true;
                    break;
                case '/':
                    this.isAddition = false;
                    this.isMultiplication = false;
                    break;
            }
        }

        public int performCalculation(int firstOperand, int secondOperand)
        {
            if (this.isAddition)
            {
                if (this.isMultiplication)
                {
                    return multiplicationStrategy.Calculate(firstOperand, secondOperand);
                }
                return additionStrategy.Calculate(firstOperand, secondOperand);
            }

            if (!this.isMultiplication)
            {
                return divisionStrategy.Calculate(firstOperand, secondOperand);
            }
            return subtractionStrategy.Calculate(firstOperand, secondOperand);
        }
    }
}


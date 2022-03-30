namespace Calculator
{
    public class Calculator: ICalculator
    {
        private readonly IParser _parser;
        
        public Calculator(IParser parser)
        {
            _parser = parser;
        }
        
        public decimal Calculate(string expression)
        {
            var postfixNotationExpression = _parser.Parse(expression);

            return 1;
        }
    }  
}

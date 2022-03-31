namespace Calculator.Operations
{
    public interface IOperation
    {
        string CharRepresentation { get; }

        decimal Calculate(decimal arg1, decimal arg2);
    }
}

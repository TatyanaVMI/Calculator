namespace Calculator.Models
{
    public class OperationToken : TokenBase
    {
        public bool IsUnary { get; set; }

        public OperationToken(string value, bool isUnary = false) : base(value)
        {
            IsUnary = isUnary;
        }
    }
}

namespace Calculator.Models
{
    public abstract class TokenBase
    {
        public string Value { get; set; }

        public TokenBase(string value)
        {
            Value = value;
        }
    }
}

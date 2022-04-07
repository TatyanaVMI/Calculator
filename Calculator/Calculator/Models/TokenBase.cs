namespace Calculator.Models
{
    public abstract class TokenBase
    {
        public string Value { get; set; }

        public TokenBase(string value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return Value == (obj as TokenBase).Value;
        }
    }
}

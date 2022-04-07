namespace Calculator.Tests.Helpers
{
    public static class InputExpression
    {
        public static string ExpressionWithAllOperationTypes = "3+4*2/(1-5)-1";
        public static string ExpressionWithSpaces = "1 + 2";
        public static string ExpressionWithInvalidCharacter = "1 ~ 1";
        public static string ExpressionWithExtraBracket = "1*(3-1))";
        public static string DecimalNumber = "2.5";
    }
}

using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Input: ");
                var input = Console.ReadLine();
                var result = new Calculator().Calculate(input);
                Console.WriteLine($"Output: {result}\n");
            }
        }
    }
}

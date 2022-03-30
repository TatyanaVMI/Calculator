using Ninject;
using System;
using System.Reflection;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var calculator = kernel.Get<ICalculator>();

            while (true)
            {
                Console.Write("Input: ");
                var input = Console.ReadLine();
                var result = calculator.Calculate(input);
                Console.WriteLine($"Output: {result}\n");
            }
        }
    }
}

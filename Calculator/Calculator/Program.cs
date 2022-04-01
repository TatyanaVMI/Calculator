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
                string result;
                try
                {
                    result = calculator.Calculate(input).ToString();
                }
                catch(Exception ex)
                {
                    result = ex.Message;
                }
                Console.WriteLine($"Output: {result}\n");
            }
        }
    }
}

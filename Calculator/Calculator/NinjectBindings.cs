using Calculator.Operations;
using Ninject.Modules;

namespace Calculator
{
    public class NinjectBindings: NinjectModule
    {
        public override void Load()
        {
            Bind<ICalculator>().To<Calculator>();
            Bind<IParser>().To<Parser>();
            Bind<IOperation>().To<SubtractionOperation>();
            Bind<IOperation>().To<AdditionOperation>();
            Bind<IOperationsProvider>().To<OperationsProvider>();
        }
    }
}

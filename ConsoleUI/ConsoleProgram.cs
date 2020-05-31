using ConsoleUI.ConsoleIOInterface;
using ConsoleUI.Operators;
using DSLib;
using DSLib.DataStructures;

namespace ConsoleUI
{
    internal class ConsoleProgram
    {
        internal static void Main()
        {
            var userInterface = new ConsoleBasedUI();
            IApplication application =
                new DataStructureApplication<string>(
                    new ConsoleMenuPrinter(),
                    userInterface,
                    new DataStructureFactory<string>(),
                    new OperatorFactory<string>(userInterface),
                    new DsAndOperationMapper());

            application.Run();
        }
    }
}
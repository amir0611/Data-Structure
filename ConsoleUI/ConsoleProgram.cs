using DSLib;

namespace ConsoleUI
{
    internal class ConsoleProgram
    {
        internal static void Main()
        {
            IApplication application = 
                new ConsoleApplication(
                    new ConsoleInputReader(new DsAndOperationMapper()),
                    new DsContext<string>(), 
                    new ConsoleOutputHandler());
            
            application.Run();
        }
    }
}
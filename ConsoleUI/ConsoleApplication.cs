using System;
using DSLib;

namespace ConsoleUI
{
    public sealed class ConsoleApplication : IApplication
    {
        private readonly IReadInput inputReader;
        private readonly IHandleOutput outputHandler;
        private readonly IDsContext dsContext;

        public ConsoleApplication(IReadInput inputReader, IDsContext dsContext, IHandleOutput outputHandler)
        {
            this.inputReader = inputReader ?? throw new ArgumentNullException(nameof(inputReader));
            this.dsContext = dsContext ?? throw new ArgumentNullException(nameof(dsContext));
            this.outputHandler = outputHandler ?? throw new ArgumentNullException(nameof(outputHandler));
        }

        public void Run()
        {
            char anotherDs;
            do
            {
                DataStructureTypes selectedDataStructure = inputReader.GetDataStructureByUser();

                char anotherOperation;
                do
                {
                    ushort operation = inputReader.GetOperationByUser(selectedDataStructure);
                    var input = inputReader.GetInputDataByUser(selectedDataStructure, operation);
                    dynamic output = dsContext.Execute(selectedDataStructure, operation, input);
                    outputHandler.HandleOutput(selectedDataStructure, operation, output);

                    Console.WriteLine("Do you want to select another Operation? Y/N");
                    anotherOperation = Convert.ToChar(Console.ReadLine() ?? throw new InvalidOperationException());

                } while (anotherOperation == 'y' || anotherOperation == 'Y');

                Console.WriteLine("Do you want to select another Data Structure? Y/N");
                anotherDs = Convert.ToChar(Console.ReadLine() ?? throw new InvalidOperationException());

            } while (anotherDs == 'y' || anotherDs == 'Y');
        }
    }
}
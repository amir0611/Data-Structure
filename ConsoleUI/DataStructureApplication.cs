using System;
using ConsoleUI.ConsoleIOInterface;
using ConsoleUI.Operators;
using DSLib;

namespace ConsoleUI
{
    internal sealed class DataStructureApplication<TDataType> : IApplication
    {
        private readonly IPrintMenu menuPrinter;
        private readonly IUserInterface userInterface;
        private readonly IMapDsAndOperations dsAndOperationsMapper;

        private readonly IDataStructureFactory<TDataType> dataStructureFactory;
        private readonly IOperatorFactory<TDataType> operatorFactory;

        public DataStructureApplication(IPrintMenu menuPrinter, IUserInterface userInterface,
            IDataStructureFactory<TDataType> dataStructureFactory,
            IOperatorFactory<TDataType> operatorFactory, IMapDsAndOperations dsAndOperationsMapper)
        {
            this.menuPrinter = menuPrinter ?? throw new ArgumentNullException(nameof(menuPrinter));
            this.userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));
            this.dsAndOperationsMapper =  dsAndOperationsMapper ?? throw new ArgumentNullException(nameof(dsAndOperationsMapper));
            this.dataStructureFactory = dataStructureFactory ?? throw new ArgumentNullException(nameof(dataStructureFactory));
            this.operatorFactory = operatorFactory ?? throw new ArgumentNullException(nameof(operatorFactory));
        }

        public void Run()
        {
            char anotherDs;
            do
            {
                DataStructureTypes selectedDataStructure = SelectDataStructure();

                IDataStructure<TDataType> dataStructureInstance =
                    dataStructureFactory.GetDataStructure(selectedDataStructure);

                char anotherOperation;
                do
                {
                    object selectedOperation = SelectOperation(selectedDataStructure);

                    IOperate dsOperator = operatorFactory.GetOperator(selectedDataStructure, dataStructureInstance, selectedOperation);

                    dsOperator.Operate();

                    Console.WriteLine("Do you want to select another Operation? Y/N");
                    anotherOperation = Convert.ToChar(Console.ReadLine() ?? throw new InvalidOperationException());

                } while (anotherOperation == 'y' || anotherOperation == 'Y');

                Console.WriteLine("Do you want to select another Data Structure? Y/N");
                anotherDs = Convert.ToChar(Console.ReadLine() ?? throw new InvalidOperationException());

            } while (anotherDs == 'y' || anotherDs == 'Y');
        }

        private DataStructureTypes SelectDataStructure()
        {
            menuPrinter.ShowEnumBasedTabularMenu(typeof(DataStructureTypes), new[] {"Index", "DS Type"});

            return (DataStructureTypes) userInterface.GetEnumBasedInputByUser(typeof(DataStructureTypes));
        }

        private object SelectOperation(DataStructureTypes dataStructure)
        {
            Type operationType = dsAndOperationsMapper.GetOperationType(dataStructure);
            menuPrinter.ShowEnumBasedTabularMenu(operationType, new[] {"Index", "Operation"});

            return userInterface.GetEnumBasedInputByUser(operationType);
        }
    }
}
using System;
using ConsoleUI.ConsoleIOInterface;
using DSLib;

namespace ConsoleUI.Operators
{
    internal class LinkedListInsertAtLastOperator<TDataType> : BaseOperator<TDataType>, IOperate
    {
        public LinkedListInsertAtLastOperator(IUserInterface userInterface, IDataStructure<TDataType> dataStructure) : base(
            userInterface, dataStructure)
        {
        }

        public void Operate()
        {
            string inputData = userInterface.GetSingleStringByUser("Enter new data to add at end: ");

            var element = (TDataType)Convert.ChangeType(inputData, typeof(TDataType));
            bool output = dataStructure.InsertAtLast(element);

            userInterface.DisplayResultMessage(output, $"Inserted {element}", $"Insertion Failed {element}");
        }
    }
}
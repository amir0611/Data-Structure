using System;
using ConsoleUI.ConsoleIOInterface;
using DSLib;

namespace ConsoleUI.Operators
{
    internal class LinkedListFindOperator<TDataType> : BaseOperator<TDataType>, IOperate
    {
        public LinkedListFindOperator(IUserInterface userInterface, IDataStructure<TDataType> dataStructure) : base(
            userInterface, dataStructure)
        {
        }

        public void Operate()
        {
            string inputData = userInterface.GetSingleStringByUser("Enter data to search: ");

            var element = (TDataType)Convert.ChangeType(inputData, typeof(TDataType));
            bool output = dataStructure.Find(element);

            userInterface.DisplayResultMessage(output, $"Found {element}", $"Not Found {element}");
        }
    }
}
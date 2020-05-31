using System.Collections.Generic;
using ConsoleUI.ConsoleIOInterface;
using DSLib;

namespace ConsoleUI.Operators
{
    internal sealed class LinkedListCreateOperator<TDataType> : BaseOperator<TDataType>, IOperate
    {
        public LinkedListCreateOperator(IUserInterface userInterface, IDataStructure<TDataType> dataStructure) : base(
            userInterface, dataStructure)
        {
        }

        public void Operate()
        {
            var inputData = userInterface.GetListOfStringsByUser("Enter Data: ");

            bool output = dataStructure.Create((IEnumerable<TDataType>) inputData);

            userInterface.DisplayResultMessage(output, "Linked List created successfully.", "Creation Failed.");
        }
    }
}
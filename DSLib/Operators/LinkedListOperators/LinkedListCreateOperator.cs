using System.Collections.Generic;

namespace DSLib.Operators.LinkedListOperators
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
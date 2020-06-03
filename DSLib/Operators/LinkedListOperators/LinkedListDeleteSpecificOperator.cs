using System;

namespace DSLib.Operators.LinkedListOperators
{
    internal class LinkedListDeleteSpecificOperator<TDataType> : BaseOperator<TDataType>, IOperate
    {
        public LinkedListDeleteSpecificOperator(IUserInterface userInterface, IDataStructure<TDataType> dataStructure) : base(
            userInterface, dataStructure)
        {
        }

        public void Operate()
        {
            string inputData = userInterface.GetSingleStringByUser("Enter data to delete: ");

            var element = (TDataType)Convert.ChangeType(inputData, typeof(TDataType));
            bool output = dataStructure.DeleteSpecific(element);

            userInterface.DisplayResultMessage(output, $"Node {element} Deleted.", $"Node {element} Deletion failed");
        }
    }
}
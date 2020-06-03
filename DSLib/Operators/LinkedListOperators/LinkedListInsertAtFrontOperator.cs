using System;

namespace DSLib.Operators.LinkedListOperators
{
    internal class LinkedListInsertAtFrontOperator<TDataType> : BaseOperator<TDataType>, IOperate
    {
        public LinkedListInsertAtFrontOperator(IUserInterface userInterface, IDataStructure<TDataType> dataStructure) : base(
            userInterface, dataStructure)
        {
        }

        public void Operate()
        {
            string inputData = userInterface.GetSingleStringByUser("Enter new data to add at front: ");

            var element = (TDataType)Convert.ChangeType(inputData, typeof(TDataType));
            bool output = dataStructure.InsertAtFront(element);

            userInterface.DisplayResultMessage(output, $"Inserted {element}", $"Insertion Failed {element}");
        }
    }
}
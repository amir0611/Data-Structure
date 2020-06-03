using System;
using System.Linq;

namespace DSLib.Operators.LinkedListOperators
{
    internal sealed class LinkedListInsertAfterOperator<TDataType> : BaseOperator<TDataType>, IOperate
    {
        public LinkedListInsertAfterOperator(IUserInterface userInterface, IDataStructure<TDataType> dataStructure) : base(
            userInterface, dataStructure)
        {
        }

        public void Operate()
        {
            var inputData = Enumerable.ToList<string>(userInterface.GetFixedLengthListOfStringsByUser(2, "Enter new data to add: ",
                "Enter Data after which new node will be inserted: "));

            var newElement = (TDataType)Convert.ChangeType(inputData[0], typeof(TDataType));
            var existingElement = (TDataType)Convert.ChangeType(inputData[1], typeof(TDataType));

            bool output = dataStructure.InsertAfter(newElement, existingElement);

            userInterface.DisplayResultMessage(output, $"Inserted {newElement}", $"Insertion Failed {newElement}");
        }
    }
}
using System;
using System.Linq;
using ConsoleUI.ConsoleIOInterface;
using DSLib;
using DSLib.DataStructures;

namespace ConsoleUI.Operators
{
    internal class LinkedListInsertBeforeOperator<TDataType> : BaseOperator<TDataType>, IOperate
    {
        public LinkedListInsertBeforeOperator(IUserInterface userInterface, IDataStructure<TDataType> dataStructure) :
            base(
                userInterface, dataStructure)
        {
        }

        public void Operate()
        {
            if (dataStructure is SinglyLinkedList<TDataType>)
            {
                userInterface.ShowMessage("This operation is not supported by SinglyLinkedList");
                return;
            }

            var inputData = userInterface.GetFixedLengthListOfStringsByUser(2,
                "Enter new data to add: ", "Enter Data before which new node will be inserted: ").ToList();

            var newElement = (TDataType)Convert.ChangeType(inputData[0], typeof(TDataType));
            var existingElement = (TDataType)Convert.ChangeType(inputData[1], typeof(TDataType));

            bool output = dataStructure.InsertBefore(newElement, existingElement);

            userInterface.DisplayResultMessage(output, $"Inserted {newElement}", $"Insertion Failed {newElement}");
        }
    }
}
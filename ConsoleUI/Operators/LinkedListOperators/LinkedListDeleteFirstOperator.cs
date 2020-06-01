using ConsoleUI.ConsoleIOInterface;
using DSLib;

namespace ConsoleUI.Operators
{
    internal class LinkedListDeleteFirstOperator<TDataType> : BaseOperator<TDataType>, IOperate
    {
        public LinkedListDeleteFirstOperator(IUserInterface userInterface, IDataStructure<TDataType> dataStructure) : base(
            userInterface, dataStructure)
        {
        }

        public void Operate()
        {
            bool output = dataStructure.DeleteFirst();

            userInterface.DisplayResultMessage(output, "First Node Deleted.", "First node deletion Failed.");
        }
    }
}
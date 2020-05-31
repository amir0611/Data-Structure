using ConsoleUI.ConsoleIOInterface;
using DSLib;

namespace ConsoleUI.Operators
{
    internal sealed class LinkedListTraversalOperator<TData> : BaseOperator<TData>, IOperate
    {
        public LinkedListTraversalOperator(IUserInterface userInterface, IDataStructure<TData> dataStructure) : base(
            userInterface, dataStructure)
        {
        }

        public void Operate()
        {
            dynamic output = dataStructure.Traverse();

            userInterface.DisplaySinglyListTraverse(output);
        }
    }
}
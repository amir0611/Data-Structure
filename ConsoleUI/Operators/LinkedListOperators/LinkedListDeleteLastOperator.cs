using ConsoleUI.ConsoleIOInterface;
using DSLib;

namespace ConsoleUI.Operators
{
    internal class LinkedListDeleteLastOperator<TDataType> : BaseOperator<TDataType>, IOperate
    {
        public LinkedListDeleteLastOperator(IUserInterface userInterface, IDataStructure<TDataType> dataStructure) : base(
            userInterface, dataStructure)
        {
        }

        public void Operate()
        {
            
        }
    }
}
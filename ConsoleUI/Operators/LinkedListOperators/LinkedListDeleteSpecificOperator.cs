using ConsoleUI.ConsoleIOInterface;
using DSLib;

namespace ConsoleUI.Operators
{
    internal class LinkedListDeleteSpecificOperator<TDataType> : BaseOperator<TDataType>, IOperate
    {
        public LinkedListDeleteSpecificOperator(IUserInterface userInterface, IDataStructure<TDataType> dataStructure) : base(
            userInterface, dataStructure)
        {
        }

        public void Operate()
        {
            
        }
    }
}
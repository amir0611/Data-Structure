namespace DSLib.Operators.LinkedListOperators
{
    internal class LinkedListDeleteLastOperator<TDataType> : BaseOperator<TDataType>, IOperate
    {
        public LinkedListDeleteLastOperator(IUserInterface userInterface, IDataStructure<TDataType> dataStructure) : base(
            userInterface, dataStructure)
        {
        }

        public void Operate()
        {
            bool output = dataStructure.DeleteLast();

            userInterface.DisplayResultMessage(output, "Last Node Deleted.", "Last node deletion Failed.");
        }
    }
}
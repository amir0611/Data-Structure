using DSLib;

namespace ConsoleUI.Operators
{
    internal interface IOperatorFactory<TDataType>
    {
        IOperate GetOperator(DataStructureTypes dataStructure,
            IDataStructure<TDataType> dataStructureInstance, object operation);
    }
}
namespace DSLib.Operators
{
    public interface IOperatorFactory<TDataType>
    {
        IOperate GetOperator(DataStructureTypes dataStructure,
            IDataStructure<TDataType> dataStructureInstance, object operation);
    }
}
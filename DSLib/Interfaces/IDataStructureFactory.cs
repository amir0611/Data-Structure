namespace DSLib
{
    public interface IDataStructureFactory<TDataType>
    {
        IDataStructure<TDataType> GetDataStructure(DataStructureTypes selectedDataStructure);
    }
}
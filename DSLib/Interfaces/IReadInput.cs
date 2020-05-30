namespace DSLib
{
    public interface IReadInput
    {
        DataStructureTypes GetDataStructureByUser();
        ushort GetOperationByUser(DataStructureTypes selectedDataStructure);
        dynamic GetInputDataByUser(DataStructureTypes dataStructure, ushort operation);
    }
}
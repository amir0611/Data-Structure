namespace DSLib
{
    public interface IHandleOutput
    {
        void HandleOutput(DataStructureTypes selectedDataStructure, dynamic operation, dynamic output);
    }
}
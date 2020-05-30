namespace DSLib
{
    public interface IDsContext
    {
        dynamic Execute(DataStructureTypes dataStructureType, ushort operation, dynamic input);
    }
}
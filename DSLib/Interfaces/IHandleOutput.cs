namespace DSLib
{
    public interface IHandleOutput<in TOutput>
    {
        void HandleOutput(TOutput output);
    }
}
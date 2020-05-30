namespace DSLib
{
    public interface INode<out TData>
    {
        TData Value { get; }
    }
}
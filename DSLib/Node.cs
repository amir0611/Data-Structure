namespace DSLib
{
    public abstract class Node<TData> : INode<TData>
    {
        public TData Value { get; set; }
    }
}
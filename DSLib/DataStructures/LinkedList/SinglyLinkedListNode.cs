namespace DSLib.DataStructures
{
    public sealed class SinglyLinkedListNode<TData>
    {
        public TData Value { get; set; }
        public SinglyLinkedListNode<TData> NextNode { get; set; }
    }
}
namespace DSLib
{
    public sealed class SinglyLinkedListNode<TData> : Node<TData>
    {
        public SinglyLinkedListNode<TData> NextNode { get; set; }
    }
}
namespace DSLib.DataStructures
{
    public sealed class SinglyLinkedListNode<TDataType> : BaseNode<TDataType>
    {
        public SinglyLinkedListNode<TDataType> NextNode { get; set; }

        public SinglyLinkedListNode(TDataType data) : base(data)
        {
        }
    }
}
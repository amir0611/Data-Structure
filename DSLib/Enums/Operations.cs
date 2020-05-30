namespace DSLib
{
    public enum ArrayOperations : ushort
    {
        Recursion = 1
    }

    public enum LinkedListOperations : ushort
    {
        Create = 1,
        Traversal,
        Find,
        InsertAtFront,
        InsertAtLast,
        InsertAfter,
        InsertBefore,
        DeleteFirst,
        DeleteLast,
        DeleteSpecific
    }

    public enum StackOperations : ushort
    {
        Push = 1
    }

    public enum QueueOperations : ushort
    {
        Enqueue = 1
    }

    public enum GraphOperations : ushort
    {
        Traversal = 1
    }

    public enum TreeOperations : ushort
    {
        Traversal = 1
    }
}
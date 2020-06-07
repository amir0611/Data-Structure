using System;

namespace DSLib
{
    [Flags]
    public enum ArrayOperations
    {
        Recursion = 1
    }

    [Flags]
    public enum LinkedListOperations
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

    [Flags]
    public enum StackOperations
    {
        Push = 1
    }

    [Flags]
    public enum QueueOperations
    {
        Enqueue = 1
    }

    [Flags]
    public enum GraphOperations
    {
        Traversal = 1
    }

    [Flags]
    public enum TreeOperations
    {
        Traversal = 1
    }
}
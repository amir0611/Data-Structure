using System;
using DSLib.DataStructures;

namespace DSLib
{
    public sealed class DsContext<TData> : IDsContext
    {
        private readonly SinglyLinkedList<TData> linkedList = new SinglyLinkedList<TData>();

        /// <summary>
        /// Executes given operation for the provided data-structure with given input-data.
        /// </summary>
        /// <param name="dataStructureType">Type of data-structure</param>
        /// <param name="operation">Operation to be performed over data-structure</param>
        /// <param name="input">It could be TData or IEnumerable{TData}</param>
        /// <returns>Output result after operating</returns>
        public dynamic Execute(DataStructureTypes dataStructureType, ushort operation, dynamic input)
        {
            switch (dataStructureType)
            {
                case DataStructureTypes.Array:
                    break;
                case DataStructureTypes.SinglyLinkedList:
                case DataStructureTypes.DoublyLinkedList:
                case DataStructureTypes.CircularLinkedList:
                    return ExecuteLinkedListOperation(dataStructureType, operation, input);
                case DataStructureTypes.Stack:
                    break;
                case DataStructureTypes.Queue:
                    break;
                case DataStructureTypes.Tree:
                    break;
                case DataStructureTypes.Graph:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataStructureType), dataStructureType, null);
            }

            return null;
        }

        private dynamic ExecuteLinkedListOperation(DataStructureTypes dataStructureType, ushort operation,
            dynamic input)
        {
            var op = (LinkedListOperations) Enum.Parse(typeof(LinkedListOperations),
                Enum.GetName(typeof(LinkedListOperations), operation) ?? throw new InvalidOperationException());

            switch (op)
            {
                case LinkedListOperations.Create:
                    linkedList.Create(input);
                    return true;
                case LinkedListOperations.Traversal:
                    return linkedList.Traverse();
                case LinkedListOperations.Find:
                    return linkedList.Find(input);
                case LinkedListOperations.InsertAtFront:
                    return linkedList.InsertAtFront(input);
                case LinkedListOperations.InsertAtLast:
                    return linkedList.InsertAtLast(input);
                case LinkedListOperations.InsertAfter:
                    return linkedList.InsertAfter(input[0], input[1]);
                case LinkedListOperations.InsertBefore:
                    return dataStructureType == DataStructureTypes.SinglyLinkedList
                        ? "Operation Not Supported"
                        : linkedList.InsertBefore(input[0], input[1]);
                case LinkedListOperations.DeleteFirst:
                    return linkedList.DeleteFirst();
                case LinkedListOperations.DeleteLast:
                    return linkedList.DeleteLast();
                case LinkedListOperations.DeleteSpecific:
                    return linkedList.DeleteSpecific(input);
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }
    }
}
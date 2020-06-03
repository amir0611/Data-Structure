using System;
using DSLib.Operators.LinkedListOperators;

namespace DSLib.Operators
{
    public sealed class OperatorFactory<TDataType> : IOperatorFactory<TDataType>
    {
        private readonly IUserInterface userInterface;

        public OperatorFactory(IUserInterface userInterface)
        {
            this.userInterface = userInterface ?? throw new ArgumentNullException(nameof(userInterface));
        }

        public IOperate GetOperator(DataStructureTypes dataStructure,
            IDataStructure<TDataType> dataStructureInstance, object operation)
        {
            switch (dataStructure)
            {
                case DataStructureTypes.Array:
                    break;
                case DataStructureTypes.SinglyLinkedList:
                case DataStructureTypes.DoublyLinkedList:
                case DataStructureTypes.CircularLinkedList:
                    return GetLinkedListOperationsHandler(dataStructureInstance, (LinkedListOperations) operation);
                case DataStructureTypes.Stack:
                    break;
                case DataStructureTypes.Queue:
                    break;
                case DataStructureTypes.Tree:
                    break;
                case DataStructureTypes.Graph:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataStructure), dataStructure, null);
            }

            return null;
        }

        private IOperate GetLinkedListOperationsHandler(IDataStructure<TDataType> dataStructureInstance,
            LinkedListOperations operation)
        {
            switch (operation)
            {
                case LinkedListOperations.Create:
                    return new LinkedListCreateOperator<TDataType>(userInterface, dataStructureInstance);
                case LinkedListOperations.Traversal:
                    return new LinkedListTraversalOperator<TDataType>(userInterface, dataStructureInstance);
                case LinkedListOperations.Find:
                    return new LinkedListFindOperator<TDataType>(userInterface, dataStructureInstance);
                case LinkedListOperations.InsertAtFront:
                    return new LinkedListInsertAtFrontOperator<TDataType>(userInterface, dataStructureInstance);
                case LinkedListOperations.InsertAtLast:
                    return new LinkedListInsertAtLastOperator<TDataType>(userInterface, dataStructureInstance);
                case LinkedListOperations.InsertAfter:
                    return new LinkedListInsertAfterOperator<TDataType>(userInterface, dataStructureInstance);
                case LinkedListOperations.InsertBefore:
                    return new LinkedListInsertBeforeOperator<TDataType>(userInterface, dataStructureInstance);
                case LinkedListOperations.DeleteFirst:
                    return new LinkedListDeleteFirstOperator<TDataType>(userInterface, dataStructureInstance);
                case LinkedListOperations.DeleteLast:
                    return new LinkedListDeleteLastOperator<TDataType>(userInterface, dataStructureInstance);
                case LinkedListOperations.DeleteSpecific:
                    return new LinkedListDeleteSpecificOperator<TDataType>(userInterface, dataStructureInstance);
                default:
                    throw new ArgumentOutOfRangeException(nameof(operation), operation, null);
            }
        }
    }
}
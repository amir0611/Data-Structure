using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DSLib
{
    public sealed class DsAndOperationMapper : IMapDsAndOperations
    {
        private readonly IDictionary<DataStructureTypes, Type> dsAndOperationsMap =
            new Dictionary<DataStructureTypes, Type>
            {
                {
                    DataStructureTypes.Array,
                    typeof(ArrayOperations)
                },
                {
                    DataStructureTypes.SinglyLinkedList,
                    typeof(LinkedListOperations)
                },
                {
                    DataStructureTypes.DoublyLinkedList,
                    typeof(LinkedListOperations)
                },
                {
                    DataStructureTypes.CircularLinkedList,
                    typeof(LinkedListOperations)
                },
                {
                    DataStructureTypes.Stack,
                    typeof(StackOperations)
                },
                {
                    DataStructureTypes.Queue,
                    typeof(QueueOperations)
                },
                {
                    DataStructureTypes.Graph,
                    typeof(GraphOperations)
                },
                {
                    DataStructureTypes.Tree,
                    typeof(TreeOperations)
                }
            };

        public Type GetOperationType(DataStructureTypes dataStructure)
        {
            if (!Enum.IsDefined(typeof(DataStructureTypes), dataStructure))
            {
                throw new InvalidEnumArgumentException(nameof(dataStructure), (int)dataStructure,
                    typeof(DataStructureTypes));
            }

            return dsAndOperationsMap[dataStructure];
        }
    }
}
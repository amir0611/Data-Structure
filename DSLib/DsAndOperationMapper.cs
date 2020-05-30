using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DSLib
{
    public sealed class DsAndOperationMapper : IMapDsAndOperations
    {
        private readonly IDictionary<DataStructureTypes, IEnumerable<dynamic>> dsAndOperationsMap =
            new Dictionary<DataStructureTypes, IEnumerable<dynamic>>
            {
                {
                    DataStructureTypes.Array,
                    Enum.GetNames(typeof(ArrayOperations))
                },
                {
                    DataStructureTypes.SinglyLinkedList,
                    Enum.GetNames(typeof(LinkedListOperations))
                },
                {
                    DataStructureTypes.DoublyLinkedList,
                    Enum.GetNames(typeof(LinkedListOperations))
                },
                {
                    DataStructureTypes.CircularLinkedList,
                    Enum.GetNames(typeof(LinkedListOperations))
                },
                {
                    DataStructureTypes.Stack,
                    Enum.GetNames(typeof(StackOperations))
                },
                {
                    DataStructureTypes.Queue,
                    Enum.GetNames(typeof(QueueOperations))
                },
                {
                    DataStructureTypes.Graph,
                    Enum.GetNames(typeof(GraphOperations))
                },
                {
                    DataStructureTypes.Tree,
                    Enum.GetNames(typeof(TreeOperations))
                }
            };

        public IEnumerable<dynamic> GetOperations(DataStructureTypes dataStructure)
        {
            if (!Enum.IsDefined(typeof(DataStructureTypes), dataStructure))
            {
                throw new InvalidEnumArgumentException(nameof(dataStructure), (int) dataStructure,
                    typeof(DataStructureTypes));
            }

            return dsAndOperationsMap.ContainsKey(dataStructure)
                ? dsAndOperationsMap[dataStructure]
                : Enumerable.Empty<dynamic>();
        }
    }
}
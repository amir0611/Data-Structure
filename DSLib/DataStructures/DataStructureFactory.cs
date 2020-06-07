using System;
using System.ComponentModel;

namespace DSLib.DataStructures
{
    public class DataStructureFactory<TDataType> : IDataStructureFactory<TDataType>
    {
        public IDataStructure<TDataType> GetDataStructure(DataStructureTypes selectedDataStructure)
        {
            if (!Enum.IsDefined(typeof(DataStructureTypes), selectedDataStructure))
            {
                throw new InvalidEnumArgumentException(nameof(selectedDataStructure), (int)selectedDataStructure,
                    typeof(DataStructureTypes));
            }

            switch (selectedDataStructure)
            {
                case DataStructureTypes.Array:
                    break;
                case DataStructureTypes.SinglyLinkedList:
                    return new SinglyLinkedList<TDataType>();
                case DataStructureTypes.DoublyLinkedList:
                    break;
                case DataStructureTypes.CircularLinkedList:
                    break;
                case DataStructureTypes.Stack:
                    break;
                case DataStructureTypes.Queue:
                    break;
                case DataStructureTypes.Tree:
                    break;
                case DataStructureTypes.Graph:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(selectedDataStructure), selectedDataStructure, null);
            }

            return null;
        }
    }
}
using System.Collections.Generic;

namespace DSLib
{
    public interface IDataStructure<TDataType>
    {
        bool Create(IEnumerable<TDataType> data);

        IEnumerable<TDataType> Traverse();

        bool Find(TDataType element);

        bool InsertAtFront(TDataType element);

        bool InsertAtLast(TDataType element);

        bool InsertAfter(TDataType newElement, TDataType existingElement);

        bool InsertBefore(TDataType newElement, TDataType existingElement);

        bool DeleteFirst();

        bool DeleteLast();

        bool DeleteSpecific(TDataType element);
    }
}
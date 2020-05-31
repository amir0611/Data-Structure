using System.Collections.Generic;

namespace DSLib.DataStructures
{
    public sealed class SinglyLinkedList<TDataType> : IDataStructure<TDataType>
    {
        private SinglyLinkedListNode<TDataType> head;
        private SinglyLinkedListNode<TDataType> current;

        public bool Create(IEnumerable<TDataType> data)
        {
            var created = false;

            foreach (TDataType item in data)
            {
                created = InsertAtLast(item);
            }

            return created;
        }

        public IEnumerable<TDataType> Traverse()
        {
            var data = new List<TDataType>();

            current = head;

            while (current != null)
            {
                data.Add(current.Value);

                current = current.NextNode;
            }

            return data;
        }

        public bool Find(TDataType element)
        {
            current = head;

            while (current != null)
            {
                if (current.Value.Equals(element))
                {
                    return true;
                }

                current = current.NextNode;
            }

            return false;
        }

        public bool InsertAtFront(TDataType element)
        {
            var newNode = new SinglyLinkedListNode<TDataType> { Value = element, NextNode = null };

            // Handle 1st element of list.
            if (head == null)
            {
                head = newNode;
                return true;
            }

            newNode.NextNode = head;
            head = newNode;

            return true;
        }

        public bool InsertAtLast(TDataType element)
        {
            var newNode = new SinglyLinkedListNode<TDataType> {Value = element, NextNode = null};

            // Handle 1st element of list.
            if (head == null)
            {
                head = newNode;
                return true;
            }

            current = head;
            while (current.NextNode != null)
            {
                current = current.NextNode;
            }

            current.NextNode = newNode;
            return true;
        }

        public bool InsertAfter(TDataType newElement, TDataType existingElement)
        {
            var newNode = new SinglyLinkedListNode<TDataType> { Value = newElement, NextNode = null };

            current = head;

            while (current != null)
            {
                if (current.Value.Equals(existingElement))
                {
                    newNode.NextNode = current.NextNode;
                    current.NextNode = newNode;
                    return true;
                }

                current = current.NextNode;
            }

            return false;
        }

        public bool InsertBefore(TDataType newElement, TDataType existingElement)
        {
            return false;
        }

        public bool DeleteFirst()
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteLast()
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteSpecific(TDataType element)
        {
            throw new System.NotImplementedException();
        }
    }
}
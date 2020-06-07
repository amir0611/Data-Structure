using System.Collections.Generic;

namespace DSLib.DataStructures
{
    public sealed class SinglyLinkedList<TDataType> : IDataStructure<TDataType>
    {
        private SinglyLinkedListNode<TDataType> head;
        private SinglyLinkedListNode<TDataType> current;

        public bool Create(IEnumerable<TDataType> data)
        {
            if (data is null)
            {
                throw new System.ArgumentNullException(nameof(data));
            }

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
                data.Add(current.Data);

                current = current.NextNode;
            }

            return data;
        }

        public bool Find(TDataType element)
        {
            current = head;

            while (current != null)
            {
                if (current.Data.Equals(element))
                {
                    return true;
                }

                current = current.NextNode;
            }

            return false;
        }

        public bool InsertAtFront(TDataType element)
        {
            var newNode = new SinglyLinkedListNode<TDataType>(element) { NextNode = null };

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
            var newNode = new SinglyLinkedListNode<TDataType>(element) { NextNode = null };

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
            var newNode = new SinglyLinkedListNode<TDataType>(newElement) { NextNode = null };

            current = head;

            while (current != null)
            {
                if (current.Data.Equals(existingElement))
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
            head = head.NextNode;

            return true;
        }

        public bool DeleteLast()
        {
            current = head;

            while (current.NextNode.NextNode != null)
            {
                current = current.NextNode;
            }

            current.NextNode = null;

            return true;
        }

        public bool DeleteSpecific(TDataType element)
        {
            bool deleted = false;

            // empty-list
            if (head == null)
            {
                return false;
            }

            // First element itself to be deleted
            if (head.Data.Equals(element))
            {
                head = null;
                return true;
            }

            var prev = head;
            current = head.NextNode;

            while (prev != null && current != null)
            {
                if (current.Data.Equals(element))
                {
                    prev.NextNode = current.NextNode;
                    deleted = true;
                    break;
                }

                prev = prev.NextNode;
                current = current.NextNode;
            }

            return deleted;
        }
    }
}
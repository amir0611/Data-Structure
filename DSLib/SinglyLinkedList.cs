using System.Collections.Generic;

namespace DSLib
{
    public sealed class SinglyLinkedList<TData> : Node<TData>
    {
        private SinglyLinkedListNode<TData> head;
        private SinglyLinkedListNode<TData> current;

        public void Create(IEnumerable<TData> data)
        {
            foreach (TData item in data)
            {
                InsertAtLast(item);
            }
        }

        public IEnumerable<TData> Traverse()
        {
            var data = new List<TData>();

            current = head;

            while (current != null)
            {
                data.Add(current.Value);

                current = current.NextNode;
            }

            return data;
        }

        public bool Find(TData element)
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

        public bool InsertAtFront(TData element)
        {
            var newNode = new SinglyLinkedListNode<TData> { Value = element, NextNode = null };

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

        public bool InsertAtLast(TData element)
        {
            var newNode = new SinglyLinkedListNode<TData> {Value = element, NextNode = null};

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

        public bool InsertAfter(TData newElement, TData existingElement)
        {
            var newNode = new SinglyLinkedListNode<TData> { Value = newElement, NextNode = null };

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

        public bool InsertBefore(TData newElement, TData existingElement)
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

        public bool DeleteSpecific(TData element)
        {
            throw new System.NotImplementedException();
        }
    }
}
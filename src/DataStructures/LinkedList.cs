using System;
using System.Collections;
using System.Collections.Generic;
using Core;

namespace DataStructures
{
    public class LinkedList<T> : ICollection<T>
    {
        public class LinkedListNode<V> 
        {
            public V Value { get; }

            //  C# 8.0 Nullable Reference for Next
            public LinkedListNode<V>? Next { get; set; }

            
            public LinkedListNode(V value)
            {
                this.Value = value;
            }
        }

        // Head
        private LinkedListNode<T> _head;

        // Tail
        private LinkedListNode<T> _tail;

        private bool IsEmpty => _head == null;

        private bool IsNotEmpty => !IsEmpty;


        public LinkedList()
        {

        }


        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T itemToAdd)
        {
            itemToAdd.ThrowIfNull(nameof(itemToAdd));

            // Create a new LinkedListNode from item
            LinkedListNode<T> nodeToAdd = new LinkedListNode<T>(itemToAdd);

            if (IsNotEmpty)
            {
                var oldTail = _tail;
                _tail = nodeToAdd;
                oldTail.Next = nodeToAdd;
            }
            else
            {
                _head = nodeToAdd;
                _tail = _head;
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T itemToRemove)
        {
            //itemToRemove.ThrowIfNull(nameof(itemToRemove));

            //// Find the item in the linked List
            //while (expression)
            //{
                
            //}

            throw new NotImplementedException();
        }

        public int Count { get; }
        public bool IsReadOnly { get; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Core;

namespace DataStructures
{
    public class LinkedList<T> : ICollection<T>
    {
        public class LinkedListNode<T>
        {
            public T Value { get; set; }

            public LinkedListNode<T>? Next { get; set; }
        }

        // Head
        private LinkedListNode<T> _head;

        // Tail
        private LinkedListNode<T> _tail;


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

        public void Add(T item)
        {
            
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

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; }
        public bool IsReadOnly { get; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Array
{
    public class CustomArray<T> : ICollection<T>
    {
        public Node<T> First;
        public Node<T> Current;
        public Node<T> Last;
        public int Count { get; private set; }
        private readonly int Begin;
        private readonly int End;
        public CustomArray(int begin, int end)
        {
            if(end < begin)
            {
                throw new ArgumentException();
            }
            Begin = begin;
            End = end;
            for (int i = begin; i <= end; i++)
            {
                Add(default(T));
            }
        }
        public T this[int index]
        {
            get
            {
                if(index < Begin || index > End)
                {
                    throw new IndexOutOfRangeException();
                }
                return GetByIndex(index).Data;
            }
            set
            {
                if (index < Begin || index > End)
                {
                    throw new IndexOutOfRangeException();
                }
                GetByIndex(index).Data = value;
            }
        }

        public bool IsEmpty 
        {
            get
            {
                return Count == 0;
            }
        }

        public bool IsReadOnly => false;

        public void InsertByIndex(T newElement, int index)
        {
            if (index < Begin || index > Count)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == Begin) 
            {
                PushFront(newElement);
            }
            else if (index == Count) 
            {
                Add(newElement);
            }
            else 
            {
                int count = Begin;
                Current = First;
                while (Current != null && count != index)
                {
                    Current = Current.Next;
                    count++;
                }
                Node<T> newNode = new Node<T>(newElement); 
                Current.Prev.Next = newNode; 
                newNode.Prev = Current.Prev;
                Current.Prev = newNode;
                newNode.Next = Current;
            }
          
        }

        public void PushFront(T newElement)
        {
            Node<T> newNode = new Node<T>(newElement);

            if (First == null)
            {
                First = Last = newNode;
            }
            else
            {
                newNode.Next = First;
                First = newNode; 
                newNode.Next.Prev = First;
            }
            Count++;
        }

        public Node<T> PopFront()
        {
            if (First == null)
            {
                throw new EmptyArrayException("Pop from empty array");
            }
            else
            {
                Node<T> temp = First;
                if (First.Next != null)
                {
                    First.Next.Prev = null;
                }
                First = First.Next;
                Count--;
                return temp;
            }
        }
        public void Add(T newElement)
        {

            Node<T> newNode = new Node<T>(newElement);

            if (First == null)
            {
                First = Last = newNode;
            }
            else
            {
                Last.Next = newNode;
                newNode.Prev = Last;
                Last = newNode;
            }
            Count++;
        }

        public Node<T> PopBack()
        {
            if (Last == null)
            {
                throw new EmptyArrayException("Pop from empty array");
            }
            else
            {
                Node<T> temp = Last;
                if (Last.Prev != null)
                {
                    Last.Prev.Next = null;
                }
                Last = Last.Prev;
                Count--;
                return temp;
            }
        }
        public void ClearList() 
        {
            while (!IsEmpty)
            {
                PopFront();
            }
        }
        public IEnumerable<T> Traverse() 
        {
            if (First == null)
            {
                yield break;
            }
            Current = First;
            
            while (Current != null)
            {
                yield return Current.Data;
                Current = Current.Next;
            }
        }

        public bool Remove(T data)
        {
            if(data==null)
            {
                throw new ArgumentNullException();
            }
            var node = FindNode(data);
            bool result = false;
            if(node == null)
            {
                return result;
            }
           
            if (node.Prev == null)
            {
                PopFront();
                result = true;
            }
            else if (node.Next == null)
            {
                PopBack();
                result = true;
            }
            else
            {
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
                result = true;
            }
            return result;
        }

        public Node<T> FindNode(T data) 
        {
            if(data==null)
            {
                throw new ArgumentNullException();
            }
            var index = First;
            while (index != null)
            {
                if (index.Data.Equals(data))
                    break;

                index = index.Next;
            }
            return index ?? null;
        }
        private Node<T> GetByIndex(int index)
        {
            if (index < Begin || index > End)
            {
                throw new IndexOutOfRangeException();
            }
            Node<T> current = First;
            int count = Begin; 
            while (current != null)
            {
                if (count == index)
                    return current;
                count++;
                current = current.Next;
            }
            return null;
        }
        public void Clear()
        {
            var listElements = Traverse();
            foreach(var el in listElements)
            {
                Remove(el);
            }
        }

        public bool Contains(T data)
        {
            var node = FindNode(data);
            return (node == null) ? false : true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("The destination array has fewer elements than the collection.");

            var listElements = Traverse().ToArray();

            for (int i = 0; i < listElements.Length; i++)
            {
                array[i + arrayIndex] = listElements[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Traverse().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

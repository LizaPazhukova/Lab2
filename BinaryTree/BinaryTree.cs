using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public Node<T> Root { get; set; }

        public delegate void BinaryTreeHandler(T data, string message);
        public event BinaryTreeHandler Notify;

        public void Insert(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }

            Root = InsertRec(Root, data);
        }

        private Node<T> InsertRec(Node<T> root, T data)
        {
            if (root == null)
            {
                root = new Node<T>() { Data = data };

                Notify?.Invoke(data, $"Was added node with value: {data}");

                return root;
            }
            int result = data.CompareTo(root.Data);
            if (result < 0)
                root.Left = InsertRec(root.Left, data);
            else if (result > 0)
                root.Right = InsertRec(root.Right, data);
            return root;
        }
        public void InsertRange(IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }
            foreach (var item in source)
            {
                Insert(item);
            }
        }
 
        public Node<T> Find(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            return FindNode(data, Root);
         
        }
        private Node<T> FindNode(T data, Node<T> root)
        {
            if (root == null) return null;

            var nodeToFind = new Node<T> { Data = data };

            if (nodeToFind == root)
            {
                return root;
            }

            int result = nodeToFind.Data.CompareTo(root.Data);

            if (result > 0)
            {
                return FindNode(data, root.Right);
            }

            if (result < 0)
            {
                return FindNode(data, root.Left);
            }

            return nodeToFind;
        }

        public void Remove(T data)
        {
            if(data==null)
            {
                throw new ArgumentNullException();
            }
            Root = RemoveRec(Root, data);
        }

        private Node<T> RemoveRec(Node<T> root, T data)
        {
            
            if (root == null) return root;

            int result = data.CompareTo(root.Data);
            if (result < 0)
                root.Left = RemoveRec(root.Left, data);
            else if (result > 0)
                root.Right = RemoveRec(root.Right, data);
            else
            {
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                root.Data = FindMin(root.Right);
                root.Right = RemoveRec(root.Right, root.Data);
            }
            return root;
        }

        private T FindMin(Node<T> root)
        {
            T minValue = root.Data;
            while (root.Left != null)
            {
                minValue = root.Left.Data;
                root = root.Left;
            }
            return minValue;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return PreOrder(Root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> PreOrder(Node<T> root)
        {
            if (root == null)
                yield break;

            yield return root.Data;

            if (root.Left != null)
                foreach (T data in PreOrder(root.Left))
                    yield return data;

            if (root.Right != null)
                foreach (T data in PreOrder(root.Right))
                    yield return data;
        }
    }
}




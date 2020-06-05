 using System;

namespace BinaryTree
{
    public class Node<T> where T : IComparable<T>
    {
        public Node<T> Right { get; set; }
        public Node<T> Left { get; set; }
        public T Data { get; set; }
    }
}




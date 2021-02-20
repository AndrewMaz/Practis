using System;
using System.Collections.Generic;
using System.Linq;

namespace Iterator.Coding.Exercise
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node<T> Parent;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;

            left.Parent = right.Parent = this;
        }

        IEnumerable<Node<T>> Visit(Node<T> current)
        {
            yield return current;

            if (current.Left != null)
                foreach (var n in Visit(current.Left))
                    yield return n;

            if (current.Right != null)
                foreach (var n in Visit(current.Right))
                    yield return n;
        }
        public IEnumerable<T> PreOrder
        {
            get
            {
                foreach (var n in Visit(this))
                    yield return n.Value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var node = new Node<char>('w', new Node<char>('o', new Node<char>('r'), new Node<char>('l')), new Node<char>('d'));


            Console.WriteLine(new string(node.PreOrder.ToArray()));
        }
    }
}

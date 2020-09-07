using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2FelevesFeladat
{
    class NoSuchItemException : Exception
    {
        public NoSuchItemException(string msg) : base(msg)
        {

        }
    }

    class ListSorted<T> where T: IComparable
    {
        class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }
            public Node(T input)
            {
                Value = input;
            }
        }

        private Node<T> head;

        public void Insert(T input)
        {
            Node<T> new1 = new Node<T>(input);
            Node<T> n;

            if (head == null || head.Value.CompareTo(new1.Value) >= 0)
            {
                new1.Next = head;
                head = new1;
            }
            else
            {
                n = head;
                while (n.Next != null && n.Next.Value.CompareTo(new1.Value) < 0)
                {
                    n = n.Next;
                }
                new1.Next = n.Next;
                n.Next = new1;
            }
        }

        public T Delete(T input)
        {
            Node<T> n = head;
            Node<T> p = null;
            while (n != null && !n.Value.Equals(input))
            {
                p = n;
                n = n.Next;
            }
            if (n != null)
            {
                if (p == null)
                {
                    head = n.Next;
                    return n.Value;
                }
                else
                {
                    p.Next = n.Next;
                    return n.Value;
                }
            }
            else
            {
                throw new NoSuchItemException("Nem lehet törölni, mert nincs ilyen elem!");
            }
        }

        public void Print()
        {
            Node<T> n = head;
            while (n != null)
            {
                Console.WriteLine(n.Value.ToString());
                n = n.Next;
            }
        }
    }
}

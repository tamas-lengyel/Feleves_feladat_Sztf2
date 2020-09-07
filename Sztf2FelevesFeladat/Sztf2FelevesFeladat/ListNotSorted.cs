using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2FelevesFeladat
{
    class ListNotSorted<T>
    {
        public class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Next { get; set; }
        }

        private Node<T> head;
        public Node<T> Head { get => head; set => head = value; }

        public void Insert(T input)
        {
            Node<T> new1 = new Node<T>();
            new1.Value = input;
            new1.Next = Head;
            Head = new1;
        }

        public T Delete(T input)
        {
            Node<T> n = Head;
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
                    Head = n.Next;
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

        public T Find(Func<T, bool> function)
        {
            var n = head;

            while (n != null)
            {
                if (function(n.Value) == true)
                {
                    return n.Value;
                }

                n = n.Next;
            }
            return default(T);
        }

        public void Foreach(Action<T> function)
        {
            var n = head;
            while (n != null)
            {
                function(n.Value);
                n = n.Next;
            }
        }

        public T Pop()
        {
            if (head == null)
            {
                return default;
            }

            var n = head;
            head = head.Next;

            return n.Value;
        }

        public void Print()
        {
            Node<T> n = Head;
            while (n != null)
            {
                Console.WriteLine(n.Value.ToString());
                n = n.Next;
            }
        }

        public string IterateString()
        {
            string s = "";
            Node<T> p = head;
            while (p != null)
            {
                s += p.Value;
                p = p.Next;
            }
            return s;
        }

        public T[] ToArray()
        {
            var count = 0;
            var n = head;
            while (n != null)
            {
                count++;
                n = n.Next;
            }

            n = head;
            T[] arr = new T[count];
            for (int i = 0; i < count; i++)
            {
                arr[i] = n.Value;
                n = n.Next;
            }
            return arr;
        }
    }
}

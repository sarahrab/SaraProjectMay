using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_part
{
    public class LinkedList<T>
    {
        protected Node<T> _head;

        public void Append(T value)
        {
            //create new node with value
            Node<T> node = new Node<T>(value);
            //list empty
            if (_head == null)
            {
                _head = node;
                return;
            }
            //get to last node
            Node<T> pointer = _head;
            while (pointer.Next != null)
            {
                pointer = pointer.Next;
            }
            //set next of tail to new node
            pointer.Next = node;
        }

        public void Prepend(T value)
        {
            //create new node with value
            Node<T> node = new Node<T>(value);
            //list empty
            if (_head == null)
            {
                _head = node;
                return;
            }
            node.Next = _head;
            _head = node;
        }

        public T Pop()
        {
            T value = default;
            //empty
            if (_head != null)
            {
                if (_head.Next == null)
                {
                    value = _head.Value;
                    _head = null;
                }
                else
                {
                    //find tail
                    Node<T> pointer = _head;
                    while (pointer.Next.Next != null)
                    {
                        pointer = pointer.Next;
                    }
                    //retrieve value
                    value = pointer.Next.Value;
                    //delete found tail
                    pointer.Next = null;
                }
            }

            return value;
        }

        public T Unqueue()
        {
            T value = default;
            if (_head != null)
            {
                value = _head.Value;
                _head = _head.Next;
            }
            return value;
        }

        public IEnumerable<T> ToList()
        {
            //create List
            List<T> values = new List<T>();
            //go through list, add values to new
            Node<T> pointer = _head;
            while (pointer != null)
            {
                values.Add(pointer.Value);
                pointer = pointer.Next;
            }
            // return new List
            return values;
        }

        public bool IsCircular()
        {
            if (_head != null)
            {
                Node<T> pointer = _head;
                while (pointer.Next != null)
                {
                    if (pointer.Next == _head)
                    {
                        return true;
                    }
                    pointer = pointer.Next;
                }
            }
            return false;
        }

        public void Sort()
        {
            List<T> values = new List<T>(ToList());
            values.Sort();
            _head = null;
            foreach (T value in values)
            {
                Append(value);
            }
        }
    }


    public class IntLinkedList : LinkedList<int>
    {

        public int GetMaxNode()
        {
            if (_head != null)
            {
                int max = _head.Value;
                Node<int> pointer = _head;
                while (pointer.Next != null)
                {
                    if (pointer.Next.Value > max)
                    {
                        max = pointer.Next.Value;
                    }
                }
                return max;
            }
            return int.MinValue;
        }

        public int GetMinNode()
        {
            if (_head != null)
            {
                int min = _head.Value;
                Node<int> pointer = _head;
                while (pointer.Next != null)
                {
                    if (pointer.Next.Value < min)
                    {
                        min = pointer.Next.Value;
                    }
                }
                return min;
            }
            return int.MaxValue;
        }
    }
}

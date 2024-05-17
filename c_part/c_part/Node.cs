using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_part
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node()
        {
            Value = default(T);
            Next = null;
        }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }

        //public bool HasNext
        //{
        //    get
        //    {
        //        return Next != null;
        //    }
        //}
    }
}

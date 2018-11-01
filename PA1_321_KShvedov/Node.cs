using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA1_321_KShvedov
{
    public class Node<T> where T : IComparable
    {
        public Node<T> nLeft;
        public Node<T> nRight;
        public T nContent;

        public Node()
        {
            nLeft = null;
            nRight = null;
        }

        public Node(T cont)
        {
            nContent = cont;
            nLeft = null;
            nRight = null;
        }

        public static bool operator >(Node<T> lhs, Node<T> rhs)
        {
            return lhs.nContent.CompareTo(rhs.nContent) > 0;
        }

        public static bool operator >=(Node<T> lhs, Node<T> rhs)
        {
            return lhs.nContent.CompareTo(rhs.nContent) >= 0;
        }

        public static bool operator <(Node<T> lhs, Node<T> rhs)
        {
            return rhs.nContent.CompareTo(lhs.nContent) > 0;
        }

        public static bool operator <=(Node<T> lhs, Node<T> rhs)
        {
            return rhs.nContent.CompareTo(lhs.nContent) >= 0;
        }

        public static bool operator ==(Node<T> lhs, Node<T> rhs)
        {
            return lhs.nContent.CompareTo(rhs.nContent) == 0;
        }

        public static bool operator !=(Node<T> lhs, Node<T> rhs)
        {
            return lhs.nContent.CompareTo(rhs.nContent) != 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA1_321_KShvedov
{
    public class AVLtree<T> : BinTree<T> where T : IComparable
    {
        private Node<T> head;
        private int nCount = 0;
        private int maxDepth = 0;
        private int tempDepth = 0;

        public AVLtree()
        {
            head = null;
        }

        /*This is the required count function that simply adds an a new value to the count variable when called*/
        private void count()
        {
            nCount++;
        }

        /*All variables are private so get functions are needed to be able to access the information*/
        public int getCount()
        {
            return nCount;
        }

        public int getMaxDepth()
        {
            return maxDepth;
        }
        /********************************************************************************************/

        /*The initial insert function is called and if there is no head node it is madde and set*/
        public override void Insert(T val)
        {
            Node<T> cur = new Node<T>();
            Node<T> newNode = new Node<T>(val);
            cur = head;
            tempDepth = 0;
            if (!ReferenceEquals(head, null))
            {
                InsertRec(cur, newNode);
                if (!ReferenceEquals(cur.nRight, null))
                {
                    cur.nRight = rotateCheck(cur.nRight);
                }
                if (!ReferenceEquals(cur.nLeft, null))
                {
                    cur.nLeft = rotateCheck(cur.nLeft);
                }
                head = rotateCheck(cur);
            }
            else
            {
                head = newNode;
                count();
            }
            if (maxDepth < tempDepth)
            {
                maxDepth = tempDepth;
            }
        }

        /*The recursive inser is private and only called from the other insert function after chechking if there is a head node*/
        private void InsertRec(Node<T> cur, Node<T> insertNode)
        {
            if (cur < insertNode)
            {
                tempDepth++;
                if (!ReferenceEquals(cur.nRight, null))
                {
                    cur = cur.nRight;
                    InsertRec(cur, insertNode);
                    if (!ReferenceEquals(cur.nRight, null))
                    {
                        cur.nRight = rotateCheck(cur.nRight);
                    }
                    if (!ReferenceEquals(cur.nLeft, null))
                    {
                        cur.nLeft = rotateCheck(cur.nLeft);
                    }
                }
                else
                {
                    cur.nRight = insertNode;
                    count();
                }
            }
            else if (cur > insertNode)
            {
                tempDepth++;
                if (!ReferenceEquals(cur.nLeft, null))
                {
                    cur = cur.nLeft;
                    InsertRec(cur, insertNode);
                    if (!ReferenceEquals(cur.nRight, null))
                    {
                        cur.nRight = rotateCheck(cur.nRight);
                    }
                    if (!ReferenceEquals(cur.nLeft, null))
                    {
                        cur.nLeft = rotateCheck(cur.nLeft);
                    }
                }
                else
                {
                    cur.nLeft = insertNode;
                    count();
                }
            }
            else if (cur == insertNode)
            {
                //do nothing since this means it already exists, recursive function makes it leave
            }
        }

        private Node<T> rotateCheck(Node<T> cur)
        {
            Node<T> tempNode1 = new Node<T>();
            Node<T> tempNode2 = new Node<T>();
            int temp = countNodes(cur.nLeft) - countNodes(cur.nRight);
            int temp2 = 0, temp3 = 0;
            if (temp > -1 && temp < 1)
            {
                //do nothing, balance
                return cur;
            }
            else if (temp > 1)
            {
                temp2 = countNodes(cur.nLeft.nLeft);
                temp3 = countNodes(cur.nLeft.nRight);
                if (temp2 > temp3)
                {
                    //no need to do the first rotation
                }
                else
                {
                    tempNode1 = cur.nLeft;
                    tempNode2 = cur.nLeft.nRight;
                    cur.nLeft = tempNode2;
                    tempNode1.nRight = tempNode2.nLeft;
                    tempNode2.nLeft = tempNode1;
                }
                tempNode1 = cur.nLeft;
                tempNode2 = cur;
                tempNode2.nLeft = tempNode1.nRight;
                tempNode1.nRight = tempNode2;
                return tempNode1;
            }
            else if (temp < -1)
            {
                temp2 = countNodes(cur.nRight.nLeft);
                temp3 = countNodes(cur.nRight.nRight);
                if (temp2 > temp3)
                {
                    tempNode1 = cur.nRight;
                    tempNode2 = cur.nRight.nLeft;
                    cur.nRight = tempNode2;
                    tempNode1.nLeft = tempNode2.nRight;
                    tempNode2.nRight = tempNode1;
                }
                else
                {
                    //no need to the first rotation
                }
                tempNode1 = cur.nRight;
                tempNode2 = cur;
                tempNode2.nRight = tempNode1.nLeft;
                tempNode1.nLeft = tempNode2;
                return tempNode1;
            }
            else
            {
                return cur;
            }
        }

        private int countNodes(Node<T> cur)
        {
            int temp1 = 0, temp2 = 0;
            if (!ReferenceEquals(cur, null))
            {
                temp1 += countNodes(cur.nLeft) + 1;
                temp2 += countNodes(cur.nRight) + 1;
                if (temp1 > temp2)
                {
                    return temp1;
                }
                else return temp2;
            }
            else return 0;
        }

        /*Since the recursive print function is private this public function is neede to be able to print the contents of the BST*/
        public void printBSTree()
        {
            Console.Write("PreOrder Print: ");
            PreOrder();
            Console.WriteLine();

            Console.Write("InOrder Print: ");
            InOrder();
            Console.WriteLine();

            Console.Write("PostOrder Print: ");
            PostOrder();
            Console.WriteLine();
        }

        public override bool Contains(T val)
        {
            Node<T> newNode = new Node<T>(val);
            Node<T> cur = new Node<T>();
            cur = head;
            if (ReferenceEquals(cur, null))
            {
                return false;
            }
            else if (cur == newNode)
            {
                return true;
            }
            else
            {
                return ContainsHelper(cur, newNode);
            }
        }

        private bool ContainsHelper(Node<T> cur, Node<T> newNode)
        {
            if (ReferenceEquals(cur, null))
            {
                return false;
            }
            else if (cur > newNode)
            {
                return ContainsHelper(cur.nLeft, newNode);
            }
            else if (cur < newNode)
            {
                return ContainsHelper(cur.nRight, newNode);
            }
            else
            {
                return true;
            }
        }

        public override void InOrder()
        {
            InOrderHelper(head);
        }

        private void InOrderHelper(Node<T> cur)
        {
            if (ReferenceEquals(cur, null))
            {
                return;
            }
            InOrderHelper(cur.nLeft);
            Console.Write("{0} ", cur.nContent);
            InOrderHelper(cur.nRight);
        }

        public override void PreOrder()
        {
            PreOrderHelper(head);
        }

        private void PreOrderHelper(Node<T> cur)
        {
            if (ReferenceEquals(cur, null))
            {
                return;
            }
            Console.Write("{0} ", cur.nContent);
            PreOrderHelper(cur.nLeft);
            PreOrderHelper(cur.nRight);
        }

        public override void PostOrder()
        {
            PostOrderHelper(head);
        }

        private void PostOrderHelper(Node<T> cur)
        {
            if (ReferenceEquals(cur, null))
            {
                return;
            }
            PostOrderHelper(cur.nLeft);
            PostOrderHelper(cur.nRight);
            Console.Write("{0} ", cur.nContent);
        }
    }
}

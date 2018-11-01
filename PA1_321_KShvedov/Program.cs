using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA1_321_KShvedov
{
    /*This class is in charge of housing the program and making it run*/
    class Program
    {
        static void Main(string[] args)
        {
            int levels1 = 0, minLevels1 = 0;
            int levels2 = 0, minLevels2 = 0;

            BSTree<int> nTree = new BSTree<int>();
            AVLtree<int> aTree = new AVLtree<int>();
            string tempSt;

            /*The program asks for the users input for all the values that will be in the tree(the values are correctrly formatted)*/
            Console.WriteLine("Enter a collection of numbers in the range [0, 100], seperate by spaces: ");
            tempSt = Console.ReadLine();

            /*Formats the string into a string array and then formats it again into a int array*/
            string[] values = tempSt.Split(' ');
            int[] convertToInt = Array.ConvertAll<string, int>(values, Convert.ToInt32);

            /*Every enetered integer is inserted one by one*/
            for(int i = 0; i < convertToInt.Length; i++)
            {
                nTree.Insert(convertToInt[i]);
                aTree.Insert(convertToInt[i]);
            }

            /*The next statements are used to print information abou the tree that has been cretaed from user data*/
            /*Makes sure that tree isn't empty*/
            if (nTree.getCount() == 0)
            {
                levels1 = 0;
                minLevels1 = 0;
            }
            else
            {
                levels1 = nTree.getMaxDepth() + 1;
                minLevels1 = (int)Math.Log(nTree.getCount(), 2) + 1;
            }

            if (aTree.getCount() == 0)
            {
                levels2 = 0;
                minLevels2 = 0;
            }
            else
            {
                levels2 = aTree.getMaxDepth() + 1;
                minLevels2 = (int)Math.Log(aTree.getCount(), 2) + 1;
            }

            Console.WriteLine("BST Tree contents: ");
            nTree.printBSTree();
            Console.WriteLine("Tree statistics:");
            Console.WriteLine(" Number of nodes: {0}", nTree.getCount());
            Console.WriteLine(" Nuber of levels: {0}", levels1);
            Console.WriteLine(" Minimum nuber of levels that a tree with {0} nodes could have = {1}", nTree.getCount(), minLevels1);
            Console.WriteLine("Done");

            Console.WriteLine();
            Console.WriteLine("AVL Tree contents: ");
            aTree.printBSTree();
            Console.WriteLine("Tree statistics:");
            Console.WriteLine(" Number of nodes: {0}", aTree.getCount());
            Console.WriteLine(" Minimum nuber of levels that a tree with {0} nodes could have = {1}", aTree.getCount(), minLevels2);
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}

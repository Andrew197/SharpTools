using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//custom
using Sharptools.Trees;
using Sharptools.Arrays;

//this is a driver program for SharpTools
namespace SharpTree
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            //int[] array = IntArray.newTestArray();
            //BinarySearchTree bst = new BinarySearchTree(array);

            BinarySearchTree bst = new BinarySearchTree(IntArray.newRandomArray(10, arrayType.NO_DUPLICATES));                  
            Console.WriteLine(bst.ToString());

            Console.WriteLine("deletion attempt for id 3");
            bst.deleteNode(3);
            Console.WriteLine(bst.ToString());

            Console.Read();
            testArrays();
            Console.Read(); Console.Read();
        }

        public void testArrays()
        {
            int[] array = IntArray.newRandomArray(25, arrayType.NO_DUPLICATES);
            Console.WriteLine(IntArray.ToString(array));

            array = IntArray.shuffle(array);
            Console.WriteLine(IntArray.ToString(array));

            array = IntArray.shuffle(array);
            Console.WriteLine(IntArray.ToString(array));

            array = IntArray.shuffle(array);
            Console.WriteLine(IntArray.ToString(array));

            Array.Sort(array);
            Console.WriteLine(IntArray.ToString(array));

            array = IntArray.newRandomArray(0, arrayType.NO_DUPLICATES);
            Console.WriteLine(IntArray.ToString(array));
        }
    }
}

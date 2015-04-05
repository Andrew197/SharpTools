using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Array Tools class
//to use, add 'using Sharptools.arrays' to your program

namespace Sharptools.Arrays
{
    public enum arrayType
    {
        NO_DUPLICATES,      //this array will not allow duplicates
        NORMAL              //NORMAL can be omitted if desired
    };

    static class IntArray
    {
        //external API
        public static int[] newRandomArray()                      { return populate(arrayType.NORMAL, -1);  }
        public static int[] newRandomArray(int len)               { return populate(arrayType.NORMAL, len); }
        public static int[] newRandomArray(arrayType at)          { return populate(at, -1);                }
        public static int[] newRandomArray(int len, arrayType at) { return populate(at, len);               }

        //internal
        private static int[] populate(arrayType at, int len)
        {
            Random rand = new Random();                                                     //random number generator
            if (len == -1) len = rand.Next(10, 50);                                         //randomize the length if it isn't given
            int[] array = new int[len];                                                     //initialize the array we set up

            if (at == arrayType.NO_DUPLICATES)
            {
                for (int i = 0; i < array.Length; i++) array[i] = i;
                    array = shuffle(array);
                return array;
            }
            else
            {
                //normal array
                for (int i = 0; i < array.Length; i++) array[i] = rand.Next(1, len);
                return array;
            }
        }

        //print any integer array
        public static string ToString(int [] array)
        {
            string outStr = "";
            for(int i=0;i<array.Length;i++)
                outStr += array[i] + " ";

            return outStr;
        }

        public static int [] shuffle(int [] array)
        {
            Random rand = new Random();

            bool[] used = new bool[array.Length];                                       //keep track of what's been applied to the array
            for (int i = 0; i < used.Length; i++) used[i] = false;                      //"zero out" the boolean array
            int rnd = rand.Next(0, array.Length);                                       //pick the first random number

            //create the array to copy into
            int[] result = new int[array.Length];

            //shuffle the array
            for(int i=0;i<array.Length;i++)
            {
                while (used[rnd]) rnd = rand.Next(0, array.Length);                     //keep picking a number until we get one that hasn't been picked
                result[i] = array[rnd];                                                 //use the picked value
                used[rnd] = true;                                                       //mark picked value as used
            }
            return result;
        }

        public static int binarySearch(int[] array, int key)
        {
            int low = 0;
            int high = array.Length;
            int mid;

            while (low <= high)
            {
                mid = (low + high) / 2;
                if (array[mid] == key) return mid;
                if (array[mid] < key) low = mid + 1;
                else if (array[mid] > key) high = mid - 1;
            }
            return -1;
        }
    }
}

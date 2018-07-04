using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchinandSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arry = {17,8,18,7,4,16,3,23};
            Sort(arry, 0, arry.Length - 1);
            foreach(int i in arry)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();
            Console.WriteLine(BinarySearch(arry,23));
            Console.ReadKey();
        }
        #region Search
        //public void LinearSearch()
        //{

        //}
        /// <summary>
        /// Binary Search
        /// </summary>
        /// <param name="arry"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int BinarySearch(int[] arry, int key)
        {
            int low = 0;
            int high = arry.Length - 1;
            while(low <=high)
            {
                int k = (low + high) / 2;
                if (arry[k] == key)
                {
                    return key;
                }
                else if (arry[k] > key)
                {
                    high = k - 1;
                }
                else if (arry[k] < key)
                {
                    low = k + 1;
                }
            }
            return -1;
        }

        //public void InterpolationSearch()
        //{

        //}

        public void HashTable()
        {

        }
        #endregion

        #region Sort
        //public void BubbleSort()
        //{

        //}
        //public void SelectionSort()
        //{

        //}
        //public void MergeSort()
        //{

        //}
        //public void ShellSort()
        //{

        //}

        public static void InsertionSort(int[] arry)
        {
            for(int i = 1; i < arry.Length; i++)
            {
                for(int j= i; j>0; j--)
                {
                    if (arry[j] <arry[j-1])
                    {
                        int temp = arry[j-1];
                        arry[j - 1] = arry[j];
                        arry[j] = temp;
                    }
                    
                }
            }
            foreach (int k in arry)
            {
                Console.Write(k + " ");
            }
        }

        /// <summary>
        /// Quick Sort
        /// </summary>
        /// <param name="arry"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void Sort(int[] arry,int left,int right)
        {
            if (left >= right)
                return;
            int index = QuickSort(arry, left, right);
            Sort(arry, left, index-1);
            Sort(arry, index + 1,right);
        }
        public static int QuickSort(int[] arry,int left, int right)
        {
            int num = arry[left];
            int i= left;
            int j = right;
            while (i < j)
            {
                if (arry[j] > num&& i < j)
                {
                    j--;
                }
                arry[i] = arry[j];
                if (arry[i] < num && i < j)
                {
                    i++;
                }
                arry[j] = arry[i];
            }
            arry[i] = num;
            return i;
        }

        public void HeapSort()
        {

        }

        #endregion
    }


}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuickThreadSorting
{
    class QuickSort
    {
        private bool useThread;
        private int length;

        /// <summary>
        /// Use thread when the to be sorted array is larger than length.
        /// </summary>
        /// <param name="useThread"></param>
        /// <param name="length"></param>
        public QuickSort(bool useThread, int length = 10000)
        {
            this.useThread = useThread;
            this.length = 10;
        }

        public void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private void Sort(int[] arr, int low, int high)
        {
            if (low >= high)
                return;

            int p = Partition(arr, low, high);


            if (useThread && p - 1 - low > length)
            {
                Task.Run(() =>
                {
                    Sort(arr, low, p - 1);
                });
            }
            else
            {
                Sort(arr, low, p - 1);
            }

            if (useThread && high - p - 1 > length)
            {
                Task.Run(() =>
                {
                    Sort(arr, p + 1, high);
                });
            }
            else
            {
                Sort(arr, p + 1, high);
            }
        }

        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low;
            for (int j = low; j <= high; j++)
            {
                if (arr[j] < pivot)
                {
                    Swap(ref arr[i], ref arr[j]);
                    i++;
                }
            }

            Swap(ref arr[i], ref arr[high]);

            return i;
        }

        private void Swap(ref int a, ref int b)
        {
            if (a == b) return;

            int temp = a;
            a = b;
            b = temp;
        }
    }
}

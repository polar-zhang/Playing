using System;
using System.Linq;

namespace QuickThreadSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr1 = CreateRandomArray(10000000);
            var arr2 = new int[arr1.Length];
            arr1.CopyTo(arr2, 0);

            DateTime dateTime = DateTime.Now;
            new QuickSort(true, 1000).Sort(arr2);
            Console.WriteLine("Use Thread: {0}", (DateTime.Now - dateTime).Ticks);

            dateTime = DateTime.Now;
            new QuickSort(false).Sort(arr1);
            Console.WriteLine(" No Thread: {0}", (DateTime.Now - dateTime).Ticks);

            Console.WriteLine("Press any key to continue.");
            Console.Read();
        }

        private static void PrintArray(int[] arr)
        {
            foreach(var a in arr)
            {
                Console.Write(a + " ");
            }
        }

        private static int[] CreateRandomArray(int length)
        {
            int[] arr = new int[length];
            for(int i = 0; i < length;i ++)
            {
                arr[i] = i;
            }

            return arr.OrderBy(a => Guid.NewGuid()).ToArray();
        }
    }
}
